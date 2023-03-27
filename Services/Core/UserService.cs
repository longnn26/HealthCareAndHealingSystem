using AutoMapper;
using Data.DataAccess;
using Data.Entities;
using Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Core
{
    public interface IUserService
    {
        Task<ResultModel> Register(UserCreateModel model);
        Task<ResultModel> Login(LoginModel model);
        Task<ResultModel> RegisterAdmin(UserCreateModel model);

        ResultModel Update(UserUpdateModel model);
        ResultModel GetAll();
    }
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public UserService(AppDbContext dbContext, IMapper mapper, IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public ResultModel GetAll()
        {
            ResultModel result = new ResultModel();
            try
            {
                var data = _dbContext.User;
                var view = _mapper.ProjectTo<UserModel>(data);
                result.Data = view;
                result.Succeed = true;
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.InnerException != null ? e.InnerException.Message : e.Message;
            }
            return result;
        }

        public async Task<ResultModel> Login(LoginModel model)
        {
            var result = new ResultModel();
            result.Succeed = false;
            var user = await _userManager.FindByNameAsync(model.phoneNumber);
            if (user != null)
            {
                var check = await _signInManager.CheckPasswordSignInAsync(user, model.password, false);
                if (!check.Succeeded)
                {
                    if (!user.EmailConfirmed)
                    {
                        //await SendMailConfirm(user);
                        result.ErrorMessage = "Unconfirmed Email. Please check email for confirm!";
                    }
                    else
                    {
                        result.ErrorMessage = "Password is wrong!";
                    }
                }
                else
                {
                    var userRoles = _dbContext.UserRoles.Where(ur => ur.UserId == user.userID).ToList();
                    var roles = new List<string>();
                    foreach (var userRole in userRoles)
                    {
                        var role = await _dbContext.Role.FindAsync(userRole.RoleId);
                        if (role != null) roles.Add(role.Name);
                    }
                    var token = GetAccessToken(user, roles);
                    result.Succeed = true;
                    result.Data = token;

                }
            }
            else
            {

                result.ErrorMessage = "Phone Number not found!";
            }
            return result;
        }

        public async Task<ResultModel> Register(UserCreateModel model)
        {
            var result = new ResultModel();
            result.Succeed = false;
            try
            {
                var user = new User
                {
                    UserName = model.userName.Trim(),
                    Email = model.Email.Trim(),
                    firstName = model.firstName.Trim(),
                    lastName = model.lastName.Trim(),
                    address = model.address.Trim(),
                    phoneNumber = model.phoneNumber,
                    NormalizedEmail = model.Email.Trim(),
                    bookingStatus = false,
                    banStatus = false,
                    gender = true
                };
                var check = await _userManager.CreateAsync(user, model.password);
                if (!check.Succeeded)
                {
                    result.ErrorMessage = check.ToString();
                    return result;
                }
                result.Succeed = true;
                result.Data = user.userID;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;

        }
        public async Task<ResultModel> RegisterAdmin(UserCreateModel model)
        {
            var result = new ResultModel();
            result.Succeed = false;
            try
            {
                var user = new User
                {
                    UserName = model.userName.Trim(),
                    Email = model.Email.Trim(),
                    firstName = model.firstName.Trim(),
                    lastName = model.lastName.Trim(),
                    address = model.address.Trim(),
                    phoneNumber = model.phoneNumber,
                    NormalizedEmail = model.Email.Trim(),
                    bookingStatus = false,
                    banStatus = false,
                    gender = true
                };
                var check = await _userManager.CreateAsync(user, model.password);
                if (!await _roleManager.RoleExistsAsync("Admin"))
                {
                    await _roleManager.CreateAsync(new Role { Description = "Role for Admin", Name = "Admin" });
                }
                var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "Admin");
                var userRole = new UserRole
                {
                    RoleId = role.Id,
                    UserId = user.Id
                };
                _dbContext.UserRoles.Add(userRole);
                await _dbContext.SaveChangesAsync();
                result.Succeed = true;
                result.Data = user.Id;
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            }
            return result;

        }
        ResultModel IUserService.Update(UserUpdateModel model)
        {
            throw new NotImplementedException();
        }
        private async Task<Token> GetAccessToken(User user, List<string> role)
        {
            List<Claim> claims = GetClaims(user, role);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddHours(int.Parse(_configuration["Jwt:ExpireTimes"])),
              //int.Parse(_configuration["Jwt:ExpireTimes"]) * 3600
              signingCredentials: creds);

            var serializedToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token
            {
                Access_token = serializedToken,
                Token_type = "Bearer",
                Expires_in = int.Parse(_configuration["Jwt:ExpireTimes"]) * 3600,
                userID = user.Id.ToString(),
                username = user.UserName,
                firstName = user.firstName,
                phoneNumber = user.phoneNumber,
                lastName = user.lastName,
            };
        }
        private List<Claim> GetClaims(User user, List<string> roles)
        {
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim> {
                new Claim("UserId", user.Id.ToString()),
                new Claim("Email", user.Email),
                new Claim("FullName", user.firstName),
                
                new Claim("UserName", user.UserName)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            if (!string.IsNullOrEmpty(user.PhoneNumber)) claims.Add(new Claim("PhoneNumber", user.PhoneNumber));
            return claims;
        }


    }

}

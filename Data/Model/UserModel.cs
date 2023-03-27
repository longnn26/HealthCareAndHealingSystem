using Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class UserModel : User
    {

    }
    public class UserCreateModel
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string address { get; set; }

        public DateTime dob { get; set; }
        public string phoneNumber { get; set; }
        public bool gender { get; set; } = true;
        public bool bookingStatus { get; set; }
        public bool banStatus { get; set; }
    }

    public class UserUpdateModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public DateTime dob { get; set; }
        public string phoneNumber { get; set; }                                                                                                                                                     
        public bool gender { get; set; } = true;
        public bool bookingStatus { get; set; }
        public bool banStatus { get; set; }
    }
    public class UserUpdatePasswordModel
    {
        public string password { get; set; }
    }
   
    public class LoginModel
    {
        public string phoneNumber { get; set; }
        public string password { get; set; }
    }
}
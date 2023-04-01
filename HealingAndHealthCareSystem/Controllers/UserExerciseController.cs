using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;
using static Data.Model.UserExerciseCreateModel;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserExerciseController : ControllerBase
    {
        private readonly IUserExerciseService _userExerciseservice;
        public UserExerciseController(IUserExerciseService userExerciseService)
        {
            _userExerciseservice = userExerciseService;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]

        [HttpPost]
        public IActionResult Post([FromBody] UserExerciseCreateModel model)
        {
            var result = _userExerciseservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _userExerciseservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _userExerciseservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _userExerciseservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(UserExerciseUpdateModel model)
        {
            var result = _userExerciseservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}

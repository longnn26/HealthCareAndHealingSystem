using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseDetailController : ControllerBase
    {
        private readonly IExerciseDetailService _exerciseDetailservice;
        private readonly IExerciseDetailService _exerciseDetailservice1;
        public ExerciseDetailController(IExerciseDetailService exerciseDetailService, IExerciseDetailService exerciseDetailService1)
        {
            _exerciseDetailservice = exerciseDetailService;
            _exerciseDetailservice1 = exerciseDetailService1;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] ExerciseDetailCreateModel model)
        {
            var result = _exerciseDetailservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _exerciseDetailservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _exerciseDetailservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _exerciseDetailservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(ExerciseDetailUpdateModel model)
        {
            var result = _exerciseDetailservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        
    }
}

using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordservice;
        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordservice = medicalRecordService;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] MedicalRecordCreateModel model)
        {
            var result = _medicalRecordservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _medicalRecordservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _medicalRecordservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _medicalRecordservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(MedicalRecordUpdateModel model)
        {
            var result = _medicalRecordservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

    }
}

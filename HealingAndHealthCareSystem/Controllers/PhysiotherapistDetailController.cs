using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysiotherapistDetailController : ControllerBase
    {
        private readonly IPhysiotherapistDetailService _physiotherapistDetailservice;
        private readonly IPhysiotherapistDetailService _physiotherapistDetailservice1;
        public PhysiotherapistDetailController(IPhysiotherapistDetailService physiotherapistDetailService, IPhysiotherapistDetailService physiotherapistDetailService1)
        {
            _physiotherapistDetailservice = physiotherapistDetailService;
            _physiotherapistDetailservice1 = physiotherapistDetailService1;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] PhysiotherapistDetailCreateModel model)
        {
            var result = _physiotherapistDetailservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _physiotherapistDetailservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _physiotherapistDetailservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _physiotherapistDetailservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(PhysiotherapistDetailUpdateModel model)
        {
            var result = _physiotherapistDetailservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        

    }
}

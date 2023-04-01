using Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Core;

namespace HealingAndHealthCareSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysiotherapistSlotController : ControllerBase
    {
        private readonly IPhysiotherapistSlotService _physiotherapistSlotservice;
        private readonly IPhysiotherapistSlotService _physiotherapistSlotservice1;
        public PhysiotherapistSlotController(IPhysiotherapistSlotService physiotherapistSlotService, IPhysiotherapistSlotService physiotherapistSlotService1)
        {
            _physiotherapistSlotservice = physiotherapistSlotService;
            _physiotherapistSlotservice1 = physiotherapistSlotService1;
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] PhysiotherapistSlotCreateModel model)
        {
            var result = _physiotherapistSlotservice.Add(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }

        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public IActionResult Get()
        {
            var result = _physiotherapistSlotservice.GetAll();
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _physiotherapistSlotservice.Get(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            var result = _physiotherapistSlotservice.Delete(id);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }
        [HttpPut]
        public IActionResult Update(PhysiotherapistSlotUpdateModel model)
        {
            var result = _physiotherapistSlotservice.Update(model);
            if (result.Succeed) return Ok(result.Data);
            return BadRequest(result.ErrorMessage);
        }


    }
}

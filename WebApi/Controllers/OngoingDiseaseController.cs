using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.OngoingDisease;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OngoingDiseaseController : ControllerBase
    {
        private IOngoingDiseaseService _ongoingDiseaseService;
        public OngoingDiseaseController(IOngoingDiseaseService ongoingDiseaseService)
        {
            _ongoingDiseaseService = ongoingDiseaseService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ongoingDiseaseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _ongoingDiseaseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(OngoingDiseaseForCreateDto ongoingDeseases)
        {
            var result = _ongoingDiseaseService.Add(ongoingDeseases);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(OngoingDiseaseForCreateDto ongoingDeseases)
        {
            var result = _ongoingDiseaseService.Update(ongoingDeseases);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(OngoingDiseaseForCreateDto ongoingDeseases)
        {
            var result = _ongoingDiseaseService.Delete(ongoingDeseases);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

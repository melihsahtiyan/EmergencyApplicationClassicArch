using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.Allergy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly IAllergyService _allergyService;
        public AllergiesController(IAllergyService allergyService)
        {
            _allergyService = allergyService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _allergyService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _allergyService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(AllergyForCreateDto allergy)
        {
            var result = _allergyService.Add(allergy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(AllergyForCreateDto allergy)
        {
            var result = _allergyService.Update(allergy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(AllergyForCreateDto allergy)
        {
            var result = _allergyService.Delete(allergy);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

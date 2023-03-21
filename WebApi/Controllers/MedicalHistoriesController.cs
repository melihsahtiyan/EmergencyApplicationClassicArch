using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.MedicalHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalHistoriesController : ControllerBase
    {
        private IMedicalHistoryService _medicalHistoryService;
        public MedicalHistoriesController(IMedicalHistoryService medicalHistoryService)
        {
            _medicalHistoryService = medicalHistoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _medicalHistoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _medicalHistoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(MedicalHistoryForCreateDto medicalHistory)
        {
            var result = _medicalHistoryService.Add(medicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(MedicalHistoryForCreateDto medicalHistory)
        {
            var result = _medicalHistoryService.Update(medicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(MedicalHistoryForCreateDto medicalHistory)
        {
            var result = _medicalHistoryService.Delete(medicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

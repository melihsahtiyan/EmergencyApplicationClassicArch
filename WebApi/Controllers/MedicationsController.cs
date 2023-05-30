using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.Medication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private IMedicationService _medicationService;
        public MedicationsController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _medicationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _medicationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(MedicationForCreateDto medication)
        {
            var result = _medicationService.Add(medication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addlist")]
        public IActionResult AddList(List<MedicationForCreateDto> medications)
        {
            var result = _medicationService.AddList(medications);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(MedicationForCreateDto medication)
        {
            var result = _medicationService.Update(medication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("updatelist")]
        public IActionResult UpdateList(List<MedicationForCreateDto> medications)
        {
            var result = _medicationService.UpdateList(medications);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(MedicationForCreateDto medication)
        {
            var result = _medicationService.Delete(medication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("deletelist")]
        public IActionResult DeleteList(List<MedicationForCreateDto> medications)
        {
            var result = _medicationService.DeleteList(medications);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

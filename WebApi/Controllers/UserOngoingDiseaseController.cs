using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.OngoingDisease;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOngoingDiseaseController : ControllerBase
    {
        IUserOngoingDiseaseService _userOngoingDiseaseService;
        public UserOngoingDiseaseController(IUserOngoingDiseaseService userOngoingDiseaseService)
        {
            _userOngoingDiseaseService = userOngoingDiseaseService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userOngoingDiseaseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userOngoingDiseaseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userOngoingDiseaseService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(UserOngoingDiseaseForCreateDto userMedicalHistory)
        {
            var result = _userOngoingDiseaseService.Add(userMedicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(UserOngoingDiseaseForCreateDto userMedicalHistory)
        {
            var result = _userOngoingDiseaseService.Update(userMedicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(UserOngoingDiseaseForCreateDto userMedicalHistory)
        {
            var result = _userOngoingDiseaseService.Delete(userMedicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

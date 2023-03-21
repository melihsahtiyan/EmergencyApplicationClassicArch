using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.MedicalHistory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMedicalHistoriesController : ControllerBase
    {
        IUserMedicalHistoriesService _userMedicalHistoriesService;
        public UserMedicalHistoriesController(IUserMedicalHistoriesService userMedicalHistoryService)
        {
            _userMedicalHistoriesService = userMedicalHistoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userMedicalHistoriesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userMedicalHistoriesService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userMedicalHistoriesService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(UserMedicalHistoriesForCreateDto userMedicalHistory)
        {
            var result = _userMedicalHistoriesService.Add(userMedicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(UserMedicalHistoriesForCreateDto userMedicalHistory)
        {
            var result = _userMedicalHistoriesService.Update(userMedicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(UserMedicalHistoriesForCreateDto userMedicalHistory)
        {
            var result = _userMedicalHistoriesService.Delete(userMedicalHistory);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

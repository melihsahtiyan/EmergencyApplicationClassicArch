using Business.Abstract;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Allergy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAllergiesController : ControllerBase
    {
        IUserAllergiesService _userAllergiesService;
        public UserAllergiesController(IUserAllergiesService userAllergiesService)
        {
            _userAllergiesService = userAllergiesService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userAllergiesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userAllergiesService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserallergiesbyuserid")]
        public IActionResult GetUserAllergiesByUserId(int userId)
        {
            var result = _userAllergiesService.GetUserAllergiesByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserAllergiesForCreateDto userAllergies)
        {
            var result = _userAllergiesService.Add(userAllergies);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserAllergiesForCreateDto userAllergies)
        {
            var result = _userAllergiesService.Update(userAllergies);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserAllergiesForCreateDto userAllergies)
        {
            var result = _userAllergiesService.Delete(userAllergies);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

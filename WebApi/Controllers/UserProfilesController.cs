using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.UserProfile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : ControllerBase
    {
        IUserProfileService _userProfileService;
        public UserProfilesController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userProfileService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userProfileService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(UserProfileForCreateDto userProfile)
        {
            var result = _userProfileService.Add(userProfile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("update")]
        public IActionResult Update(UserProfileForCreateDto userProfile)
        {
            var result = _userProfileService.Update(userProfile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(UserProfileForCreateDto userProfile)
        {
            var result = _userProfileService.Delete(userProfile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

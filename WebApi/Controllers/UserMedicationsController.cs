using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMedicationsController : ControllerBase
    {
        IUserMedicationsService _userMedicationsService;
        public UserMedicationsController(IUserMedicationsService userMedicationsService)
        {
            _userMedicationsService = userMedicationsService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userMedicationsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userMedicationsService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserMedications userMedication)
        {
            var result = _userMedicationsService.Add(userMedication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserMedications userMedication)
        {
            var result = _userMedicationsService.Update(userMedication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserMedications userMedication)
        {
            var result = _userMedicationsService.Delete(userMedication);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

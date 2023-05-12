using Business.Abstract;
using Entity.Dtos.Source;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourcesController : ControllerBase
    {
        private ISourceService _sourceService;

        public SourcesController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _sourceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getallbypostid")]
        public IActionResult GetAllByPostId(int postId)
        {
            var result = _sourceService.GetAllByPostId(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int sourceId)
        {
            var result = _sourceService.GetById(sourceId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] SourceForCreateDto sourceForCreateDto,
            [FromForm(Name = "Source")] IFormFile file)
        {
            var result = _sourceService.Add(sourceForCreateDto, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(SourceForCreateDto sourceForCreateDto)
        {
            var result = _sourceService.Update(sourceForCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(SourceForCreateDto sourceForCreateDto)
        {
            var result = _sourceService.Delete(sourceForCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }           
    }
}

using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostTemplatesController : ControllerBase
    {
        private readonly IPostTemplateService _postTemplateService;

        public PostTemplatesController(IPostTemplateService postTemplateService)
        {
            _postTemplateService = postTemplateService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _postTemplateService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int postTemplateId)
        {
            var result = _postTemplateService.GetById(postTemplateId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(PostTemplate postTemplate)
        {
            var result = _postTemplateService.Add(postTemplate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("addlist")]
        public IActionResult AddList(List<PostTemplate> postTemplates)
        {
            var result = _postTemplateService.AddList(postTemplates);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(PostTemplate postTemplate)
        {
            var result = _postTemplateService.Update(postTemplate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(PostTemplate postTemplate)
        {
            var result = _postTemplateService.Delete(postTemplate);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("deletelist")]
        public IActionResult DeleteList(List<PostTemplate> postTemplates)
        {
            var result = _postTemplateService.DeleteList(postTemplates);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

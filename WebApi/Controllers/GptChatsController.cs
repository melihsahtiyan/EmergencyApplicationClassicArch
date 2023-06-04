using Business.Abstract;
using Entity.Concrete;
using Entity.Dtos.GptChats;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GptChatsController : ControllerBase
    {
        private readonly IGptChatsService _gptChatsService;

        public GptChatsController(IGptChatsService gptChatsService)
        {
            _gptChatsService = gptChatsService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _gptChatsService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _gptChatsService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbypostid")]
        public IActionResult GetByPostId(int postId)
        {
            var result = _gptChatsService.GetByPostId(postId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int gptChatId)
        {
            var result = _gptChatsService.GetById(gptChatId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("getbyresponseid")]
        public IActionResult GetByResponseId(string responseId)
        {
            var result = _gptChatsService.GetByResponseId(responseId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(GptChatsForCreateDto gptChat)
        {
            var result = _gptChatsService.Add(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(GptChatsForCreateDto gptChat)
        {
            var result = _gptChatsService.Update(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(GptChatsForCreateDto gptChat)
        {
            var result = _gptChatsService.Delete(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("deletelist")]
        public IActionResult DeleteList(List<GptChatsForCreateDto> gptChats)
        {
            var result = _gptChatsService.DeleteList(gptChats);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addlist")]
        public IActionResult AddList(List<GptChatsForCreateDto> gptChats)
        {
            var result = _gptChatsService.AddList(gptChats);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("updatelist")]
        public IActionResult UpdateList(List<GptChatsForCreateDto> gptChats)
        {
            var result = _gptChatsService.UpdateList(gptChats);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

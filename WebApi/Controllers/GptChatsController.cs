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
        private readonly IConfiguration _configuration;

        public GptChatsController(IGptChatsService gptChatsService, IConfiguration configuration)
        {
            _gptChatsService = gptChatsService;
            _configuration = configuration;
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

        [HttpGet("getbyresponseid")]
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
        public async Task<IActionResult> AddByUser(GptChatsForCreateDto gptChat)
        {
            var result =
                await _gptChatsService.AddByUser(gptChat, _configuration.GetConnectionString("GptApiKeyString"));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("addlist")]
        public async Task<IActionResult> AddList(List<GptChatsForCreateDto> gptChats)
        {
            var result = await _gptChatsService.AddList(gptChats, _configuration.GetConnectionString("GptApiKeyString"));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(GptChatsForUpdateDto gptChat)
        {
            var result = _gptChatsService.Update(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("updatelist")]
        public IActionResult UpdateList(List<GptChatsForUpdateDto> gptChats)
        {
            var result = _gptChatsService.UpdateList(gptChats);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(GptChatsForUpdateDto gptChat)
        {
            var result = _gptChatsService.Delete(gptChat);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("deletelist")]
        public IActionResult DeleteList(List<GptChatsForUpdateDto> gptChats)
        {
            var result = _gptChatsService.DeleteList(gptChats);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

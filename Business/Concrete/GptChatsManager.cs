using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.Dtos.GptChats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Business.Concrete
{
    public class GptChatsManager : IGptChatsService
    {
        private readonly IGptChatsDal _gptChatsDal;
        private readonly IPostService _postService;

        public GptChatsManager(IGptChatsDal gptChatsDal, IPostService postService)
        {
            _gptChatsDal = gptChatsDal;
            _postService = postService;
        }

        public IDataResult<List<GptChats>> GetAll()
        {
            return new SuccessDataResult<List<GptChats>>(_gptChatsDal.GetAll(), Messages.GptChatsListed);
        }

        public IDataResult<GptChats> GetById(int gptChatsId)
        {
            return new SuccessDataResult<GptChats>(_gptChatsDal.Get(g => g.Id == gptChatsId));
        }

        public IDataResult<List<GptChats>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<GptChats>>(_gptChatsDal.GetAll(g => g.UserId == userId));
        }

        public IDataResult<List<GptChats>> GetByPostId(int postId)
        {
            return new SuccessDataResult<List<GptChats>>(_gptChatsDal.GetAll(g => g.PostId == postId));
        }

        public IDataResult<List<GptChats>> GetByResponseId(string responseId)
        {
            return new SuccessDataResult<List<GptChats>>(_gptChatsDal.GetAll(g => g.ResponseId == responseId));
        }


        public async Task<IResult> AddByUser(GptChatsForCreateDto gptChats, string apiKey)
        {

            var postDetails = _postService.GetPostDetailsByPostId(gptChats.PostId).Data;
            if (postDetails == null)
            {
                return new ErrorResult(Messages.PostNotFound);
            }

            var oldChats = GetByPostId(gptChats.PostId).Data;

            string prompt = gptChats.Message != "string" ? gptChats.Message :
                $"Act as a chatbot. You are a chatbot designed to help humans in emergency. Current emergency reported is {postDetails.Title}." +
                $"Note that user's height is {postDetails.Height}, gender is {postDetails.Gender}, blood type is {postDetails.BloodType}. " +
                $"User is allergic to {postDetails.Allergies}, and has {postDetails.Diseases} and is {postDetails.Age} years old." +
                " Suggest possible actions. Start first message with \"Hi, I'm ResQ Helpbot!\". " +
                " And keep your messages short and accurate as user is probably in a dangerous condition and in a hurry.";

            var model = "gpt-3.5-turbo";
            var maxTokens = 150;

            var messages = new List<object>();

            messages.Add(new
            {
                role = "user",
                content = prompt,
            });

            foreach (var oldChat in oldChats)
            {
                messages.Add(new
                {
                    role = "user",
                    content = oldChat.Message,
                });
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                var requestBody = new
                {
                    messages = messages,
                    model = model,
                    max_tokens = maxTokens,
                    temperature = 0.7,
                };

                var requestContent = JsonConvert.SerializeObject(requestBody);
                var request = await client.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(requestContent, Encoding.UTF8, "application/json"));
                var responseContent = await request.Content.ReadAsStringAsync();
                dynamic response = JObject.Parse(responseContent);

                var gptChatByUser = new GptChats
                {
                    Message = gptChats.Message != "string" ? gptChats.Message : null,
                    Model = response.model.ToString(),
                    ResponseId = response.id.ToString(),
                    Status = true,
                    Usage = response.usage.ToString(),
                    UserId = gptChats.UserId,
                    PostId = gptChats.PostId,
                    SentBy = "User"
                };
                if (gptChatByUser.Message != null)
                    _gptChatsDal.Add(gptChatByUser);

                var result = new GptChats
                {
                    Message = response.choices[0].message.content,
                    Model = response.model.ToString(),
                    ResponseId = response.id.ToString(),
                    Status = true,
                    Usage = response.usage.ToString(),
                    UserId = gptChats.UserId,
                    PostId = gptChats.PostId,
                    SentBy = "Gpt"
                };
                _gptChatsDal.Add(result);


                return new SuccessResult(Messages.GptChatsAdded);
            }


        }

        public IResult Update(GptChatsForUpdateDto gptChat)
        {
            var result = CheckIfGptChatsExists(gptChat.Id, gptChat.UserId, gptChat.ResponseId);

            if (result == null)
            {
                return new ErrorResult(Messages.GptChatsNotFound);
            }

            result.UserId = gptChat.UserId;
            result.PostId = gptChat.PostId;
            result.ResponseId = gptChat.ResponseId;
            result.Model = gptChat.Model;
            result.Usage = gptChat.Usage;
            result.Message = gptChat.Message;
            result.Status = gptChat.Status;

            _gptChatsDal.Update(result);
            return new SuccessResult(Messages.GptChatsUpdated);
        }

        public async Task<IResult> AddList(List<GptChatsForCreateDto> gptChats, string apiKey)
        {
            foreach (var gptChat in gptChats)
            {
                var chatToCheck = CheckIfGptChatsExists(null, gptChat.UserId, gptChat.ResponseId);
                if (chatToCheck != null)
                {
                    return new ErrorResult(Messages.GptChatsExists);
                }

                var result = new GptChatsForCreateDto
                {
                    UserId = gptChat.UserId,
                    PostId = gptChat.PostId,
                    SentBy = "User"
                };


                await AddByUser(result, apiKey);
            }
            return new SuccessResult(Messages.GptChatsAdded);
        }

        public IResult UpdateList(List<GptChatsForUpdateDto> gptChats)
        {
            foreach (var gptChat in gptChats)
            {
                var result = CheckIfGptChatsExists(gptChat.Id, gptChat.UserId, gptChat.ResponseId);
                if (result == null)
                {
                    return new ErrorResult(Messages.GptChatsNotFound);
                }

                result.UserId = gptChat.UserId;
                result.PostId = gptChat.PostId;
                result.ResponseId = gptChat.ResponseId;
                result.Model = gptChat.Model;
                result.Usage = gptChat.Usage;
                result.Message = gptChat.Message;
                result.Status = gptChat.Status;

                _gptChatsDal.Update(result);
            }
            return new SuccessResult(Messages.GptChatsUpdated);
        }

        public IResult Delete(GptChatsForUpdateDto gptChat)
        {
            var result = CheckIfGptChatsExists(gptChat.Id, gptChat.UserId, gptChat.ResponseId);

            if (result == null)
            {
                return new ErrorResult(Messages.GptChatsNotFound);
            }

            _gptChatsDal.Delete(result);
            return new SuccessResult(Messages.GptChatsDeleted);
        }

        public IResult DeleteList(List<GptChatsForUpdateDto> gptChats)
        {
            foreach (var gptChat in gptChats)
            {
                var result = CheckIfGptChatsExists(gptChat.Id, gptChat.UserId, gptChat.ResponseId);
                if (result == null)
                {
                    return new ErrorResult(Messages.GptChatsNotFound);
                }

                result.UserId = gptChat.UserId;
                result.PostId = gptChat.PostId;
                result.ResponseId = gptChat.ResponseId;
                result.Model = gptChat.Model;
                result.Usage = gptChat.Usage;
                result.Message = gptChat.Message;
                result.Status = gptChat.Status;

                _gptChatsDal.Delete(result);
            }
            return new SuccessResult(Messages.GptChatsDeleted);
        }

        private GptChats CheckIfGptChatsExists(int? id, int? userId, string responseId)
        {
            var result = _gptChatsDal.Get(g => g.Id == id || g.UserId == userId || g.ResponseId == responseId);
            return result;
        }
    }
}

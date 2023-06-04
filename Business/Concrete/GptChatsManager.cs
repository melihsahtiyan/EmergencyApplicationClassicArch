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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GptChatsManager : IGptChatsService
    {
        IGptChatsDal _gptChatsDal;

        public GptChatsManager(IGptChatsDal gptChatsDal)
        {
            _gptChatsDal = gptChatsDal;
        }

        public IDataResult<List<GptChats>> GetAll()
        {
            return new SuccessDataResult<List<GptChats>>(_gptChatsDal.GetAll(), Messages.GptChatsListed);
        }

        public IDataResult<GptChats> GetById(int gptChatsId)
        {
            return new SuccessDataResult<GptChats>(_gptChatsDal.Get(g => g.Id == gptChatsId));
        }

        public IDataResult<GptChats> GetByUserId(int userId)
        {
            return new SuccessDataResult<GptChats>(_gptChatsDal.Get(g => g.UserId == userId));
        }

        public IDataResult<GptChats> GetByPostId(int postId)
        {
            return new SuccessDataResult<GptChats>(_gptChatsDal.Get(g => g.PostId == postId));
        }

        public IDataResult<GptChats> GetByResponseId(string responseId)
        {
            return new SuccessDataResult<GptChats>(_gptChatsDal.Get(g => g.ResponseId == responseId));
        }

        public IResult Add(GptChatsForCreateDto gptChat)
        {

            var result = CheckIfGptChatsExists(null, gptChat.UserId, gptChat.ResponseId);
            if (result != null)
            {
                return new ErrorResult(Messages.GptChatsExists);
            }
            result = new GptChats()
            {
                UserId = gptChat.UserId,
                PostId = gptChat.PostId,
                ResponseId = gptChat.ResponseId,
                Model = gptChat.Model,
                Usage = gptChat.Usage,
                Message = gptChat.Message,
                Status = gptChat.Status,
                User = gptChat.User
            };
            _gptChatsDal.Add(result);
            return new SuccessResult(Messages.GptChatsAdded);
        }

        public IResult Update(GptChatsForCreateDto gptChat)
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
            result.User = gptChat.User;

            _gptChatsDal.Update(result);
            return new SuccessResult(Messages.GptChatsUpdated);
        }

        public IResult Delete(GptChatsForCreateDto gptChat)
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
            result.User = gptChat.User;

            _gptChatsDal.Delete(result);
            return new SuccessResult(Messages.GptChatsDeleted);
        }

        public IResult AddList(List<GptChatsForCreateDto> gptChats)
        {
            foreach (var gptChat in gptChats)
            {
                var result = CheckIfGptChatsExists(gptChat.Id, gptChat.UserId, gptChat.ResponseId);
                if (result != null)
                {
                    return new ErrorResult(Messages.GptChatsExists);
                }

                result = new GptChats()
                {
                    UserId = gptChat.UserId,
                    PostId = gptChat.PostId,
                    ResponseId = gptChat.ResponseId,
                    Model = gptChat.Model,
                    Usage = gptChat.Usage,
                    Message = gptChat.Message,
                    Status = gptChat.Status,
                    User = gptChat.User
                };
                _gptChatsDal.Add(result);
            }
            return new SuccessResult(Messages.GptChatsAdded);
        }

        public IResult UpdateList(List<GptChatsForCreateDto> gptChats)
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
                result.User = gptChat.User;

                _gptChatsDal.Update(result);
            }
            return new SuccessResult(Messages.GptChatsUpdated);
        }

        public IResult DeleteList(List<GptChatsForCreateDto> gptChats)
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
                result.User = gptChat.User;

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

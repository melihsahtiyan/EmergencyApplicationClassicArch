using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.GptChats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGptChatsService
    {
        IDataResult<List<GptChats>> GetAll();
        IDataResult<GptChats> GetById(int id);
        IDataResult<GptChats> GetByUserId(int userId);
        IDataResult<GptChats> GetByPostId(int postId);
        IDataResult<GptChats> GetByResponseId(string responseId);
        Task<IResult> AddByUser(GptChatsForCreateDto gptChats, string apiKey);
        Task<IResult> AddList(List<GptChatsForCreateDto> gptChats, string apiKey);
        IResult Update(GptChatsForUpdateDto gptChats);
        IResult UpdateList(List<GptChatsForUpdateDto> gptChats);
        IResult Delete(GptChatsForUpdateDto gptChats);
        IResult DeleteList(List<GptChatsForUpdateDto> gptChats);
    }
}

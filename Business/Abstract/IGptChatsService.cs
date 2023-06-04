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
        IResult Add(GptChatsForCreateDto gptChats);
        IResult Update(GptChatsForCreateDto gptChats);
        IResult Delete(GptChatsForCreateDto gptChats);
        IResult DeleteList(List<GptChatsForCreateDto> gptChats);
        IResult AddList(List<GptChatsForCreateDto> gptChats);
        IResult UpdateList(List<GptChatsForCreateDto> gptChats);
    }
}

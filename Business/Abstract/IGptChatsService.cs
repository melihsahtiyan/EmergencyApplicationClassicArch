using Core.Utilities.Results;
using Entity.Concrete;
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
        IDataResult<List<GptChats>> GetByUserId(int userId);
        IDataResult<List<GptChats>> GetByPostId(int postId);
        IDataResult<List<GptChats>> GetByResponseId(string responseId);
        IResult Add(GptChats gptChats);
        IResult Update(GptChats gptChats);
        IResult Delete(GptChats gptChats);
    }
}

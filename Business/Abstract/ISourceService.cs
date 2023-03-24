using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISourceService
    {
        IDataResult<List<Source>> GetAll();
        IDataResult<List<Source>> GetAllByPostId(int postId);
        IDataResult<Source> GetById(int sourceId);
        //IDataResult<List<Source>> GetSourcesByUser(int userId);
        IResult Add(SourceForCreateDto sourceForCreateDto);
        IResult Update(SourceForCreateDto sourceForCreateDto);
        IResult Delete(SourceForCreateDto sourceForCreateDto);
    }
}

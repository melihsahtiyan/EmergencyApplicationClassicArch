using Core.Utilities.Results;
using Entity.Concrete;
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
        IDataResult<Source> GetById(int sourceId);
        IResult Add(Source source);
        IResult Update(Source source);
        IResult Delete(Source source);
    }
}

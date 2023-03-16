using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostTemplatesService
    {
        IDataResult<List<PostTemplates>> GetAll();
        IDataResult<PostTemplates> GetById(int postTemplatesId);
        IResult Add(PostTemplates postTemplates);
        IResult Update(PostTemplates postTemplates);
        IResult Delete(PostTemplates postTemplates);
    }
}

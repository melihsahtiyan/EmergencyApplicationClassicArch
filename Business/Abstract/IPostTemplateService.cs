using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostTemplateService
    {
        IDataResult<List<PostTemplate>> GetAll();
        IDataResult<PostTemplate> GetById(int postTemplatesId);
        IResult Add(PostTemplate postTemplate);
        IResult AddList(List<PostTemplate> postTemplates);
        IResult Update(PostTemplate postTemplate);
        IResult Delete(PostTemplate postTemplate);
        IResult DeleteList(List<PostTemplate> postTemplates);
    }
}

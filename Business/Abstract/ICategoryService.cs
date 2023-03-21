using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
        IResult Add(CategoryForCreateDto category);
        IResult Update(CategoryForCreateDto category);
        IResult Delete(CategoryForCreateDto category);
    }
}

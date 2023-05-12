using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(CategoryForCreateDto category)
        {
            var result = CheckIfCategoryExists(null, category.CategoryName);

            if (result != null)
            {
                return new ErrorResult(Messages.CategoryExists);
            }

            result.CategoryName = category.CategoryName;

            _categoryDal.Add(result);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(CategoryForCreateDto category)
        {
            var result = CheckIfCategoryExists(category.Id, category.CategoryName);

            if (result == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            result.CategoryName = category.CategoryName;

            _categoryDal.Delete(result);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId));
        }

        public IResult Update(CategoryForCreateDto category)
        {
            var result = CheckIfCategoryExists(category.Id, category.CategoryName);
            if (result == null)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            result.CategoryName = category.CategoryName;

            _categoryDal.Update(result);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        private Category CheckIfCategoryExists(int? id, string categoryName)
        {
            var result = _categoryDal.Get(c => c.Id == id || c.CategoryName == categoryName);
            return result;
        }
    }
}

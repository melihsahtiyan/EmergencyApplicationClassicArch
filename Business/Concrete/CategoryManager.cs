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
            var check = CheckIfCategoryExists(category.Id, category.CategoryName);

            if (check)
            {
                return new ErrorResult(Messages.CategoryExists);
            }

            var result = new Category() 
            {
                CategoryName = category.CategoryName 
            };

            _categoryDal.Add(result);
            return new SuccessResult(Messages.CategoryAdded);
        }

        public IResult Delete(CategoryForCreateDto category)
        {
            var check = CheckIfCategoryExists(category.Id, category.CategoryName);

            if (!check)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            var result = new Category()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

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
            var check = CheckIfCategoryExists(category.Id, category.CategoryName);
            if (!check)
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }

            var result = new Category()
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            _categoryDal.Update(result);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        private bool CheckIfCategoryExists(int id, string categoryName)
        {
            var result = _categoryDal.GetAll(c => c.Id == id || c.CategoryName == categoryName).Any();
            return result;
        }
    }
}

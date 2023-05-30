using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class PostTemplateManager : IPostTemplateService
    {
        private readonly IPostTemplateDal _postTemplateDal;

        public PostTemplateManager(IPostTemplateDal postTemplateDal)
        {
            _postTemplateDal = postTemplateDal;
        }
        public IDataResult<List<PostTemplate>> GetAll()
        {
            var result = _postTemplateDal.GetAll();
            return new SuccessDataResult<List<PostTemplate>>(result, Messages.PostTemplatesListed);
        }

        public IDataResult<PostTemplate> GetById(int postTemplatesId)
        {
            var result = _postTemplateDal.Get(p => p.Id == postTemplatesId);
            if (result == null)
            {
                return new ErrorDataResult<PostTemplate>(Messages.PostTemplateNotFound);
            }
            return new SuccessDataResult<PostTemplate>(result, Messages.PostTemplateListed);
        }

        public IResult Add(PostTemplate postTemplate)
        {
            var result = CheckIfPostTemplateExists(postTemplate.Title);
            if (result != null)
            {
                return new ErrorResult(Messages.PostTemplateExists);
            }

            _postTemplateDal.Add(postTemplate);
            return new SuccessResult(Messages.PostTemplateAdded);
        }

        public IResult AddList(List<PostTemplate> postTemplates)
        {
            foreach (var postTemplate in postTemplates)
            {
                var result = CheckIfPostTemplateExists(postTemplate.Title);
                if (result != null)
                {
                    return new ErrorResult(Messages.PostTemplateExists);
                }
            }
            return new SuccessResult(Messages.PostTemplateAdded);
        }

        public IResult Update(PostTemplate postTemplate)
        {
            var result = CheckIfPostTemplateExists(postTemplate.Title);
            if (result != null)
            {
                return new ErrorResult(Messages.PostTemplateExists);
            }

            _postTemplateDal.Update(postTemplate);
            return new SuccessResult(Messages.PostTemplateUpdated);
        }

        public IResult Delete(PostTemplate postTemplate)
        {
            var result = CheckIfPostTemplateExists(postTemplate.Title);
            if (result == null)
            {
                return new ErrorResult(Messages.PostTemplateNotFound);
            }

            _postTemplateDal.Delete(postTemplate);
            return new SuccessResult(Messages.PostTemplateDeleted);
        }

        public IResult DeleteList(List<PostTemplate> postTemplates)
        {
            foreach (var postTemplate in postTemplates)
            {
                var result = CheckIfPostTemplateExists(postTemplate.Title);
                if (result == null)
                {
                    return new ErrorResult(Messages.PostTemplateNotFound);
                }
            }
            return new SuccessResult(Messages.PostTemplateDeleted);
        }

        private PostTemplate CheckIfPostTemplateExists(string title)
        {
            return _postTemplateDal.Get(p => p.Title == title);
        }
    }
}

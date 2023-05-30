using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Business.Concrete
{
    public class SourceManager : ISourceService
    {
        private readonly ISourceDal _sourceDal;

        public SourceManager(ISourceDal sourceDal)
        {
            _sourceDal = sourceDal;
        }

        public IResult Add(SourceForCreateDto sourceForCreateDto, IFormFile file)
        {

            var sourcePath = FormFileHelper.Add(file);
            if (sourcePath == null)
            {
                return new ErrorResult("File could not be added!");
            }
            var result = new Source()
            {
                Date = sourceForCreateDto.Date,
                PostId = sourceForCreateDto.PostId,
                SourceCategory = sourceForCreateDto.SourceCategory,
                SourcePath = sourceForCreateDto.SourcePath
            };
            _sourceDal.Add(result);
            return new SuccessResult();
        }

        public IResult AddRange(SourceForCreateDto sourceForCreateDto, IFormFileCollection files)
        {
            foreach (var file in files)
            {
                var sourcePath = FormFileHelper.Add(file);
                if (sourcePath == null)
                {
                    return new ErrorResult("File could not be added!");
                }
                var result = new Source()
                {
                    Date = sourceForCreateDto.Date,
                    PostId = sourceForCreateDto.PostId,
                    SourceCategory = sourceForCreateDto.SourceCategory,
                    SourcePath = sourceForCreateDto.SourcePath
                };
                _sourceDal.Add(result);
            }

            return new SuccessResult(Messages.SourceAdded);
        }

        public IResult Delete(SourceForCreateDto sourceForCreateDto)
        {
            var result = CheckIfSourceExists(sourceForCreateDto.Id);

            if (result == null)
            {
                return new ErrorResult("Source could not be found!");
            }

            _sourceDal.Delete(result);
            return new SuccessResult();
        }

        public IResult DeleteRange(List<SourceForCreateDto> sourceForCreateDtos)
        {
            foreach (var source in sourceForCreateDtos)
            {
                var result = CheckIfSourceExists(source.Id);

                if (result == null)
                {
                    return new ErrorResult("Source could not be found!");
                }

                _sourceDal.Delete(result);
            }

            return new SuccessResult();
        }

        public IDataResult<List<Source>> GetAll()
        {
            _sourceDal.GetAll();
            return new SuccessDataResult<List<Source>>();
        }

        public IDataResult<List<Source>> GetAllByPostId(int postId)
        {
            _sourceDal.Get(p => p.PostId == postId);
            return new SuccessDataResult<List<Source>>();
        }

        public IDataResult<Source> GetById(int sourceId)
        {
            _sourceDal.Get(p => p.Id == sourceId);
            return new SuccessDataResult<Source>();

        }

        //public IDataResult<List<Source>> GetSourcesByUser(int userId)
        //{
        //    _sourceDal.Get(s=>s.)
        //}

        public IResult Update(SourceForCreateDto sourceForCreateDto)
        {
            var result = CheckIfSourceExists(sourceForCreateDto.Id);

            if (result == null)
            {
                return new ErrorResult("Source could not be found!");
            }

            result.Date = sourceForCreateDto.Date;
            result.PostId = sourceForCreateDto.PostId;
            result.SourceCategory = sourceForCreateDto.SourceCategory;
            result.SourcePath = sourceForCreateDto.SourcePath;
            result.Id = sourceForCreateDto.Id;

            _sourceDal.Update(result);
            return new SuccessResult();
        }

        private Source CheckIfSourceExists(int sourceId)
        {
            return _sourceDal.Get(s => s.Id == sourceId);
        }
    }
}

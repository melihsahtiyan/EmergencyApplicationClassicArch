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

namespace Business.Concrete
{
    public class SourceManager : ISourceService
    {
        private readonly ISourceDal _sourceDal;

        public SourceManager(ISourceDal sourceDal)
        {
            _sourceDal = sourceDal;
        }

        public IResult Add(SourceForCreateDto sourceForCreateDto)
        {
            var result = new Source() { 
                Date = sourceForCreateDto.Date,
                PostId = sourceForCreateDto.PostId,
                SourceCategory = sourceForCreateDto.SourceCategory,
                SourcePath = sourceForCreateDto.SourcePath  
            };
            _sourceDal.Add(result);
            return new SuccessResult();
        }

        public IResult Delete(SourceForCreateDto sourceForCreateDto)
        {
            var result = new Source()
            {
                Date = sourceForCreateDto.Date,
                PostId = sourceForCreateDto.PostId,
                SourceCategory = sourceForCreateDto.SourceCategory,
                SourcePath = sourceForCreateDto.SourcePath,
                Id = sourceForCreateDto.Id
            };
            _sourceDal.Delete(result);  
            return new SuccessResult();
        }

        public IDataResult<List<Source>> GetAll()
        {
            _sourceDal.GetAll();
            return new SuccessDataResult<List<Source>>();
        }

        public IDataResult<List<Source>> GetAllByPostId(int postId)
        {
            _sourceDal.Get(p=>p.PostId== postId);
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
            var result = new Source()
            {
                Date = sourceForCreateDto.Date,
                PostId = sourceForCreateDto.PostId,
                SourceCategory = sourceForCreateDto.SourceCategory,
                SourcePath = sourceForCreateDto.SourcePath,
                Id = sourceForCreateDto.Id
            };
            _sourceDal.Update(result);
            return new SuccessResult();     
        }
    }
}

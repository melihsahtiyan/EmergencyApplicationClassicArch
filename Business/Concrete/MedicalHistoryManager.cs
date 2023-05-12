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
using Entity.Dtos.MedicalHistory;

namespace Business.Concrete
{
    public class MedicalHistoryManager : IMedicalHistoryService
    {
        private readonly IMedicalHistoryDal _medicalHistoryDal;

        public MedicalHistoryManager(IMedicalHistoryDal medicalHistoryDal)
        {
            _medicalHistoryDal = medicalHistoryDal;
        }

        public IDataResult<List<MedicalHistory>> GetAll()
        {
            return new SuccessDataResult<List<MedicalHistory>>(_medicalHistoryDal.GetAll(), Messages.MedicalHistoriesListed);
        }

        public IDataResult<MedicalHistory> GetById(int medicalHistoryId)
        {
            var result = _medicalHistoryDal.Get(m => m.Id == medicalHistoryId);
            if (result == null)
            {
                return new ErrorDataResult<MedicalHistory>(Messages.MedicalHistoryNotFound);
            }
            return new SuccessDataResult<MedicalHistory>(result, Messages.MedicalHistoryListed);
        }

        public IResult Add(MedicalHistoryForCreateDto medicalHistory)
        {
            var result = CheckIfMedicalHistoryExists(medicalHistory.Name);

            if (result != null)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            result.Name = medicalHistory.Name;
            result.Description = medicalHistory.Description;

            _medicalHistoryDal.Add(result);
            return new SuccessResult(Messages.MedicalHistoryAdded);
        }

        public IResult Update(MedicalHistoryForCreateDto medicalHistory)
        {
            var result = CheckIfMedicalHistoryExists(medicalHistory.Id);

            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            var checkName = CheckIfMedicalHistoryExists(medicalHistory.Name);

            if (result != null)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            result.Name = medicalHistory.Name;
            result.Description = medicalHistory.Description;

            _medicalHistoryDal.Update(result);
            return new SuccessResult(Messages.MedicalHistoryUpdated);
        }

        public IResult Delete(MedicalHistoryForCreateDto medicalHistory)
        {
            var result = CheckIfMedicalHistoryExists(medicalHistory.Id);

            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            result.Name = medicalHistory.Name;
            result.Description = medicalHistory.Description;

            _medicalHistoryDal.Delete(result);
            return new SuccessResult(Messages.MedicalHistoryDeleted);
        }

        public MedicalHistory CheckIfMedicalHistoryExists(string name)
        {
            var result = _medicalHistoryDal.Get(m => m.Name == name);
            
            return result;
        }
        
        public MedicalHistory CheckIfMedicalHistoryExists(int id)
        {
            var result = _medicalHistoryDal.Get(m => m.Id == id);
            
            return result;
        }
    }
}

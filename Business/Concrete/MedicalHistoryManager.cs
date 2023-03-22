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
            var check = CheckIfMedicalHistoryByName(medicalHistory.Name);

            if (check)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            var result = new MedicalHistory()
            {
                Name = medicalHistory.Name,
                Description = medicalHistory.Description
            };

            _medicalHistoryDal.Add(result);
            return new SuccessResult(Messages.MedicalHistoryAdded);
        }

        public IResult Update(MedicalHistoryForCreateDto medicalHistory)
        {
            var check = CheckIfMedicalHistoryById(medicalHistory.Id);

            if (!check)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            var checkName = CheckIfMedicalHistoryByName(medicalHistory.Name);

            if (!checkName)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            var result = new MedicalHistory()
            {
                Id = medicalHistory.Id,
                Name = medicalHistory.Name,
                Description = medicalHistory.Description
            };

            _medicalHistoryDal.Update(result);
            return new SuccessResult(Messages.MedicalHistoryUpdated);
        }

        public IResult Delete(MedicalHistoryForCreateDto medicalHistory)
        {
            var check = CheckIfMedicalHistoryById(medicalHistory.Id);

            if (!check)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            var result = new MedicalHistory()
            {
                Id = medicalHistory.Id,
                Name = medicalHistory.Name,
                Description = medicalHistory.Description
            };

            _medicalHistoryDal.Delete(result);
            return new SuccessResult(Messages.MedicalHistoryDeleted);
        }

        public bool CheckIfMedicalHistoryByName(string name)
        {
            var result = _medicalHistoryDal.Get(m => m.Name == name);

            if (result != null)
            {
                return false;
            }
            return true;
        }
        
        public bool CheckIfMedicalHistoryById(int id)
        {
            var result = _medicalHistoryDal.Get(m => m.Id == id);

            if (result != null)
            {
                return false;
            }
            return true;
        }
    }
}

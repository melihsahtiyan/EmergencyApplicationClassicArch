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
using Entity.Dtos.OngoingDisease;

namespace Business.Concrete
{
    public class OngoingDiseaseManager : IOngoingDiseaseService
    {
        private readonly IOngoingDiseaseDal _ongoingDiseaseDal;

        public OngoingDiseaseManager(IOngoingDiseaseDal ongoingDiseaseDal)
        {
            _ongoingDiseaseDal = ongoingDiseaseDal;
        }

        public IDataResult<List<OngoingDisease>> GetAll()
        {
            return new SuccessDataResult<List<OngoingDisease>>(_ongoingDiseaseDal.GetAll(), Messages.MedicalHistoriesListed);
        }

        public IDataResult<OngoingDisease> GetById(int medicalHistoryId)
        {
            var result = _ongoingDiseaseDal.Get(m => m.Id == medicalHistoryId);
            if (result == null)
            {
                return new ErrorDataResult<OngoingDisease>(Messages.MedicalHistoryNotFound);
            }
            return new SuccessDataResult<OngoingDisease>(result, Messages.MedicalHistoryListed);
        }

        public IResult Add(OngoingDiseaseForCreateDto ongoingDeseases)
        {
            var result = CheckIfMedicalHistoryExists(ongoingDeseases.Name);

            if (result != null)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            result.Name = ongoingDeseases.Name;
            result.Description = ongoingDeseases.Description;

            _ongoingDiseaseDal.Add(result);
            return new SuccessResult(Messages.MedicalHistoryAdded);
        }

        public IResult Update(OngoingDiseaseForCreateDto ongoingDeseases)
        {
            var result = CheckIfMedicalHistoryExists(ongoingDeseases.Id);

            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            var checkName = CheckIfMedicalHistoryExists(ongoingDeseases.Name);

            if (result != null)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            result.Name = ongoingDeseases.Name;
            result.Description = ongoingDeseases.Description;

            _ongoingDiseaseDal.Update(result);
            return new SuccessResult(Messages.MedicalHistoryUpdated);
        }

        public IResult Delete(OngoingDiseaseForCreateDto ongoingDeseases)
        {
            var result = CheckIfMedicalHistoryExists(ongoingDeseases.Id);

            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            result.Name = ongoingDeseases.Name;
            result.Description = ongoingDeseases.Description;

            _ongoingDiseaseDal.Delete(result);
            return new SuccessResult(Messages.MedicalHistoryDeleted);
        }

        public OngoingDisease CheckIfMedicalHistoryExists(string name)
        {
            var result = _ongoingDiseaseDal.Get(m => m.Name == name);
            
            return result;
        }
        
        public OngoingDisease CheckIfMedicalHistoryExists(int id)
        {
            var result = _ongoingDiseaseDal.Get(m => m.Id == id);
            
            return result;
        }
    }
}

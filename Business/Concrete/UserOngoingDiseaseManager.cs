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
    public class UserOngoingDiseaseManager : IUserOngoingDiseaseService
    {
        private readonly IUserOngoingDiseaseDal _userOngoingDiseaseDal;
        private readonly IUserDal _userDal;
        private readonly IOngoingDiseaseDal _ongoingDiseaseDal;
        public IDataResult<List<UserOngoingDisease>> GetAll()
        {
            return new SuccessDataResult<List<UserOngoingDisease>>(_userOngoingDiseaseDal.GetAll());
        }

        public IDataResult<UserOngoingDisease> GetById(int userMedicalHistoriesId)
        {
            var result = _userOngoingDiseaseDal.Get(m => m.Id == userMedicalHistoriesId);
            if (result == null)
            {
                return new ErrorDataResult<UserOngoingDisease>(Messages.MedicalHistoryNotFound);
            }
            return new SuccessDataResult<UserOngoingDisease>(result, Messages.MedicalHistoryListed);
        }

        public IResult Add(UserOngoingDiseaseForCreateDto userMedicalHistories)
        {
            var result = CheckIfUserMedicalHistoriesExists(userMedicalHistories.UserId, userMedicalHistories.OngoingDiseaseId);
            if (result != null)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            result.UserId = userMedicalHistories.UserId;
            result.OngoingDiseaseId = userMedicalHistories.OngoingDiseaseId;

            _userOngoingDiseaseDal.Add(result);
            return new SuccessResult(Messages.MedicalHistoryAdded);
        }

        public IResult Update(UserOngoingDiseaseForCreateDto userMedicalHistories)
        {
            var result = 
                CheckIfUserMedicalHistoriesExists(userMedicalHistories.UserId, userMedicalHistories.OngoingDiseaseId);
            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            result.UserId = userMedicalHistories.UserId;
            result.OngoingDiseaseId = userMedicalHistories.OngoingDiseaseId;

            _userOngoingDiseaseDal.Update(result);
            return new SuccessResult(Messages.MedicalHistoryUpdated);
        }

        public IResult Delete(UserOngoingDiseaseForCreateDto userMedicalHistories)
        {
            var result =
                CheckIfUserMedicalHistoriesExists(userMedicalHistories.UserId, userMedicalHistories.OngoingDiseaseId);
            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            result.UserId = userMedicalHistories.UserId;
            result.OngoingDiseaseId = userMedicalHistories.OngoingDiseaseId;

            _userOngoingDiseaseDal.Delete(result);
            return new SuccessResult(Messages.MedicalHistoryDeleted);
        }

        public IDataResult<List<UserOngoingDisease>> GetByUserId(int userId)
        {
            var result = _userOngoingDiseaseDal.GetAll(m => m.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<List<UserOngoingDisease>>(Messages.MedicalHistoryNotFound);
            }
            return new SuccessDataResult<List<UserOngoingDisease>>(result, Messages.MedicalHistoryListed);
        }

        private UserOngoingDisease CheckIfUserMedicalHistoriesExists(int userId, int medicalHistoryId)
        {
            var result = _userOngoingDiseaseDal
                .Get(m => m.UserId == userId && m.OngoingDiseaseId == medicalHistoryId);

            return result;
        }
    }
}

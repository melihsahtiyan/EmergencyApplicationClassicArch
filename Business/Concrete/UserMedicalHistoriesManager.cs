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
    public class UserMedicalHistoriesManager : IUserMedicalHistoriesService
    {
        private readonly IUserMedicalHistoryDal _userMedicalHistoryDal;
        private readonly IUserDal _userDal;
        private readonly IMedicalHistoryDal _medicalHistoryDal;
        public IDataResult<List<UserMedicalHistories>> GetAll()
        {
            return new SuccessDataResult<List<UserMedicalHistories>>(_userMedicalHistoryDal.GetAll());
        }

        public IDataResult<UserMedicalHistories> GetById(int userMedicalHistoriesId)
        {
            var result = _userMedicalHistoryDal.Get(m => m.Id == userMedicalHistoriesId);
            if (result == null)
            {
                return new ErrorDataResult<UserMedicalHistories>(Messages.MedicalHistoryNotFound);
            }
            return new SuccessDataResult<UserMedicalHistories>(result, Messages.MedicalHistoryListed);
        }

        public IResult Add(UserMedicalHistoriesForCreateDto userMedicalHistories)
        {
            var result = CheckIfUserMedicalHistoriesExists(userMedicalHistories.UserId, userMedicalHistories.MedicalHistoryId);
            if (result != null)
            {
                return new ErrorResult(Messages.MedicalHistoryExists);
            }

            result.UserId = userMedicalHistories.UserId;
            result.MedicalHistoryId = userMedicalHistories.MedicalHistoryId;

            _userMedicalHistoryDal.Add(result);
            return new SuccessResult(Messages.MedicalHistoryAdded);
        }

        public IResult Update(UserMedicalHistoriesForCreateDto userMedicalHistories)
        {
            var result = 
                CheckIfUserMedicalHistoriesExists(userMedicalHistories.UserId, userMedicalHistories.MedicalHistoryId);
            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            result.UserId = userMedicalHistories.UserId;
            result.MedicalHistoryId = userMedicalHistories.MedicalHistoryId;

            _userMedicalHistoryDal.Update(result);
            return new SuccessResult(Messages.MedicalHistoryUpdated);
        }

        public IResult Delete(UserMedicalHistoriesForCreateDto userMedicalHistories)
        {
            var result =
                CheckIfUserMedicalHistoriesExists(userMedicalHistories.UserId, userMedicalHistories.MedicalHistoryId);
            if (result == null)
            {
                return new ErrorResult(Messages.MedicalHistoryNotFound);
            }

            result.UserId = userMedicalHistories.UserId;
            result.MedicalHistoryId = userMedicalHistories.MedicalHistoryId;

            _userMedicalHistoryDal.Delete(result);
            return new SuccessResult(Messages.MedicalHistoryDeleted);
        }

        public IDataResult<List<UserMedicalHistories>> GetByUserId(int userId)
        {
            var result = _userMedicalHistoryDal.GetAll(m => m.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<List<UserMedicalHistories>>(Messages.MedicalHistoryNotFound);
            }
            return new SuccessDataResult<List<UserMedicalHistories>>(result, Messages.MedicalHistoryListed);
        }

        private UserMedicalHistories CheckIfUserMedicalHistoriesExists(int userId, int medicalHistoryId)
        {
            var result = _userMedicalHistoryDal
                .Get(m => m.UserId == userId && m.MedicalHistoryId == medicalHistoryId);

            return result;
        }
    }
}

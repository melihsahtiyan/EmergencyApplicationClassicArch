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
using Entity.Dtos.Allergy;

namespace Business.Concrete
{
    public class UserAllergiesManager : IUserAllergiesService
    {
        private readonly IUserAllergiesDal _userAllergiesDal;
        private readonly IAllergyDal _allergyDal;
        private readonly IUserDal _userDal;

        public UserAllergiesManager(IUserAllergiesDal userAllergiesDal, IAllergyDal allergyDal, IUserDal userDal)
        {
            _userAllergiesDal = userAllergiesDal;
            _allergyDal = allergyDal;
            _userDal = userDal;
        }

        public IDataResult<List<UserAllergies>> GetAll()
        {
            return new SuccessDataResult<List<UserAllergies>>(_userAllergiesDal.GetAll(), Messages.UserAllergiesListed);
        }

        public IDataResult<UserAllergies> GetById(int userAllergiesId)
        {
            var result = _userAllergiesDal.Get(ua => ua.Id == userAllergiesId);
            if (result == null)
            {
                return new ErrorDataResult<UserAllergies>(Messages.UserAllergiesNotFound);
            }
            return new SuccessDataResult<UserAllergies>(result, Messages.UserAllergiesListed);
        }

        public IResult Add(UserAllergiesForCreateDto userAllergies)
        {
            var result = CheckIfUserAllergiesExists(userAllergies.UserId, userAllergies.AllergyId);
            if (result != null)
            {
                return new ErrorResult(Messages.UserAllergiesExists);
            }

            result = new UserAllergies()
            {
                UserId = userAllergies.UserId, 
                AllergyId = userAllergies.AllergyId
            };

            _userAllergiesDal.Add(result);
            return new SuccessResult(Messages.UserAllergiesAdded);
        }

        public IResult Update(UserAllergiesForCreateDto userAllergies)
        {
            var result = CheckIfUserAllergiesExists(userAllergies.UserId, userAllergies.AllergyId);
            if (result == null)
            {
                return new ErrorResult(Messages.UserAllergiesNotFound);
            }

            result.UserId = userAllergies.UserId;
            result.AllergyId = userAllergies.AllergyId;

            _userAllergiesDal.Update(result);
            return new SuccessResult(Messages.UserAllergiesUpdated);
        }

        public IResult Delete(UserAllergiesForCreateDto userAllergies)
        {
            var result = CheckIfUserAllergiesExists(userAllergies.UserId, userAllergies.AllergyId);
            if (result == null)
            {
                return new ErrorResult(Messages.UserAllergiesNotFound);
            }
            

            _userAllergiesDal.Delete(result);
            return new SuccessResult(Messages.UserAllergiesDeleted);
        }

        public IDataResult<List<UserAllergies>> GetUserAllergiesByUserId(int userId)
        {
            var result = _userAllergiesDal.GetAll(ua => ua.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<List<UserAllergies>>(Messages.UserAllergiesNotFound);
            }
            return new SuccessDataResult<List<UserAllergies>>(result, Messages.UserAllergiesListed);
        }

        private UserAllergies CheckIfUserAllergiesExists(int userId, int allergyId)
        {
            var result = _userAllergiesDal.Get(ua => ua.UserId == userId && ua.AllergyId == allergyId);
            return result;
        }
    }
}

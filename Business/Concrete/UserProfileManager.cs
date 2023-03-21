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
    public class UserProfileManager : IUserProfileService
    {
        private readonly IUserProfileDal _userProfileDal;

        public UserProfileManager(IUserProfileDal userProfileDal)
        {
            _userProfileDal = userProfileDal;
        }

        public IDataResult<List<UserProfile>> GetAll()
        {
            return new SuccessDataResult<List<UserProfile>>(_userProfileDal.GetAll());
        }

        public IDataResult<UserProfile> GetById(int userProfileId)
        {
            var result = _userProfileDal.Get(u => u.Id == userProfileId);
            if (result == null)
            {
                return new ErrorDataResult<UserProfile>(Messages.UserProfileNotFound);
            }
            return new SuccessDataResult<UserProfile>(result, Messages.UserProfilesListed);
        }

        public IResult Add(UserProfile userProfile)
        {
            var check = CheckIfUserProfileByName(userProfile.UserId);
            if (check)
            {
                return new ErrorResult(Messages.UserProfileExists);
            }
            _userProfileDal.Add(userProfile);
            return new SuccessResult(Messages.UserProfileAdded);
        }

        public IResult Update(UserProfile userProfile)
        {
            var check = CheckIfUserProfileByName(userProfile.UserId);
            if (!check)
            {
                return new ErrorResult(Messages.UserProfileNotFound);
            }
            _userProfileDal.Update(userProfile);
            return new SuccessResult(Messages.UserProfileUpdated);
        }

        public IResult Delete(UserProfile userProfile)
        {
            var check = CheckIfUserProfileByName(userProfile.UserId);
            if (!check)
            {
                return new ErrorResult(Messages.UserProfileNotFound);
            }
            _userProfileDal.Delete(userProfile);
            return new SuccessResult(Messages.UserProfileDeleted);
        }

        private bool CheckIfUserProfileByName(int userId)
        {
            var result = _userProfileDal.Get(u => u.UserId == userId);
            if (result == null)
            {
                return true;
            }
            return false;
        }
    }
}

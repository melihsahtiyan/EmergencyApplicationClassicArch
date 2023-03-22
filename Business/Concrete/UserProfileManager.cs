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
using Entity.Dtos.UserProfile;

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

        public IResult Add(UserProfileForCreateDto userProfile)
        {
            var check = CheckIfUserProfileByName(userProfile.UserId);
            if (check)
            {
                return new ErrorResult(Messages.UserProfileExists);
            }

            var result = new UserProfile()
            {
                Address = userProfile.Address,
                BloodType = userProfile.BloodType,
                Height = userProfile.Height,
                Weight = userProfile.Weight,
                UserId = userProfile.UserId,
                PhoneNumber = userProfile.PhoneNumber,
                ProfilePicture = userProfile.ProfilePicture
            };

            _userProfileDal.Add(result);
            return new SuccessResult(Messages.UserProfileAdded);
        }

        public IResult Update(UserProfileForCreateDto userProfile)
        {
            var check = CheckIfUserProfileByName(userProfile.UserId);
            if (!check)
            {
                return new ErrorResult(Messages.UserProfileNotFound);
            }

            var result = new UserProfile()
            {
                Id = userProfile.Id,
                Address = userProfile.Address,
                BloodType = userProfile.BloodType,
                Height = userProfile.Height,
                Weight = userProfile.Weight,
                UserId = userProfile.UserId,
                PhoneNumber = userProfile.PhoneNumber,
                ProfilePicture = userProfile.ProfilePicture
            };

            _userProfileDal.Update(result);
            return new SuccessResult(Messages.UserProfileUpdated);
        }

        public IResult Delete(UserProfileForCreateDto userProfile)
        {
            var check = CheckIfUserProfileByName(userProfile.UserId);
            if (!check)
            {
                return new ErrorResult(Messages.UserProfileNotFound);
            }

            var result = new UserProfile()
            {
                Id = userProfile.Id,
                Address = userProfile.Address,
                BloodType = userProfile.BloodType,
                Height = userProfile.Height,
                Weight = userProfile.Weight,
                UserId = userProfile.UserId,
                PhoneNumber = userProfile.PhoneNumber,
                ProfilePicture = userProfile.ProfilePicture
            };

            _userProfileDal.Delete(result);
            return new SuccessResult(Messages.UserProfileDeleted);
        }

        private bool CheckIfUserProfileByName(int userId)
        {
            var result = _userProfileDal.GetAll(u => u.UserId == userId).Any();
            return result;
        }
    }
}

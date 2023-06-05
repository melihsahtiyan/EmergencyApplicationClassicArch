using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos.UserProfile;
using Microsoft.AspNetCore.Http;

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

        public IResult Add(UserProfileForCreateDto userProfile/*, IFormFile image*/)
        {
            var result = CheckIfUserProfileExists(userProfile.UserId);
            if (result != null)
            {
                return new ErrorResult(Messages.UserProfileExists);
            }

            //var profilePicturePath = FormFileHelper.Add(image);
            result = new UserProfile()
            {
                Address = userProfile.Address,
                BloodType = userProfile.BloodType,
                Height = userProfile.Height,
                Weight = userProfile.Weight,
                PhoneNumber = userProfile.PhoneNumber,
                ProfilePicture = "" /*profilePicturePath*/,
                Gender = userProfile.Gender,
                UserId = userProfile.UserId
            };

            _userProfileDal.Add(result);
            return new SuccessResult(Messages.UserProfileAdded);
        }

        public IResult AddList(List<UserProfileForCreateDto> userProfiles)
        {
            foreach (var userProfile in userProfiles)
            {
                Add(userProfile);
            }
            return new SuccessResult(Messages.UserProfileAdded);
        }

        public IResult Update(UserProfileForCreateDto userProfile, IFormFile image)
        {
            var result = CheckIfUserProfileExists(userProfile.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.UserProfileNotFound);
            }

            var profilePicture = FormFileHelper.Update(image, result.ProfilePicture);
            
            result.Address = userProfile.Address;
            result.BloodType = userProfile.BloodType;
            result.Height = userProfile.Height;
            result.Weight = userProfile.Weight;
            result.PhoneNumber = userProfile.PhoneNumber;
            result.ProfilePicture = profilePicture;
            result.UserId = userProfile.UserId;

            _userProfileDal.Update(result);
            return new SuccessResult(Messages.UserProfileUpdated);
        }

        public IResult Delete(UserProfileForCreateDto userProfile)
        {
            var result = CheckIfUserProfileExists(userProfile.UserId);
            if (result == null)
            {
                return new ErrorResult(Messages.UserProfileNotFound);
            }

            FormFileHelper.Delete(result.ProfilePicture);

            _userProfileDal.Delete(result);
            return new SuccessResult(Messages.UserProfileDeleted);
        }

        private UserProfile CheckIfUserProfileExists(int userId)
        {
            var result = _userProfileDal.Get(u => u.UserId == userId);
            return result;
        }
    }
}

using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.UserProfile;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IUserProfileService
    {
        IDataResult<List<UserProfile>> GetAll();
        IDataResult<UserProfile> GetById(int userProfileId);
        IResult Add(UserProfileForCreateDto userProfile/*, IFormFile image*/);
        IResult AddList(List<UserProfileForCreateDto> userProfiles);
        IResult Update(UserProfileForCreateDto userProfile, IFormFile image);
        IResult Delete(UserProfileForCreateDto userProfile);
    }
}

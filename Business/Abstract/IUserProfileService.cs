using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.UserProfile;

namespace Business.Abstract
{
    public interface IUserProfileService
    {
        IDataResult<List<UserProfile>> GetAll();
        IDataResult<UserProfile> GetById(int userProfileId);
        IResult Add(UserProfileForCreateDto userProfile);
        IResult Update(UserProfileForCreateDto userProfile);
        IResult Delete(UserProfileForCreateDto userProfile);
    }
}

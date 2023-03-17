using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserProfileService
    {
        IDataResult<List<UserProfile>> GetAll();
        IDataResult<UserProfile> GetById(int userProfileId);
        IResult Add(UserProfile userProfile);
        IResult Update(UserProfile userProfile);
        IResult Delete(UserProfile userProfile);
    }
}

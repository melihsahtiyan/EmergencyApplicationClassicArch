using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserAllergiesService
    {
        IDataResult<List<UserAllergies>> GetAll();
        IDataResult<UserAllergies> GetById(int userAllergiesId);
        IDataResult<List<UserAllergies>> GetUserAllergiesByUserId(int userId);
        IResult Add(UserAllergies userAllergies);
        IResult Update(UserAllergies userAllergies);
        IResult Delete(UserAllergies userAllergies);
    }
}

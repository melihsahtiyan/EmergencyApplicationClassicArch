using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Allergy;

namespace Business.Abstract
{
    public interface IUserAllergiesService
    {
        IDataResult<List<UserAllergies>> GetAll();
        IDataResult<UserAllergies> GetById(int userAllergiesId);
        IDataResult<List<UserAllergies>> GetUserAllergiesByUserId(int userId);
        IResult Add(UserAllergiesForCreateDto userAllergies);
        IResult Update(UserAllergiesForCreateDto userAllergies);
        IResult Delete(UserAllergiesForCreateDto userAllergies);
    }
}

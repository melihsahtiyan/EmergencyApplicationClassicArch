using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserMedicalHistoriesService
    {
        IDataResult<List<UserMedicalHistories>> GetAll();
        IDataResult<UserMedicalHistories> GetById(int userMedicalHistoriesId);
        IResult Add(UserMedicalHistories userMedicalHistories);
        IResult Update(UserMedicalHistories userMedicalHistories);
        IResult Delete(UserMedicalHistories userMedicalHistories);
        IDataResult<List<UserMedicalHistories>> GetByUserId(int userId);
    }
}

using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.MedicalHistory;

namespace Business.Abstract
{
    public interface IUserMedicalHistoriesService
    {
        IDataResult<List<UserMedicalHistories>> GetAll();
        IDataResult<UserMedicalHistories> GetById(int userMedicalHistoriesId);
        IResult Add(UserMedicalHistoriesForCreateDto userMedicalHistories);
        IResult Update(UserMedicalHistoriesForCreateDto userMedicalHistories);
        IResult Delete(UserMedicalHistoriesForCreateDto userMedicalHistories);
        IDataResult<List<UserMedicalHistories>> GetByUserId(int userId);
    }
}

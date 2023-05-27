using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.OngoingDisease;

namespace Business.Abstract
{
    public interface IUserOngoingDiseaseService
    {
        IDataResult<List<UserOngoingDisease>> GetAll();
        IDataResult<UserOngoingDisease> GetById(int userMedicalHistoriesId);
        IResult Add(UserOngoingDiseaseForCreateDto userMedicalHistories);
        IResult Update(UserOngoingDiseaseForCreateDto userMedicalHistories);
        IResult Delete(UserOngoingDiseaseForCreateDto userMedicalHistories);
        IDataResult<List<UserOngoingDisease>> GetByUserId(int userId);
    }
}

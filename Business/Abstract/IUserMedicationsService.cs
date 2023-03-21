using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.Medication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserMedicationsService
    {
        IDataResult<List<UserMedications>> GetAll();
        IDataResult<UserMedications> GetById(int userMedicationsId);
        IResult Add(UserMedicationsForCreateDto userMedications);
        IResult Update(UserMedicationsForCreateDto userMedications);
        IResult Delete(UserMedicationsForCreateDto userMedications);
    }
}

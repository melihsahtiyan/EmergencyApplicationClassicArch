using Core.Utilities.Results;
using Entity.Concrete;
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
        IResult Add(UserMedications userMedications);
        IResult Update(UserMedications userMedications);
        IResult Delete(UserMedications userMedications);
    }
}

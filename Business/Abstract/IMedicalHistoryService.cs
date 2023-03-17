using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMedicalHistoryService
    {
        IDataResult<List<MedicalHistory>> GetAll();
        IDataResult<MedicalHistory> GetById(int medicalHistoryId);
        IResult Add(MedicalHistory medicalHistory);
        IResult Update(MedicalHistory medicalHistory);
        IResult Delete(MedicalHistory medicalHistory);
    }
}

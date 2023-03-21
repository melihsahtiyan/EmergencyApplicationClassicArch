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
    public interface IMedicalHistoryService
    {
        IDataResult<List<MedicalHistory>> GetAll();
        IDataResult<MedicalHistory> GetById(int medicalHistoryId);
        IResult Add(MedicalHistoryForCreateDto medicalHistory);
        IResult Update(MedicalHistoryForCreateDto medicalHistory);
        IResult Delete(MedicalHistoryForCreateDto medicalHistory);
    }
}

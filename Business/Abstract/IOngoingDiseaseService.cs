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
    public interface IOngoingDiseaseService
    {
        IDataResult<List<OngoingDisease>> GetAll();
        IDataResult<OngoingDisease> GetById(int medicalHistoryId);
        IResult Add(OngoingDiseaseForCreateDto ongoingDeseases);
        IResult Update(OngoingDiseaseForCreateDto ongoingDeseases);
        IResult Delete(OngoingDiseaseForCreateDto ongoingDeseases);
    }
}

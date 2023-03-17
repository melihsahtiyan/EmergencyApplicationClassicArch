using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMedicationService
    {
        IDataResult<List<Medication>> GetAll();
        IDataResult<Medication> GetById(int medicationId);
        IResult Add(Medication medication);
        IResult Update(Medication medication);
        IResult Delete(Medication medication);
    }
}

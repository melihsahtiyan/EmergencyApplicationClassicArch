using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAllergyService
    {
        IDataResult<List<Allergy>> GetAll();
        IDataResult<Allergy> GetById(int allergyId);
        IResult Add(Allergy allergy);
        IResult Update(Allergy allergy);
        IResult Delete(Allergy allergy);
    }
}

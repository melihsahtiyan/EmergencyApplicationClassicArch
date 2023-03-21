using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.Allergy;

namespace Business.Abstract
{
    public interface IAllergyService
    {
        IDataResult<List<Allergy>> GetAll();
        IDataResult<Allergy> GetById(int allergyId);
        IResult Add(AllergyForCreateDto allergy);
        IResult Update(AllergyForCreateDto allergy);
        IResult Delete(AllergyForCreateDto allergy);
    }
}

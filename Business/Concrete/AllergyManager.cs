using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AllergyManager : IAllergyService
    {
        IAllergyDal _allergyDal;

        public AllergyManager(IAllergyDal allergyDal)
        {
            _allergyDal = allergyDal;
        }

        public IResult Add(Allergy allergy)
        {
            _allergyDal.Add(allergy);
            return new SuccessResult(Messages.AllergyAdded);
        }

        public IResult Delete(Allergy allergy)
        {
            _allergyDal.Delete(allergy);
            return new SuccessResult(Messages.AllergyDeleted);
        }

        public IDataResult<List<Allergy>> GetAll()
        {
            return new SuccessDataResult<List<Allergy>>(_allergyDal.GetAll(), Messages.AllergiesListed);
        }

        public IDataResult<Allergy> GetById(int allergyId)
        {
            return new SuccessDataResult<Allergy>(_allergyDal.Get(a => a.Id == allergyId));
        }

        public IResult Update(Allergy allergy)
        {
            _allergyDal.Update(allergy);
            return new SuccessResult(Messages.AllergyUpdated);
        }
    }
}

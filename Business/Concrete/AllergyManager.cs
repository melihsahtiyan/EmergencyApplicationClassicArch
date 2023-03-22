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
using Entity.Dtos.Allergy;

namespace Business.Concrete
{
    public class AllergyManager : IAllergyService
    {
        IAllergyDal _allergyDal;

        public AllergyManager(IAllergyDal allergyDal)
        {
            _allergyDal = allergyDal;
        }

        public IResult Add(AllergyForCreateDto allergy)
        {
            var check = CheckIfAllergyExists(allergy.Id, allergy.Name);
            if (check)
            {
                return new ErrorResult(Messages.AllergyExists);
            }

            var result = new Allergy()
            {
                Name = allergy.Name,
                Description = allergy.Description
            };

            _allergyDal.Add(result);
            return new SuccessResult(Messages.AllergyAdded);
        }

        public IResult Delete(AllergyForCreateDto allergy)
        {
            var check = CheckIfAllergyExists(allergy.Id, allergy.Name);

            if (!check)
            {
                return new ErrorResult(Messages.AllergyNotFound);
            }

            var result = new Allergy()
            {
                Id = allergy.Id,
                Name = allergy.Name,
                Description = allergy.Description
            };
            _allergyDal.Delete(result);
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

        public IResult Update(AllergyForCreateDto allergy)
        {
            var check = CheckIfAllergyExists(allergy.Id, allergy.Name);

            if (!check)
            {
                return new ErrorResult(Messages.AllergyNotFound);
            }

            var result = new Allergy()
            {
                Id = allergy.Id,
                Name = allergy.Name,
                Description = allergy.Description,
            };
            _allergyDal.Update(result);
            return new SuccessResult(Messages.AllergyUpdated);
        }

        private bool CheckIfAllergyExists(int id, string name)
        {
            var result = _allergyDal.GetAll(a => a.Id == id || a.Name == name).Any();
            return result;
        }
    }
}

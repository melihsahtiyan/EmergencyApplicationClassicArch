using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class MedicationManager : IMedicationService
    {
        private readonly IMedicationDal _medicationDal;

        public MedicationManager(IMedicationDal medicationDal)
        {
            _medicationDal = medicationDal;
        }


        public IDataResult<List<Medication>> GetAll()
        {
            return new SuccessDataResult<List<Medication>>(_medicationDal.GetAll(), Messages.MedicationsListed);
        }

        public IDataResult<Medication> GetById(int medicationId)
        {
            var result = _medicationDal.Get(m => m.Id == medicationId);
            if (result == null)
            {
                return new ErrorDataResult<Medication>(Messages.MedicationNotFound);
            }
            return new SuccessDataResult<Medication>(result, Messages.MedicationListed);
        }

        public IResult Add(Medication medication)
        {
            var check = CheckIfMedicationByName(medication.Name);
            if (check)
            {
                return new ErrorResult(Messages.MedicationExists);
            }
            _medicationDal.Add(medication);
            return new SuccessResult(Messages.MedicationAdded);
        }

        public IResult Update(Medication medication)
        {
            var check = CheckIfMedicationById(medication.Id);
            
            if (!check)
            {
                return new ErrorResult(Messages.MedicationNotFound);
            }
            
            var checkName = CheckIfMedicationByName(medication.Name);
            
            if (!checkName)
            {
                return new ErrorResult(Messages.MedicationExists);
            }

            _medicationDal.Update(medication);
            return new SuccessResult(Messages.MedicationUpdated);
        }

        public IResult Delete(Medication medication)
        {
            var check = CheckIfMedicationById(medication.Id);
            
            if (!check)
            {
                return new ErrorResult(Messages.MedicationNotFound);
            }

            _medicationDal.Delete(medication);
            return new SuccessResult(Messages.MedicationDeleted);
        }

        private bool CheckIfMedicationByName(string name)
        {
            var result = _medicationDal.Get(m => m.Name == name);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        private bool CheckIfMedicationById(int id)
        {
            var result = _medicationDal.Get(m => m.Id == id);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}

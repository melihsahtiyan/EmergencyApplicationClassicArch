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
using Entity.Dtos.Medication;

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

        public IResult Add(MedicationForCreateDto medication)
        {
            var result = CheckIfMedicationExists(medication.Name);
            if (result != null)
            {
                return new ErrorResult(Messages.MedicationExists);
            }

            result.Name = medication.Name;
            result.Description = medication.Description;

            _medicationDal.Add(result);
            return new SuccessResult(Messages.MedicationAdded);
        }

        public IResult Update(MedicationForCreateDto medication)
        {
            var result = CheckIfMedicationExists(medication.Id);
            
            if (result == null)
            {
                return new ErrorResult(Messages.MedicationNotFound);
            }
            
            var checkName = CheckIfMedicationExists(medication.Name);
            
            if (checkName != null)
            {
                return new ErrorResult(Messages.MedicationExists);
            }

            

            _medicationDal.Update(result);
            return new SuccessResult(Messages.MedicationUpdated);
        }

        public IResult Delete(MedicationForCreateDto medication)
        {
            var result = CheckIfMedicationExists(medication.Id);
            
            if (result == null)
            {
                return new ErrorResult(Messages.MedicationNotFound);
            }

            result.Name = medication.Name;
            result.Description = medication.Description;

            _medicationDal.Delete(result);
            return new SuccessResult(Messages.MedicationDeleted);
        }

        private Medication CheckIfMedicationExists(string name)
        {
            var result = _medicationDal.Get(m => m.Name == name);
            
            return result;
        }

        private Medication CheckIfMedicationExists(int id)
        {
            var result = _medicationDal.Get(m => m.Id == id);
            
            return result;
        }
    }
}

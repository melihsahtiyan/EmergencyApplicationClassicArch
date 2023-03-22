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
    public class UserMedicationsManager : IUserMedicationsService
    {
        private readonly IUserMedicationDal _userMedicationDal;
        private readonly IUserDal _userDal;
        private readonly IMedicationDal _medicationDal;

        public UserMedicationsManager(IUserMedicationDal userMedicationDal, IUserDal userDal,
            IMedicationDal medicationDal)
        {
            _userMedicationDal = userMedicationDal;
            _userDal = userDal;
            _medicationDal = medicationDal;
        }

        public IDataResult<List<UserMedications>> GetAll()
        {
            return new SuccessDataResult<List<UserMedications>>(_userMedicationDal.GetAll());
        }

        public IDataResult<UserMedications> GetById(int userMedicationsId)
        {
            var result = _userMedicationDal.Get(m => m.Id == userMedicationsId);
            if (result == null)
            {
                return new ErrorDataResult<UserMedications>(Messages.UserMedicationNotFound);
            }
            return new SuccessDataResult<UserMedications>(result, Messages.UserMedicationListed);
        }

        public IResult Add(UserMedicationsForCreateDto userMedications)
        {
            var check = CheckIfUserMedicationExists(userMedications.UserId, userMedications.MedicationId);
            if (check)
            {
                return new ErrorResult(Messages.UserMedicationExists);
            }
            _userMedicationDal.Add(userMedications);
            return new SuccessResult(Messages.UserMedicationAdded);
        }

        public IResult Update(UserMedicationsForCreateDto userMedications)
        {
            var check = CheckIfUserMedicationById(userMedications.Id);
            if (!check)
            {
                return new ErrorResult(Messages.UserMedicationNotFound);
            }

            var checkName = CheckIfUserMedicationExists(userMedications.UserId, userMedications.MedicationId);
            if (checkName)
            {
                return new ErrorResult(Messages.UserMedicationExists);
            }

            _userMedicationDal.Update(userMedications);
            return new SuccessResult(Messages.UserMedicationUpdated);
        }

        public IResult Delete(UserMedicationsForCreateDto userMedications)
        {
            var check = CheckIfUserMedicationById(userMedications.Id);
            if (!check)
            {
                return new ErrorResult(Messages.UserMedicationNotFound);
            }
            _userMedicationDal.Delete(userMedications);
            return new SuccessResult(Messages.UserMedicationDeleted);
        }

        public IDataResult<List<UserMedications>> GetByUserId(int userId)
        {
            var result = _userMedicationDal.GetAll(m => m.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<List<UserMedications>>(Messages.UserMedicationNotFound);
            }
            return new SuccessDataResult<List<UserMedications>>(result, Messages.UserMedicationListed);
        }

        private bool CheckIfUserMedicationExists(int userId, int medicationId)
        {
            var result = _userMedicationDal.GetAll(m => m.UserId == userId && m.MedicationId == medicationId);
            if (result.Count > 0)
            {
                return false;
            }
            return true;
        }

        private bool CheckIfUserMedicationById(int userMedicationId)
        {
            var result = _userMedicationDal.Get(m => m.Id == userMedicationId);
            if (result == null)
            {
                return false;
            }
            return true;
        }
    }
}

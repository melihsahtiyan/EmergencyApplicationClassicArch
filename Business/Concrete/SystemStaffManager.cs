using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.Dtos.SystemStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SystemStaffManager : ISystemStaffService
    {
        ISystemStaffDal _systemStaffDal;
        public SystemStaffManager(ISystemStaffDal systemStaffDal)
        {
            _systemStaffDal = systemStaffDal;
        }
        public IResult Add(SystemStaffForCreateDto systemStaff)
        {
            var check = CheckIfSystemStaffExists(systemStaff.UserId, systemStaff.StaffNumber);
            if (check)
            {
                return new ErrorResult(Messages.SystemStaffExists);
            }

            var result = new SystemStaff()
            {
                UserId = systemStaff.UserId,
                StaffStatus = systemStaff.StaffStatus,
                StaffNumber = systemStaff.StaffNumber
            };

            _systemStaffDal.Add(result);
            return new SuccessResult(Messages.SystemStaffAdded);
        }
        public IResult Delete(SystemStaffForCreateDto systemStaff)
        {
            var check = CheckIfSystemStaffExists(systemStaff.UserId, systemStaff.StaffNumber);
            if (!check)
            {
                return new ErrorResult(Messages.SystemStaffNotFound);
            }

            var result = new SystemStaff()
            {
                Id = systemStaff.Id,
                UserId = systemStaff.UserId,
                StaffStatus = systemStaff.StaffStatus,
                StaffNumber = systemStaff.StaffNumber
            };

            _systemStaffDal.Delete(result);
            return new SuccessResult(Messages.SystemStaffDeleted);
        }
        public IDataResult<List<SystemStaff>> GetAll()
        {
            return new SuccessDataResult<List<SystemStaff>>(_systemStaffDal.GetAll(), Messages.SystemStaffsListed);
        }
        public IDataResult<SystemStaff> GetById(int systemStaffId)
        {
            var result = _systemStaffDal.Get(ss => ss.Id == systemStaffId);
            if (result == null)
            {
                return new ErrorDataResult<SystemStaff>(Messages.SystemStaffNotFound);
            }
            return new SuccessDataResult<SystemStaff>(result, Messages.SystemStaffsListed);
        }
        public IResult Update(SystemStaffForCreateDto systemStaff)
        {
            var check = CheckIfSystemStaffExists(systemStaff.UserId, systemStaff.StaffNumber);
            if (!check)
            {
                return new ErrorResult(Messages.SystemStaffNotFound);
            }

            var result = new SystemStaff()
            {
                Id = systemStaff.Id,
                UserId = systemStaff.UserId,
                StaffStatus = systemStaff.StaffStatus,
                StaffNumber = systemStaff.StaffNumber
            };

            _systemStaffDal.Update(result);
            return new SuccessResult(Messages.SystemStaffUpdated);
        }

        private bool CheckIfSystemStaffExists(int userId, string staffNumber)
        {
            var result = _systemStaffDal.GetAll(ss => ss.UserId == userId && ss.StaffNumber == staffNumber).Any();
            return result;
        }
    }
}

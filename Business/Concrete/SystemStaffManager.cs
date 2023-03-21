using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
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
        public IResult Add(SystemStaff systemStaff)
        {
            var check = CheckIfSystemStaffExists(systemStaff.UserId, systemStaff.StaffNumber);
            if (check)
            {
                return new ErrorResult(Messages.SystemStaffExists);
            }
            _systemStaffDal.Add(systemStaff);
            return new SuccessResult(Messages.SystemStaffAdded);
        }
        public IResult Delete(SystemStaff systemStaff)
        {
            var check = CheckIfSystemStaffExists(systemStaff.UserId, systemStaff.StaffNumber);
            if (!check)
            {
                return new ErrorResult(Messages.SystemStaffNotFound);
            }
            _systemStaffDal.Delete(systemStaff);
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
        public IResult Update(SystemStaff systemStaff)
        {
            var check = CheckIfSystemStaffExists(systemStaff.UserId, systemStaff.StaffNumber);
            if (!check)
            {
                return new ErrorResult(Messages.SystemStaffNotFound);
            }
            _systemStaffDal.Update(systemStaff);
            return new SuccessResult(Messages.SystemStaffUpdated);
        }

        private bool CheckIfSystemStaffExists(int userId, string staffNumber)
        {
            var result = _systemStaffDal.GetAll(ss => ss.UserId == userId && ss.StaffNumber == staffNumber).Any();
            return result;
        }
    }
}

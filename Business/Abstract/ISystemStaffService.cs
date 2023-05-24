using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.SystemStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISystemStaffService
    {
        IDataResult<List<SystemStaff>> GetAll();
        IDataResult<SystemStaff> GetById(int id);
        IDataResult<SystemStaff> GetByStaffNumber(string staffNumber);
        IResult Add(SystemStaffForCreateDto systemStaff);
        IResult Update(SystemStaffForCreateDto systemStaff);
        IResult Delete(SystemStaffForCreateDto systemStaff);
    }
}

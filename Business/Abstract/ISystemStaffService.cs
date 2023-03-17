using Core.Utilities.Results;
using Entity.Concrete;
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
        IDataResult<SystemStaff> GetById(int systemStaffId);
        IResult Add(SystemStaff systemStaff);
        IResult Update(SystemStaff systemStaff);
        IResult Delete(SystemStaff systemStaff);
    }
}

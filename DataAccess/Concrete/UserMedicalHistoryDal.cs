using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class UserMedicalHistoryDal : EfEntityRepositoryBase<UserMedicalHistories, BaseDbContext>,
        IUserMedicalHistoryDal

    {
        public UserMedicalHistoryDal(BaseDbContext context) : base(context)
        {
        }
    }
}

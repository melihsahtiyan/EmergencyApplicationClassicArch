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
    public class ContactDal : EfEntityRepositoryBase<Contact, BaseDbContext>, IContactDal
    {
        public ContactDal(BaseDbContext context) : base(context)
        {
        }
    }
}

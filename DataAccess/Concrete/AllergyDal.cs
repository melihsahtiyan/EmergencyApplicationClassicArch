using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;

namespace DataAccess.Concrete
{
    public class AllergyDal : EfEntityRepositoryBase<Allergy, BaseDbContext>, IAllergyDal
    {
        public AllergyDal(BaseDbContext context) : base(context)
        {
        }
    }
}

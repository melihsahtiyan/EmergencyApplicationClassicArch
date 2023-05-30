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
    public class PostTemplateDal : EfEntityRepositoryBase<PostTemplate, BaseDbContext>, IPostTemplateDal
    {
        public PostTemplateDal(BaseDbContext context) : base(context)
        {
        }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class UserDal : EfEntityRepositoryBase<User, BaseDbContext>, IUserDal
    {
        public UserDal(BaseDbContext context) : base(context)
        {
        }
        public List<OperationClaim> GetClaims(User user)
        {
            
                var result = from operationClaim in Context.OperationClaims
                             join userOperationClaim in Context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            
        }
    }
}

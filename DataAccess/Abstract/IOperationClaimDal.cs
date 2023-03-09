using Core.DataAccess;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    internal interface IOperationClaimDal : IEntityRepository<OperationClaim>
    {
    }
}

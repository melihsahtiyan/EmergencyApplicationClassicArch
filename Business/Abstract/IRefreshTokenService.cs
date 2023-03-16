using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRefreshTokenService
    {
        IDataResult<List<RefreshToken>> GetAll();
        IDataResult<RefreshToken> GetById(int refreshTokenId);
        IResult Add(RefreshToken refreshToken);
        IResult Update(RefreshToken refreshToken);
        IResult Delete(RefreshToken refreshToken);
    }
}

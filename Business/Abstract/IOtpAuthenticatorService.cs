using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOtpAuthenticatorService
    {
        IDataResult<List<OtpAuthenticator>> GetAll();
        IDataResult<OtpAuthenticator> GetById(int otpAuthenticatorId);
        IResult Add(OtpAuthenticator otpAuthenticator);
        IResult Update(OtpAuthenticator otpAuthenticator);
        IResult Delete(OtpAuthenticator otpAuthenticator);
    }
}

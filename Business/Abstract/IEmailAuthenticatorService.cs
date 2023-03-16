using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmailAuthenticatorService
    {
        IDataResult<List<EmailAuthenticator>> GetAll();
        IDataResult<EmailAuthenticator> GetById(int emailAuthenticatorId);
        IResult Add(EmailAuthenticator emailAuthenticator);
        IResult Update(EmailAuthenticator emailAuthenticator);
        IResult Delete(EmailAuthenticator emailAuthenticator);
    }
}

using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(UserForCreateDto user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IResult Update(UserForCreateDto user);
        IResult Delete(UserForCreateDto user);
    }
}

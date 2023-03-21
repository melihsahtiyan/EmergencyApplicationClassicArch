using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        IResult IUserService.Add(UserForCreateDto user)
        {
            var check = CheckIfUserUserExists(user.Id, user.IdentityNumber);
            if (!check)
            {
                return new ErrorResult(Messages.UserExists);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(result, Messages.UserListed);
        }

        public IResult Update(UserForCreateDto user)
        {
            var check = CheckIfUserUserExists(user.Id, user.IdentityNumber);
            if (!check)
            {
                return new ErrorResult(Messages.UserExists);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(UserForCreateDto user)
        {
            var check = CheckIfUserUserExists(user.Id, user.IdentityNumber);
            if (!check)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        private bool CheckIfUserUserExists(int id, string identityNumber)
        {
            var result = _userDal.GetAll(u => u.Id == id || u.IdentityNumber == identityNumber).Any();
            return result;
        }
    }
}

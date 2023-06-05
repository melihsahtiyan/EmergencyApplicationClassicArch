using Business.Abstract;
using Business.Constants;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dtos.SystemStaff;

namespace Business.Concrete
{
    public class AuthManager: IAuthService
    {
        private IUserService _userService;
        private ISystemStaffService _systemStaffService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, 
            ISystemStaffService systemStaffService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _systemStaffService = systemStaffService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IdentityNumber = userForRegisterDto.IdentityNumber,
                BirthDate = userForRegisterDto.BirthDate,
                Status = true
            };
            var result = _userService.Add(user);
            if (result.Success)
            {
                return new SuccessDataResult<User>(user, Messages.UserRegistered);
            }

            return new ErrorDataResult<User>(Messages.UserRegisterFailure);
        }

        public IDataResult<User> RegisterList(List<UserForRegisterDto> usersForRegisterDto, string password)
        {
            foreach (var userForRegisterDto in usersForRegisterDto)
            {
                var userToCheck = _userService.GetByMail(userForRegisterDto.Email).Data;
                if (userToCheck != null)
                {
                    return new ErrorDataResult<User>(Messages.UserAlreadyExists);
                }
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User()
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IdentityNumber = userForRegisterDto.IdentityNumber,
                    BirthDate = userForRegisterDto.BirthDate,
                    Status = true
                };
                var result = _userService.Add(user);
                if (!result.Success)
                {
                    return new ErrorDataResult<User>(Messages.UserRegisterFailure);
                }
            }
            return new SuccessDataResult<User>(Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.WrongEmailOrPassword);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.WrongEmailOrPassword);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<User> SystemStaffLogin(SystemStaffForLoginDto systemStaffForLoginDto)
        {
            var staffToCheck = _systemStaffService.GetByStaffNumber(systemStaffForLoginDto.StaffNumber).Data;
            if (staffToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.SystemStaffNotFound);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(systemStaffForLoginDto.Password, out passwordHash, out passwordSalt);

            if (!HashingHelper.VerifyPasswordHash(systemStaffForLoginDto.Password, passwordHash, passwordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            var userToCheck = _userService.GetById(staffToCheck.UserId).Data;

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> SystemStaffRegister(SystemStaffForRegisterDto systemStaffForRegisterDto)
        {
            var staffToCheck = _systemStaffService.GetByStaffNumber(systemStaffForRegisterDto.StaffNumber).Data;

            if (staffToCheck != null)
            {
                return new ErrorDataResult<User>(Messages.SystemStaffExists);
            }

            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(systemStaffForRegisterDto.Password, 
                out passwordHash, out passwordSalt);

            var userToAdd = new User()
            {

                Email = systemStaffForRegisterDto.Email,
                FirstName = systemStaffForRegisterDto.FirstName,
                LastName = systemStaffForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IdentityNumber = systemStaffForRegisterDto.IdentityNumber,
                BirthDate = systemStaffForRegisterDto.BirthDate,
                Status = true
            };

            _userService.Add(userToAdd);

            var addedUser = _userService.GetByMail(systemStaffForRegisterDto.Email).Data;

            var staffToAdd = new SystemStaffForCreateDto()
            {
                UserId = addedUser.Id,
                StaffNumber = systemStaffForRegisterDto.StaffNumber,
                StaffStatus = systemStaffForRegisterDto.StaffStatus
            };

            _systemStaffService.Add(staffToAdd);

            return new SuccessDataResult<User>(userToAdd,Messages.SystemStaffAdded);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}

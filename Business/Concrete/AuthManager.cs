using Business.Abstract;
using Business.Contants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims=_userService.GetClaims(user);

            var accessToken=_tokenHelper.CreateToken(user,claims);

            if (claims==null || accessToken==null)
            {
                return new ErrorDataResult<AccessToken>(Message.ErrorAccessToken);
            }

            return new SuccessDataResult<AccessToken>(accessToken, Message.AccessTokenCreated);


        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email=userForRegisterDto.Email,
                FirstName=userForRegisterDto.FirstName,
                LastName=userForRegisterDto.LastName,
                PasswordHash=passwordHash,
                PasswordSalt=passwordSalt,
                Status=true
            };
            _userService.Add(user);

            return new SuccessDataResult<User>(user,Message.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userCheck==null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userCheck.PasswordHash,userCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Message.PasswordError);
            }

            return new SuccessDataResult<User>(userCheck, Message.SuccessfulLogin);
        }

      

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Message.UserAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}

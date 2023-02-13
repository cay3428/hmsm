using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserDal _userDal;
      IUserService _userService;
         ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,IUserDal userDal)
        {
            _userDal = userDal;
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {   
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Id = userForRegisterDto.Id,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatası");
            }

            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IDataResult<UserForUpdateDto> Update(UserForUpdateDto userForUpdateDto)
        {
       var user = _userService.GetById(userForUpdateDto.Id);
           
            var newUser = new User
            {
                Id = user.Data.Id,
                Email = userForUpdateDto.Email,
                FirstName = userForUpdateDto.FirstName,
                LastName = userForUpdateDto.LastName,
                PasswordHash = user.Data.PasswordHash,
                PasswordSalt = user.Data.PasswordSalt,
                Status = true
            };
           
            _userService.Update(newUser);
            return new SuccessDataResult<UserForUpdateDto>(userForUpdateDto, Messages.UserUpdated);
        }
 

        public IDataResult<User> GetById(int id)
        {
            return _userService.GetById(id);
        }

        public IDataResult<List<User>> GetAll()
        {
           
            return _userService.GetAll() ;
        }

        public IResult Delete(int ıd)
        {
            var user = _userDal.Get(r => r.Id == ıd);

            if (user!= null)
            {
                _userDal.Delete(user);

                return new SuccessResult(Messages.UserDeleted);
            }

            return new ErrorResult("Kullanıcı yok!");

        }

        public IResult Add(User user)
        {

           
 

            _userDal.Add(user);

            return new SuccessResult("Kullanıcı eklendi");
        }
    }
}

 
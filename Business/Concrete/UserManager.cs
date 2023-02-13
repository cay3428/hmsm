using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

       

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == Id));
        }

        public IDataResult<List<User>> GetAll()
        {

            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserShows);
        }

        IResult IUserService.Delete(int id)
        {
            var user = _userDal.Get(r => r.Id == id);

            if (user != null)
            {
                _userDal.Delete(user);

                return new SuccessResult(Messages.UserDeleted);
            }

            return new ErrorResult("Kullanıcı yok!");

        }
    }
    }


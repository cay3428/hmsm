using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;
using Entities.DTOs;
using System.Text;


namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

       void Update(User user);
       IResult Delete(int id);
       
        IDataResult<User> GetById(int  Id);


        IDataResult<List<User>> GetAll();


 
    }
}

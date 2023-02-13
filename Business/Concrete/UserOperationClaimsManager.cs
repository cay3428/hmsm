using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimsManager : IUserOperationClaimsService
    {
        IUserOperationClaimsDal _userOperationClaimsDal;
        public UserOperationClaimsManager(IUserOperationClaimsDal userOperationClaimsDal)
        {
            _userOperationClaimsDal = userOperationClaimsDal;   
        }

        public IDataResult<UserOperationClaim> GetByAuthId(int Id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimsDal.Get(p => p.Id == Id));
        }

        public IResult Update(UserOperationClaim userOperationClaims)
        {
           
            _userOperationClaimsDal.Update(userOperationClaims);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
 
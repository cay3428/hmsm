using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Core.Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserOperationClaimsService
    {
        IResult Update(UserOperationClaim userOperationClaims);
        IDataResult<UserOperationClaim > GetByAuthId(int Id);
    }
}

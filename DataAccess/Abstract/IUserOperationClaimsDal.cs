using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimsDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimsDto> GetOperationDetails(Expression<Func<UserOperationClaim, bool>> filter = null);
    }
}

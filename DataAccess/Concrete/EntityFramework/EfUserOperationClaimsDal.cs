using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs.Entities.DTOs;
using System.Linq.Expressions;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfUserOperationClaimsDal : EfEntityRepositoryBase<UserOperationClaim, OzztechContext>, IUserOperationClaimsDal
    {
        public List<OperationClaim> GetClaims(UserOperationClaims userOperationClaims)
        {
            using (var context = new OzztechContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join useraOperationClaims in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaims.OperationClaimId
                             where userOperationClaims.Id ==  userOperationClaims. Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id ,
                              Name = operationClaim.Name ,
                             };


                return result.ToList();
            }


        }

         

        public List<UserOperationClaimsDto> GetOperationDetails(Expression<Func<UserOperationClaim, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}


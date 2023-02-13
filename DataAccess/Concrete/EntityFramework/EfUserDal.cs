using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs.Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, OzztechContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new OzztechContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim. Id == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetails(Expression<Func<UserDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}

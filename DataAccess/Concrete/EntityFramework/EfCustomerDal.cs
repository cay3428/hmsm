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

    public class EfCustomerDal : EfEntityRepositoryBase<Customer, OzztechContext>, ICustomerDal
    {
       public List<OperationClaim> GetClaims(Customer customer)
        {
            using (var context = new OzztechContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join customerOperationClaim in context.CustomerOperationClaims
                             on operationClaim.Id equals customerOperationClaim.OperationClaimId
                             where customerOperationClaim.customerId == customer.CustomerId
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };


                             return result.ToList();
            }

            
        }

        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Sales, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}


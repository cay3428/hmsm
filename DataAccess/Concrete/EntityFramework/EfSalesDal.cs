using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


 

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSalesDal : EfEntityRepositoryBase<Sales, OzztechContext>, ISalesDal
    {
        public List<OperationClaim> GetClaims(Sales sales )
        {
            
                using (var context = new OzztechContext())
                {
                    var result = from operationClaim in context.OperationClaims
                                 join salesOperationClaim in context.SalesOperationClaims
                                 on operationClaim.Id equals salesOperationClaim.OperationClaimId
                                 where salesOperationClaim.SalesId == sales.SalesId
                                 select new OperationClaim
                                 {
                                      Id= operationClaim.Id,
                                      Name= operationClaim.Name,
                                      
                                 };


                    return result.ToList();
                }
            }

        public List<SalesDetailDto> GetSalesDetails(Expression<Func<Sales, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
    
}


 
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISalesDal : IEntityRepository<Sales>
    {
        List<SalesDetailDto> GetSalesDetails(Expression<Func<Sales, bool>> filter = null);
    }
}

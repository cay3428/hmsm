using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISalesService
    {

        IDataResult<List<Sales>> GetAll();
        IDataResult<List<Sales>> GetbySId(int salesId);
        IDataResult<List<Sales>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<SalesDetailDto>> GetSalesDetails();
        IDataResult<Sales> GetById(int customerId);
        IResult Add(Sales sales);
        IResult Update(Sales sales);
        IResult Delete(int Id);

    }
}

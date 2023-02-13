using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SalesManager : ISalesService
    {
        ISalesDal _salesDal;

        public SalesManager(ISalesDal salesDal)
        {
            _salesDal = salesDal;

        }

        public IResult Add(Sales sales)
        {

             
            _salesDal.Add(sales);
            return new SuccessResult(Messages.CustomerAdd);
        }

        public IResult Delete(int SalesId)
        {
            var sales = _salesDal.Get(r => r.SalesId == SalesId);
            _salesDal.Delete(sales);

            return new SuccessResult(Messages.SalesDelete);
        }

        public IDataResult<List<Sales>> GetAll()
        {
            return new SuccessDataResult<List<Sales>>(_salesDal.GetAll());
        }

            public IDataResult<List<Sales>> GetbySId(int salesId)
            {
            return new SuccessDataResult<List<Sales>>(_salesDal.GetAll(p => p.SalesId== salesId));

        }

        public IDataResult<Sales> GetById(int CustomerId)
            {
            return new SuccessDataResult<Sales>(_salesDal.Get(b => b.CustomerId == CustomerId));

        }

        public IDataResult<List<Sales>> GetByUnitPrice(decimal min, decimal max)
            {
            return new SuccessDataResult<List<Sales>>(_salesDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<SalesDetailDto>> GetSalesDetails()
            {
            return new SuccessDataResult<List<SalesDetailDto>>(_salesDal.GetSalesDetails());
        }

        [ValidationAspect(typeof(SalesValidator))]
        public IResult Update(Sales sales)
            {
 
            _salesDal.Update(sales);
            return new SuccessResult(Messages.SalesUpdate);
        }
        
    }
}


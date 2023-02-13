using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
       
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
 
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
             
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdd);
        }

        public IResult Delete(int customerId)
        {
            var customer = _customerDal.Get(r => r.CustomerId == customerId);
            if (customer != null)
            {
                _customerDal.Delete(customer);

                return new SuccessResult(Messages.UserDeleted);
            }
            return new ErrorResult("Yok");
        }

        

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.CustomerId == customerId));
        }

        

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
        
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
             
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
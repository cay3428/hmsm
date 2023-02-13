using Core.Entities.Concrete;
 
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c).NotEmpty();
            RuleFor(c => c.CustomerName).MinimumLength(3).WithMessage("Müşteri ismi en az 3 karakter olmalıdır");
        }
    }
}

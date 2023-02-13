using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SalesValidator:AbstractValidator<Sales>
    {
        public SalesValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.ProductId == 1);
            RuleFor(c => c.CustomerId).NotEmpty();
            RuleFor(c => c).NotEmpty();
            RuleFor(c => c.CustomerName).MinimumLength(3).WithMessage("Müşteri ismi en az 3 karakter olmalıdır");

        }
    }
}

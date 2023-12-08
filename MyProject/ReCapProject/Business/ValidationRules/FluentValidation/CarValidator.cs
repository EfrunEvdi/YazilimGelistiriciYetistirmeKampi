using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MinimumLength(2).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı "); ;
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(0).GreaterThanOrEqualTo(90).When(c => c.BrandId == 1);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

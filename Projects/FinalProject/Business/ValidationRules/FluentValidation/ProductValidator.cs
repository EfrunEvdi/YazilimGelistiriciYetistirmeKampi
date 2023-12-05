using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName)
                   .NotEmpty().WithMessage("Ürün adı boş bırakılamaz.")
                   .Must(StartWithA).WithMessage("Ürün adı A ile başlamalıdır.")
                   .MinimumLength(2).WithMessage("Ürün adı minimum 2 karakter olmalıdır.");

            RuleFor(p => p.UnitPrice)
                   .NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz.")
                   .GreaterThan(0).WithMessage("Ürün fiyatı 0 dan büyük olmalıdır.")
                   .GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

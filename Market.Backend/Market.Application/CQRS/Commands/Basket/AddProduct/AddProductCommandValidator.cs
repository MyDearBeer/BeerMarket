using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Basket.AddProduct
{
    public class AddProductCommandValidator
        : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(addProductCommand =>
            addProductCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(addProductCommand =>
            addProductCommand.ProductId).NotEqual(Guid.Empty);
        }
    }
}

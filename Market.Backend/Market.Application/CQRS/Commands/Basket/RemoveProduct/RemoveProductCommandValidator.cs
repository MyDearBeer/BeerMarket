using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Basket.RemoveProduct
{
    public class RemoveProductCommandValidator
        : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(removeProduct => removeProduct.Id).NotEqual(Guid.Empty);
            RuleFor(removeProduct => removeProduct.UserId).NotEqual(Guid.Empty);
        }
    }
}

using FluentValidation;
using Market.Application.Products.Commands.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(updateProductCommand =>
            updateProductCommand.Name).NotEmpty();
            RuleFor(updateProductCommand =>
            updateProductCommand.FactoryId).NotEmpty();
            RuleFor(updateProductCommand =>
            updateProductCommand.TypeId).NotEmpty();
            RuleFor(updateProductCommand =>
            updateProductCommand.Rating).NotEmpty().InclusiveBetween(0, 5);
            RuleFor(updateProductCommand =>
            updateProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}

using FluentValidation;
using Market.Application.CQRS.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Products.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Name).NotEmpty();
            RuleFor(createProductCommand =>
            createProductCommand.FactoryId).NotEmpty();
            RuleFor(createProductCommand =>
            createProductCommand.TypeId).NotEmpty();
            RuleFor(createProductCommand =>
            createProductCommand.Rating).NotEmpty().InclusiveBetween(0, 5);
        }
    }
}

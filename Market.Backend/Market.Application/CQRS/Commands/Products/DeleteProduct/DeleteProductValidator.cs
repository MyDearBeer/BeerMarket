using FluentValidation;
using Market.Application.Products.Commands.DeleteProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Products.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator()
        {
            RuleFor(deleteProductCommand =>
            deleteProductCommand.Id).NotEmpty();
        }
    }
}

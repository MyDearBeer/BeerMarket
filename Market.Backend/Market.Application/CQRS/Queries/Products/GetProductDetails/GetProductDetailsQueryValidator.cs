using FluentValidation;
using Market.Application.CQRS.Commands.CreateProduct;
using Market.Application.Products.Queries.GetProductDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetProductDetails
{
    public class GetProductDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
    {
        public GetProductDetailsQueryValidator()
        {
            RuleFor(product => product.Id).NotEmpty();
            
        }
    }
}

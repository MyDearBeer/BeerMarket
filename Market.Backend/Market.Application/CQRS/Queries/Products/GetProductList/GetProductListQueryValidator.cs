using FluentValidation;
using Market.Application.CQRS.Commands.CreateProduct;
using Market.Application.Products.Queries.GetProductList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetProductList
{
    public class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
    {
        public GetProductListQueryValidator()
        {
            RuleFor(createProductCommand =>
            createProductCommand.Page).GreaterThanOrEqualTo(1);
            RuleFor(createProductCommand =>
            createProductCommand.Limit).GreaterThanOrEqualTo(1);
        }
    }
}

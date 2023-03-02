using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetBasketProductList
{
    public class GetBasketProductListQueryValidator
        : AbstractValidator<GetBasketProductListQuery>
    {
        public GetBasketProductListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}

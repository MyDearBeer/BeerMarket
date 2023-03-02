using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetBasketProductList
{
    public class BasketProductListVm
    {
        public IList<BasketProductListDto> BasketProducts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductList
{
    public class ProductListVm
    {
        public IEnumerable<ProductLookupDto> Products { get; set; }
    }
}

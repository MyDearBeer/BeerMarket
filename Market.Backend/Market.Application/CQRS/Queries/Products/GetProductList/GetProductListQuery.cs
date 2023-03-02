using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public int? FactoryId { get; set; }

        public int? TypeId { get; set; }
        public int? Page { get; set; }

        public int? Limit { get; set; }
    }
}

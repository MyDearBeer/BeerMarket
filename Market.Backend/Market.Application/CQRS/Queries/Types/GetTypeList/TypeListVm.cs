using Market.Application.Products.Queries.GetProductList;
using Market.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Queries.GetTypeList
{
    public class TypeListVm
    {
        public IList<TypeListDto> Types { get; set; }
    }
}

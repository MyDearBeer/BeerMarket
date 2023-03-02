using Market.Application.Products.Queries.GetTypeList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Factories.GetFactoryList
{
    public class FactoryListVm
    {
        public IList<FactoryListDto> Factories { get; set; }
    }
}

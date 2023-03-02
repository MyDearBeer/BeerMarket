using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Factories.GetFactoryList
{
    public class GetFactoryListQuery : IRequest<FactoryListVm>
    {

    }
}

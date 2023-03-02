using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.DeleteFactory
{
    public class DeleteFactoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}

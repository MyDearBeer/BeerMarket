using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.CreateFactory
{
    public class CreateFactoryCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Img { get; set; }

    }
}

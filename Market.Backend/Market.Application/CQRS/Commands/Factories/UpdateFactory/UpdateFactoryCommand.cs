using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Factories.UpdateFactory
{
    public class UpdateFactoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Address { get; set; }

        public string Img { get; set; }
    }
}

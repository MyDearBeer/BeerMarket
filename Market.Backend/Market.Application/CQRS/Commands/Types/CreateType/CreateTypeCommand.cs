using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands.CreateType
{
    public class CreateTypeCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}

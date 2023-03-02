using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands.DeleteType
{
    public class DeleteTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}

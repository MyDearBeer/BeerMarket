using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.Basket.AddProduct
{
    public class AddProductCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
    }
}

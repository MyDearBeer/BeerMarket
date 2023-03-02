using AutoMapper;
using Market.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Queries.Products.GetBasketProductList
{
    public class GetBasketProductListQuery : IRequest<BasketProductListVm>
    {
        public Guid UserId { get; set; }
    }
}

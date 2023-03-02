using AutoMapper;
using Market.Application.Common.Mapping;
using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.CQRS.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Img { get; set; }

        public int FactoryId { get; set; }

        public int TypeId { get; set; }

        public string? Description { get; set; }

        public ICollection<ProductInfo>? Info { get; set; } = new List<ProductInfo>();

        // public TypeOfProduct? Type { get; set; }


    }
}

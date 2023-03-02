using Market.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Img { get; set; }

        public int FactoryId { get; set; }

        public int TypeId { get; set; }

        public string? Description { get; set; }

        public ICollection<ProductInfo>? Info { get; set; } = new List<ProductInfo>();
    }
}

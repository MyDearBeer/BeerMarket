using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal? Rating { get; set; }

        public int Price { get; set; }

        public string? Img { get; set; }

        public int FactoryId { get; set; }

        public int TypeId { get; set; }

        public string? Description { get; set; }

        public TypeOfProduct? Type { get; set; }

        public Factory? Factory { get; set; }

        public ICollection<ProductInfo>? Info { get; set; } = new List<ProductInfo>();

        public ICollection<BasketProduct>? BasketProducts { get; set; } = new List<BasketProduct>();

    }
}

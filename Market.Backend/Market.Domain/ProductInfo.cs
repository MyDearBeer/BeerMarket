using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain
{
    public class ProductInfo
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public Product? Product { get; set; }
    }
}

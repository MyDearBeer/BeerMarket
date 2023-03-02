using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Img { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

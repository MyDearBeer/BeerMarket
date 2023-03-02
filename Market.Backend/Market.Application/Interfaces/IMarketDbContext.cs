using Market.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Interfaces
{
    public interface IMarketDbContext
    {
        DbSet<Product> Products { get; set; }

        DbSet<TypeOfProduct> Types { get; set; }

        DbSet<Factory> Factories { get; set; }

        DbSet<ProductInfo> ProductInfos { get; set; }

        DbSet<BasketProduct> BasketProducts { get; set; }

        //DbSet<Factory> Factories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

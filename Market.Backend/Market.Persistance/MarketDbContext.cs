using Market.Application.Interfaces;
using Market.Domain;
using Market.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Persistance
{
    public class MarketDbContext:DbContext,IMarketDbContext
    {
       public DbSet<Product> Products { get; set; }
       public DbSet<TypeOfProduct> Types { get; set; }
       public DbSet<Factory> Factories { get; set; }
       public DbSet<ProductInfo> ProductInfos { get; set; }
       public DbSet<BasketProduct> BasketProducts { get; set; }

        public MarketDbContext(DbContextOptions<MarketDbContext> options)
            : base(options)
        {

            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new TypeConfiguration());
            builder.ApplyConfiguration(new FactoryConfiguration());
            builder.ApplyConfiguration(new ProductInfoConfiguration());
            builder.ApplyConfiguration(new BasketConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

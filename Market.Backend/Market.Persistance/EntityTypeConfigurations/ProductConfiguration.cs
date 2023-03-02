using Market.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Persistance.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product=>product.Id);
            builder.HasIndex(product=>product.Id).IsUnique();
            builder.HasIndex(product => product.Name).IsUnique();
            builder.HasOne(product => product.Type)
                .WithMany(type => type.Products)
                .HasForeignKey(product=>product.TypeId);
            builder.HasOne(product => product.Factory)
               .WithMany(type => type.Products)
               .HasForeignKey(product => product.FactoryId);



        }
    }
}

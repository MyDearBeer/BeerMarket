using Market.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Persistance.EntityTypeConfigurations
{
    public class ProductInfoConfiguration : IEntityTypeConfiguration<ProductInfo>
    {
        public void Configure(EntityTypeBuilder<ProductInfo> builder)
        {
            builder.HasKey(info => info.Id);
            builder.HasIndex(info => info.Id).IsUnique();
            builder.HasOne(info => info.Product)
                .WithMany(product => product.Info)
                .HasForeignKey(info => info.ProductId);

        }
    }
}

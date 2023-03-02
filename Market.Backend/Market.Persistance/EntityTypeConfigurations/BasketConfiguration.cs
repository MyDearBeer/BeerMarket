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
    public class BasketConfiguration : IEntityTypeConfiguration<BasketProduct>
    {
        public void Configure(EntityTypeBuilder<BasketProduct> builder)
        {
            builder.HasKey(bp => bp.Id);
            builder.HasIndex(bp => bp.Id).IsUnique();  
        }
    }
}

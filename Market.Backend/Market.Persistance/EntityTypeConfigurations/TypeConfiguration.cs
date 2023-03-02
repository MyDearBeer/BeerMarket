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
    public class TypeConfiguration : IEntityTypeConfiguration<TypeOfProduct>
    {
        public void Configure(EntityTypeBuilder<TypeOfProduct> builder)
        {
            builder.HasKey(type => type.Id);
            builder.HasIndex(type => type.Id).IsUnique();
            builder.HasIndex(type => type.Name).IsUnique();
        }
        }
}

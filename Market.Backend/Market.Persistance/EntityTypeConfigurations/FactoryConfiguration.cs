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
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder.HasKey(factory => factory.Id);
            builder.HasIndex(factory => factory.Id).IsUnique();
            builder.HasIndex(factory => factory.Name).IsUnique();
        }
    }
}

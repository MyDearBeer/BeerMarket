using Identity.Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Backend.Data
{
    public class AuthDbConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(acc => acc.Id);
            builder.HasIndex(acc => acc.Email).IsUnique();
            builder.HasData(
                new Account()
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@email.com",
                    Password = "admin",
                    Roles = "Admin"
                },
                new Account()
                {
                    Id = Guid.NewGuid(),
                    Email = "market@gmail.com",
                    Password = "12345",
                    Roles = "Admin"
                });
        }
    }
}

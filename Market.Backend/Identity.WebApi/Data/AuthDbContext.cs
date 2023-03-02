using Identity.Backend.Interfaces;
using Identity.Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Backend.Data
{
    public class AuthDbContext : DbContext, IAuthDbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthDbConfiguration());
            base.OnModelCreating(builder);
        }
    }
}

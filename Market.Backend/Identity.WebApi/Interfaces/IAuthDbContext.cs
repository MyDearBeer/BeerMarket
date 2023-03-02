using Identity.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Identity.Backend.Interfaces
{
    public interface IAuthDbContext
    {
        public DbSet<Account> Accounts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

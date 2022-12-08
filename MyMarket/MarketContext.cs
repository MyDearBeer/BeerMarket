using Microsoft.EntityFrameworkCore;
using MyMarket.Models;

namespace MyMarket
{


    using Microsoft.EntityFrameworkCore;
    public class MarketContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TypeItem> TypeItem { get; set; } = null!;

      public DbSet<Factory> Factory { get; set; } = null!;

        public DbSet<Item> Item { get; set; } = null!;

        public DbSet<ItemInfo> ItemInfo { get; set; } = null!;
        public MarketContext(DbContextOptions<MarketContext> options)
            : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //            new User { Id = 1, Name = "Tom", Email = "****", Password = "****", Role = "User" },
        //            new User { Id = 2, Name = "Bob", Email = "****", Password = "****", Role = "User" },
        //            new User { Id = 3, Name = "Sam", Email = "****", Password = "****", Role = "User" }
        //    );
        //}
    }
}
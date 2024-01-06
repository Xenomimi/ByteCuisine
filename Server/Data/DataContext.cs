using ByteCuisine.Client;
using ByteCuisine.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace ByteCuisine.Server.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Ingridient> Ingridients { get; set; }

        public DbSet<VirtualFridge> VirtualFridges { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.User_id);
            modelBuilder.Entity<Dish>().HasKey(x => x.Dish_id);
            modelBuilder.Entity<Ingridient>().HasKey(x => x.Ingridient_id);
            modelBuilder.Entity<VirtualFridge>().HasKey(x => x.VirtualFridge_id);
            base.OnModelCreating(modelBuilder);
        }
    }
}

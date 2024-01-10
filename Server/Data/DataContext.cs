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

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<DishIngredient> DishIngredients { get; set; }

        public DbSet<VirtualFridge> VirtualFridges { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasKey(d => d.Dish_id);
            modelBuilder.Entity<Ingredient>().HasKey(i => i.Ingredient_id);
            modelBuilder.Entity<Account>().HasKey(x => x.User_id);
            modelBuilder.Entity<VirtualFridge>().HasKey(x => x.VirtualFridge_id);

            // Konfiguracja klucza złożonego dla tabeli DishIngredient
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.Dish_Id, di.Ingredient_Id });

            // Konfiguracja relacji wiele-do-wielu między Dish i Ingredient poprzez DishIngredient
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.Dish_Id);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.Ingredient_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

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

        public DbSet<IngredientsInFridge> IngredientsInFridges { get; set; }

        public DbSet<Theme> Themes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dish>().HasKey(d => d.Dish_Id);
            modelBuilder.Entity<Ingredient>().HasKey(i => i.Ingredient_Id);
            modelBuilder.Entity<VirtualFridge>().HasKey(x => x.VirtualFridge_Id);
            modelBuilder.Entity<Account>().HasKey(x => x.User_Id);
            modelBuilder.Entity<Theme>().HasKey(x => x.Theme_Id);
            modelBuilder.Entity<IngredientsInFridge>().HasKey(x => x.IngredientsInFridge_Id);
            modelBuilder.Entity<DishIngredient>().HasKey(x => x.DishIngredient_Id);

            // Konfiguracja relacji jeden-do-wielu między VirtualFridge i Theme
            modelBuilder.Entity<VirtualFridge>()
                .HasOne(vf => vf.Theme)
                .WithMany(t => t.VirtualFridges)
                .HasForeignKey(vf => vf.Theme_Id);

            // Relacja IngredientsInFridge - Ingredient
            modelBuilder.Entity<IngredientsInFridge>()
                .HasOne(iif => iif.Ingredient)
                .WithMany(i => i.IngredientsInFridge)
                .HasForeignKey(iif => iif.Ingredient_Id);

            // Relacja IngredientsInFridge - VirtualFridge
            modelBuilder.Entity<IngredientsInFridge>()
                .HasOne(iif => iif.VirtualFridge)
                .WithMany(vf => vf.IngredientsInFridge)
                .HasForeignKey(iif => iif.VirtualFridge_Id);

            // Konfiguracja relacji jeden-do-jednego między Account i VirtualFridge
            modelBuilder.Entity<Account>()
                .HasOne(a => a.VirtualFridge)
                .WithOne(v => v.Account)
                .HasForeignKey<VirtualFridge>(v => v.VirtualFridge_Id);

            // Relacja DishIngredient - Dish
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.Dish_Id);

            // Relacja DishIngredient - Ingredient
            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.Ingredient_Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}

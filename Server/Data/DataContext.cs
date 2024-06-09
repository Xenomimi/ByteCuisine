using Microsoft.EntityFrameworkCore;
using ByteCuisine.Shared;

namespace ByteCuisine.Server.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<IngredientsInFridge> IngredientsInFridges { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<Account>().HasKey(a => a.User_Id);
            modelBuilder.Entity<Dish>().HasKey(d => d.Dish_Id);
            modelBuilder.Entity<Ingredient>().HasKey(i => i.Ingredient_Id);
            modelBuilder.Entity<DishIngredient>().HasKey(di => di.DishIngredient_Id);
            modelBuilder.Entity<IngredientsInFridge>().HasKey(iif => iif.IngredientsInFridge_Id);
            modelBuilder.Entity<Log>().HasKey(l => l.Id);
            modelBuilder.Entity<Category>().HasKey(c => c.Id);

            // Relationships
            modelBuilder.Entity<Dish>()
                .HasMany(d => d.DishIngredients)
                .WithOne(di => di.Dish)
                .HasForeignKey(di => di.Dish_Id);

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.DishIngredients)
                .WithOne(di => di.Ingredient)
                .HasForeignKey(di => di.Ingredient_Id);

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.IngredientsInFridge)
                .WithOne(iif => iif.Ingredient)
                .HasForeignKey(iif => iif.Ingredient_Id);

            modelBuilder.Entity<IngredientsInFridge>()
                .HasOne(iif => iif.Account)
                .WithMany(a => a.IngredientsInFridge)
                .HasForeignKey(iif => iif.AccountId);

            modelBuilder.Entity<Log>()
                .HasOne(l => l.Account)
                .WithMany(a => a.Logs)
                .HasForeignKey(l => l.AccountId);

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany(c => c.Dishes)
                .HasForeignKey(d => d.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

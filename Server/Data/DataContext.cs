using ByteCuisine.Shared;
using Microsoft.EntityFrameworkCore;
namespace ByteCuisine.Server.Controllers.Data
{
    public class DataContext : DbContext
    {
        //W ten sposób dodajecie modele, np.
        //public DbSet<Account> Accounts { get; set; }
        //potem w package manager console wywołujecie add-migration Nazwa_migracji i jeżeli stworzy się migracja w folderze Migrations
        //to wywołujecie w package manager console update-database i powinna się pojawić nowa tabela
        //

        public DbSet<Account> Accounts { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(x => x.User_id);
            base.OnModelCreating(modelBuilder);
        }
    }
}

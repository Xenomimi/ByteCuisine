using Microsoft.EntityFrameworkCore;
namespace ByteCuisine.Server.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        
    }
}

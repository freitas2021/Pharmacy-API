using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Models;


namespace Pharmacy.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) 
        { 
        }
                        
        public DbSet<Product> Products { get; set; }
    }
}

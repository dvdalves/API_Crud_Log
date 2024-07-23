using API_Crud_Log.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Crud_Log.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}

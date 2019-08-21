using Microsoft.EntityFrameworkCore;
using server.Models.Domain;

namespace server.Models.Database
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class DBProvider : DbContext
    {
        public DbSet<MarkerData> Markers { get; set; } = null!;

        public DBProvider()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=admin");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Table("markers")]
    public class MarkerData
    {
        [Key]
        public Guid marker_guid { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string? descr { get; set; }
        public int user_id { get; set; }
        
    }
}

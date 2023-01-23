using Microsoft.EntityFrameworkCore;

namespace AudioAPP.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Audio> Audios { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}

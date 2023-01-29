using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AudioAPP.Models;

namespace AudioAPP.Areas.Identity.Pages.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        //public DbSet<Priority> Priorities { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }
            );
            base.OnModelCreating(builder);
        }

    }
}

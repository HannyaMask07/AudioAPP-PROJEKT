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
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AudioAPP.Models;

namespace AudioAPP.Areas.Identity.Pages.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Audio> Audios { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}

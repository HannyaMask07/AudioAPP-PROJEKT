using Microsoft.EntityFrameworkCore;
using AudioAPP.Data.Repository.Repository;
using AudioAPP.Data.FileManager;
using Microsoft.AspNetCore.Identity;
using AudioAPP.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AudioAPP.Areas.Identity.Pages.Data;

namespace AudioAPP
{
    public class Program
    {

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("AudioAPPContextConnection") ?? throw new InvalidOperationException("Connection string 'AudioAPPContextConnection' not found.");

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(builder.Configuration["Data:Connection"]));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddTransient<IRepository, Repository>();
            builder.Services.AddTransient<IFileManager, FileManager>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;
            app.MapRazorPages();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
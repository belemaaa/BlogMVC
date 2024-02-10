using BlogMVC.Data;
using BlogMVC.Helpers;
using BlogMVC.Interfaces;
using BlogMVC.Repository;
using BlogMVC.Services;
using Microsoft.EntityFrameworkCore;

namespace BlogMVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IClubRepository, ClubRepository>();
        builder.Services.AddScoped<IRaceRepository, RaceRepository>();
        builder.Services.AddScoped<IPhotoService, PhotoService>();
        builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Data seeding
        if (args.Length == 1 && args[0].ToLower() == "seeddata")
        {
            Seed.SeedData(app);
        }

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

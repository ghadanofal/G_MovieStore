using G_MovieStoreMVC.Data;
using G_MovieStoreMVC.Models.Entity;
using G_MovieStoreMVC.Repositories.Abstract;
using G_MovieStoreMVC.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace G_MovieStoreMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
            builder.Services.AddScoped<IGenreService, GenreService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IMovieService, MovieService>();





            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("connect")));

            // For Identity  
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Simplify password requirements
                options.Password.RequireDigit = false; // No digit required
                options.Password.RequiredLength = 4; // Minimum length of 4
                options.Password.RequireNonAlphanumeric = false; // No special characters required
                options.Password.RequireUppercase = false; // No uppercase required
                options.Password.RequireLowercase = false; // No lowercase required
                options.Password.RequiredUniqueChars = 1; // At least 1 unique character
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();




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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Pim_Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pim_Web.Models;
using FastReport.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Pim_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            builder.Services.AddFastReport();

            builder.Services.AddSingleton(new WeatherApi("78debce39888f77a97ebf2eb37571524"));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("UrbanFarm");
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Usuarios/login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseFastReport();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuarios}/{action=Login}/{id?}");

            app.Run();
        }
    }
}

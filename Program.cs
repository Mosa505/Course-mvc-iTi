using Course_mvc_iTi.Models;
using Course_mvc_iTi.Repository;
using Microsoft.EntityFrameworkCore;

namespace Course_mvc_iTi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddScoped<ICourseRepository,CourseRepository>();

            builder.Services.AddDbContext<CourseDbContext>(OptionBuilder =>
            {

                OptionBuilder.UseSqlServer("Server = . ; Database = CourseDb ; Trusted_Connection = true");
            }
            );

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
            app.UseSession();

            app.MapControllerRoute(
                "test",
                "inst/{id:int?}", new
                {
                    Controller = "Instructor",
                    action= "Index"

                }
                );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
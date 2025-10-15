using Microsoft.EntityFrameworkCore;
using TesProgrammer.Interface;
using TesProgrammer.Models;
using TesProgrammer.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        builder.Services.AddDbContext<ApplicationContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(builder.Configuration.GetConnectionString("MySQLConnection"), serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

        builder.Services.AddScoped<IMataKuliah, MataKuliahServices>();
        builder.Services.AddScoped<IDosen, DosenServices>();


        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession();

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
        app.UseSession();
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Matakuliah}/{action=Index}/{id?}");

        app.Run();
    }
}
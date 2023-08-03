using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.Services;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        //builder.Services.addContext
        builder.Services.AddDbContext<AsyncInnContext>(options =>
        options.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection")));

        builder.Services.AddTransient<IHotel, HotelService>();
        var app = builder.Build();

        //app.MapGet("/", () => "Hello World!");


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        // This will look like this on the webpage
        // https://localhost:8001/Home/Index/Id
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

       


        app.Run();
    }
}

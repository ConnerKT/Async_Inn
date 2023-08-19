using System.Text.Json;
using System.Text.Json.Serialization;
using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Async_Inn;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        builder.Services.AddSwaggerGen(options =>
        {
            // Make sure get the "using Statement"
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Async Inn",
                Version = "v1",
            });
        });
        builder.Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<AsyncInnContext>();


        //builder.Services.addContext
        builder.Services.AddDbContext<AsyncInnContext>(options =>

        options.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection"))
        );

        var app = builder.Build();

        app.UseSwagger(options => {
            options.RouteTemplate = "/api/{documentName}/swagger.json";
        });
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
            options.RoutePrefix = "docs";
        });
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

using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;

namespace RestaurantAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add connection to SQLServer configuration
            builder.Services.AddDbContext<RestaurantDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDB")));

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddScoped<RestaurantSeeder>();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(System.Reflection.Assembly.GetExecutingAssembly());
            builder.Services.AddScoped<IRestaurantService, RestaurantService>();

            //NLog configuration
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            var app = builder.Build();

            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();

            seeder.Seed();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}

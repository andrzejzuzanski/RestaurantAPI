using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add connection to SQLite configuration
            builder.Services.AddDbContext<RestaurantDbContext>(
                options => options.UseSqlite(builder.Configuration.GetConnectionString("RestaurantDB")));

            // Add services to the container.
            builder.Services.AddAuthorization();


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}

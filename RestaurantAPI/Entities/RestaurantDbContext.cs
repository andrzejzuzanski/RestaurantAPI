using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Entities
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(mb =>
            {
                mb.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);
            });

            modelBuilder.Entity<Dish>(mb =>
            {
                mb.Property(d => d.Name)
                .IsRequired();
            });
        }
    }
}

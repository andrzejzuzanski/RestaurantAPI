using System.Runtime.CompilerServices;

namespace RestaurantAPI.Entities
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private List<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
            new Restaurant()
            {
                Name = "Test Name 1",
                Category = "Test Category 1",
                Description = "Test Description 1",
                ContactEmail = "test1@gmail.com",
                HasDelivery = true,
                Dishes = new List<Dish>
                {
                    new Dish()
                    {
                        Name = "Test dish 1",
                        Price = 10.30M
                    },
                    new Dish()
                    {
                        Name = "Test dish 2",
                        Price = 5.50M
                    }
                },
                Address = new Address()
                {
                    City = "Test City 1",
                    Street = "Test Street 1",
                    PostalCode = "11-111"
                }
            },
            new Restaurant()
            {
                Name = "Test Name 2",
                Category = "Test Category 2",
                Description = "Test Description 2",
                ContactEmail = "test2@gmail.com",
                HasDelivery = true,
                Dishes = new List<Dish>
                {
                    new Dish()
                    {
                        Name = "Test dish 3",
                        Price = 10.30M
                    },
                    new Dish()
                    {
                        Name = "Test dish 4",
                        Price = 5.50M
                    }
                },
                Address = new Address()
                {
                    City = "Test City 2",
                    Street = "Test Street 2",
                    PostalCode = "11-111"
                }
            }
            };
            return restaurants;
        }
    }
}

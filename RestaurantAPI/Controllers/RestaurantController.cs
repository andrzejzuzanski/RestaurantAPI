using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        // GET all restaurants
        [HttpGet]
        public ActionResult<List<RestaurantDto>> GetAll()
        {
            var restaurants = _service.GetAll();

            return Ok(restaurants);
        }

        // GET restaurant with specific ID 
        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var restaurant = _service.GetById(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // POST create restaurant
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto restaurantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var restaurantId = _service.Create(restaurantDto);

            return Created($"api/restaurants/{restaurantId}", null);
        }

        //DELETE Delete restaurant with specific ID
        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurant([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        //PUT Update restaurant with specific ID
        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated = _service.Update(id, updateDto);
            if (!isUpdated)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}

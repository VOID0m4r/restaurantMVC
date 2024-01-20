using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REST_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly CR_DBcontext _context;

        public RestaurantsController(CR_DBcontext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<restaurant>>> GetAllRestaurants()
        {
            return Ok(await _context.RestaurantSet.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<restaurant>>> AddRestaurant(restaurant res)
        {
            var _restaurant = await _context.RestaurantSet.FindAsync(res.RestaurantId);
            if (_restaurant != null)
                return BadRequest("restaurant already exist");
            _context.RestaurantSet.Add(res);
            await _context.SaveChangesAsync();
            return Ok(await _context.RestaurantSet.ToListAsync());
        }
    }
}

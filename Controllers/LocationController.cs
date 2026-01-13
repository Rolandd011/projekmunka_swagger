using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Context;
using MyApp.Backend.Models;

namespace MyApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly AppInMemoryDbContext _context;
        public LocationController(AppInMemoryDbContext context)
        {
            // <AppDbContext> HELYETT <AppInMemoryDbContext>-et kell írni!
            var options = new DbContextOptionsBuilder<AppInMemoryDbContext>()
                .UseInMemoryDatabase("MyApp_InMemory")
                .Options;

            _context = new AppInMemoryDbContext(options);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Locations.ToListAsync());
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            int count = await _context.Locations.CountAsync();
            return Ok(new { count });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Location? location = await _context.Locations.FirstOrDefaultAsync(s => s.Id == id);
            if (location is null)
                return NotFound();
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            return location is null ? NotFound() : Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Create([FromBody] Location newLocation)
        {
            _context.Locations.Add(newLocation);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Location input)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location is null) return NotFound();

            location.Name = input.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

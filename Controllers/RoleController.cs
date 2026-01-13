using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Context;
using MyApp.Backend.Models;

namespace MyApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : ControllerBase
    {
        private readonly AppInMemoryDbContext _context;
        public RoleController(AppInMemoryDbContext context)
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
            return Ok(await _context.Roles.ToListAsync());
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            int count = await _context.Roles.CountAsync();
            return Ok(new { count });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Role? role = await _context.Roles.FirstOrDefaultAsync(s => s.RoleId == id);
            if (role is null)
                return NotFound();
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _context.Roles.FindAsync(id);
            return location is null ? NotFound() : Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create([FromBody] Role newRole)
        {
            _context.Roles.Add(newRole);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role input)
        {
            var location = await _context.Roles.FindAsync(id);
            if (location is null) return NotFound();

            location.Name = input.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
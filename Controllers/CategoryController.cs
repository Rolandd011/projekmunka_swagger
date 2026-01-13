using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Context;
using MyApp.Backend.Models;

namespace MyApp.Backend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppInMemoryDbContext _context;
        public CategoryController(AppInMemoryDbContext context)
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
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            int count = await _context.Categories.CountAsync();
            return Ok(new { count });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (category is null)
                return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category is null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Create([FromBody] Category newCategory)
        {
            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category input)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is null) return NotFound();

            category.Name = input.Name;

            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

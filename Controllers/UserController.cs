using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Context;
using MyApp.Backend.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{

    private readonly AppInMemoryDbContext _context;
    public UsersController(AppInMemoryDbContext context)
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
        return Ok(await _context.Users.ToListAsync());
    }

    [HttpGet("count")]
    public async Task<IActionResult> Count()
    {
        int count = await _context.Users.CountAsync();
        return Ok(new { count });
    }

 
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
        if (user is null)
            return NotFound();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User newUser)
    {
        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User input)
    {
        var user = await _context.Users.FindAsync(id);
        if (user is null) return NotFound();

        user.Name = input.Name;
        user.Email = input.Email;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}





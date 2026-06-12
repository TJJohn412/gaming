using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gaming.Data;
using gaming.Models;

namespace gaming.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var list = await _db.Users.ToListAsync();
        return Ok(list);
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        if (id != user.Id)
            return BadRequest();

        var existing = await _db.Users.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.Name = user.Name;
        existing.Email = user.Email;
        existing.IsActive = user.IsActive;

        await _db.SaveChangesAsync();

        return Ok(user);
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var existing = await _db.Users.FindAsync(id);
        if (existing == null)
            return NotFound();

        _db.Users.Remove(existing);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}

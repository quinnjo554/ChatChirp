
using ChatChirp.Data;
using ChatChirp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatChirp.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserContext _context;
    public UserController(ILogger<UserController> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet(Name = "GetAllUsers")]
    public async Task<IActionResult> Get()
    {
        var user = new User()
        {
            Name = "Quinn",
            Email = "q@gmail.com",
            Points = 32,
        };
        _context.Add(user);
        await _context.SaveChangesAsync();

        // Retrieve users using the ToListAsync method
        var allUsers = await _context.Users.ToListAsync();

        return Ok(allUsers);
    }

}


using ChatChirp.Requests.UserRequest;
using ChatChirp.Data;
using ChatChirp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatChirp.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using ChatChirp.Exceptions.UserExceptions;

namespace ChatChirp.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly UserService _userService;

    public UserController(ILogger<UserController> logger, UserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost()]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        try
        {
            var response = await _userService.CreateUser(request);
            return CreatedAtAction(nameof(GetUser), new { id = response.Id }, response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        try
        {
            var response = _userService.GetUser(id);
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            _logger.LogError(ex, "Error getting user by ID");
            return StatusCode(404, "User not found");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user by ID");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("email/{email}")]
    public IActionResult GetUserByEmail(string email)
    {
        try
        {
            var response = _userService.GetUserByEmail(email);
            return Ok(response);
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user by email");
            return StatusCode(500, "Internal Server Error");
        }
    }
}

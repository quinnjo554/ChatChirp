
using ChatChirp.Request.UserRequest;
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


    [HttpPost()]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var user = new User(
        Guid.NewGuid(),
        request.Name,
        request.Email,
        request.Points,
        request.ScreenName,
        request.Description,
        request.Protected,
        request.Verified,
        request.FollowersCount,
        request.FriendsCount,
        request.FavouritesCount,
        request.StatusesCount,
        DateTime.UtcNow,
        request.ProfileBannerUrl,
        request.ProfileImageUrlHttps,
        request.DefaultProfile,
        request.DefaultProfileImage
    );

        _context.Add(user);
        await _context.SaveChangesAsync();

        var response = new UserResponse(
        user.Id,
        user.Name,
        user.Email,
        user.Points,
        user.ScreenName,
        user.Description,
        user.Protected,
        user.Verified,
        user.FollowersCount,
        user.FriendsCount,
        user.FavouritesCount,
        user.StatusesCount,
        user.CreatedAt,
        user.ProfileBannerUrl,
        user.ProfileImageUrlHttps,
        user.DefaultProfile,
        user.DefaultProfileImage
    );
        return CreatedAtAction(
         actionName: nameof(GetUser),
         routeValues: new { id = user.Id },
         value: response
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);

        return Ok(user);
    }

}

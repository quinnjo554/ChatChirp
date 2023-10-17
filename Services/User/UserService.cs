namespace ChatChirp.Services.User;

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ChatChirp.Data;
using ChatChirp.Models;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using ChatChirp.Requests.UserRequest;
using System.Net;

public class UserService
{
    private readonly ILogger<UserService> _logger;
    private readonly UserContext _context;

    public UserService(ILogger<UserService> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<UserResponse> CreateUser(CreateUserRequest request)
    {
        try
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (existingUser != null)
            {
                throw new Exception("User with the same email already exists.");
            }
            var user = new User(
                Guid.NewGuid(),
                request.Name,
                request.Email,
                request.HashedPassword,
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

            var response = MapToUserResponse(user);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user");
            throw;
        }
    }

    //For some reason Request.CreateUserRequest doenst work;
    //need to fix this
    public UserResponse GetUser(Guid id)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id) ?? throw new Exception();
            var response = MapToUserResponse(user);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user by ID");
            throw;
        }
    }

    public UserResponse GetUserByEmail(string email)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new Exception();
            }
            var response = MapToUserResponse(user);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting user by email");
            throw;
        }
    }

    private UserResponse MapToUserResponse(User user)
    {
        return new UserResponse(
            user.Id,
            user.Name,
            user.Email,
            user.HashedPassword,
            user.Points,
            user.ScreenName,
            user.Description ?? " ",
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
    }
}

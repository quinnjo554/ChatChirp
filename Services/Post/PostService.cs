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
using ChatChirp.Requests.PostRequest;
using System.Net;
using ChatChirp.Exceptions.UserExceptions;

public class PostService
{
    private readonly ILogger<UserService> _logger;
    private readonly UserContext _context;

    public PostService(ILogger<UserService> logger, UserContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<PostResponse> CreatePost(CreatePostRequest request)
    {
        try
        {
            var User = _context.Posts.FirstOrDefault(u => u.UserId == request.UserId) ?? throw new Exception("User Not Found.");
            var post = new Post(
                Guid.NewGuid(),
                request.Text,
                DateTime.UtcNow,
                request.Source,
                request.Truncated,
                request.InReplyToStatusId,
                request.InReplyToScreenName,
                request.InReplyToUserId,
                User.UserId,
                request.LikeCount,
                request.Points
            );
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            var response = MapToPostResponse(post);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating post");
            throw;
        }
    }

    public async Task<PostResponse> GetPost(Guid postId)
    {
        try
        {
            var post = await _context.Posts
                .Where(p => p.Id == postId)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                _logger.LogInformation($"Post not found for ID: {postId}");
                throw new NotFoundException($"Post not found for ID: {postId}");
            }

            var response = MapToPostResponse(post);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting post by ID: {postId}");
            throw;
        }
    }


    public async Task<PostResponse[]> GetAllPosts()
    {
        try
        {
            var posts = await _context.Posts.ToListAsync();
            var responses = posts.Select(MapToPostResponse).ToArray();
            return responses;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all posts");
            throw;
        }
    }

    public async Task<PostResponse[]> GetPostsByUserId(Guid userId)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var posts = await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
            var responses = posts.Select(MapToPostResponse).ToArray();
            return responses;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting posts by user ID");
            throw;
        }
    }


    public static PostResponse MapToPostResponse(Post post)
    {
        return new PostResponse(
            post.Id,
            post.UserId,
            post.Text,
            post.CreatedAt,
            post.Source,
            post.Truncated,
            post.InReplyToStatusId,
            post.InReplyToScreenName,
            post.InReplyToUserId,
            post.LikeCount,
            post.Points

        );
    }

}
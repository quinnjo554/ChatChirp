
using ChatChirp.Requests.UserRequest;
using ChatChirp.Data;
using ChatChirp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatChirp.Services.User;
using Microsoft.AspNetCore.Http.HttpResults;
using ChatChirp.Exceptions.UserExceptions;
using ChatChirp.Requests.PostRequest;

namespace ChatChirp.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly PostService _postService;


    public PostController(ILogger<PostController> logger, PostService postService, UserService userService)
    {
        _logger = logger;
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostRequest request)
    {
        try
        {
            var response = await _postService.CreatePost(request);
            return CreatedAtAction(nameof(GetPost), new { id = response.Id }, response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating post");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPost(Guid id)
    {
        try
        {
            var response = await _postService.GetPost(id);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting post");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        try
        {
            var response = await _postService.GetAllPosts();
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all posts");
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("user/{UserId}")]
    public async Task<IActionResult> GetPostByUserId(Guid UserId)
    {
        try
        {
            var response = await _postService.GetPostsByUserId(UserId);
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

}

using ChatChirp.Models;
using Microsoft.EntityFrameworkCore;
namespace ChatChirp.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }
    public DbSet<User> Users { get; }
}
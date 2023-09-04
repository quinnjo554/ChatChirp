using ChatChirp.Models;
using Microsoft.EntityFrameworkCore;
namespace ChatChirp.Data;
public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the unique constraint on the Email property
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        // Other configurations...

        base.OnModelCreating(modelBuilder);
    }
}
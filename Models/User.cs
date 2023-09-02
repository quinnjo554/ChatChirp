namespace ChatChirp.Models;
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Points { get; set; }

    public User(Guid id, string name, string email, int points)
    {
        // Enforce invariants
        Id = id;
        Name = name;
        Email = email;
        Points = points;
    }

    public User()
    {
    }
}
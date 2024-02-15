using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChatChirp.Models;
public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public double Points { get; set; }
    public string ScreenName { get; set; }
    public string? Description { get; set; }
    public bool Protected { get; set; } = false;
    public bool Verified { get; set; } = false;
    public int FollowersCount { get; set; }
    public int FriendsCount { get; set; }
    public int FavouritesCount { get; set; } //num of likes
    public int StatusesCount { get; set; } //num of post by this user
    public DateTime CreatedAt { get; set; }
    public string ProfileBannerUrl { get; set; }
    public string ProfileImageUrlHttps { get; set; }
    public bool DefaultProfile { get; set; }
    public bool DefaultProfileImage { get; set; }
    public User(
    Guid id,
    string name,
    string email,
    string hashedPassword,
    double points,
    string screenName,
    string description,
    bool @protected,
    bool verified,
    int followersCount,
    int friendsCount,
    int favouritesCount,
    int statusesCount,
    DateTime createdAt,
    string profileBannerUrl,
    string profileImageUrlHttps,
    bool defaultProfile,
    bool defaultProfileImage)
    {
        // Enforce invariants
        Id = id;
        Name = name;
        Email = email;
        HashedPassword = hashedPassword;
        Points = points;
        ScreenName = screenName;
        Description = description;
        Protected = @protected;
        Verified = verified;
        FollowersCount = followersCount;
        FriendsCount = friendsCount;
        FavouritesCount = favouritesCount;
        StatusesCount = statusesCount;
        CreatedAt = createdAt;
        ProfileBannerUrl = profileBannerUrl;
        ProfileImageUrlHttps = profileImageUrlHttps;
        DefaultProfile = defaultProfile;
        DefaultProfileImage = defaultProfileImage;
    }
}
namespace ChatChirp.Requests.UserRequest;

public record UserResponse(
       Guid Id,
       string Name,
       string Email,
       string HashedPassword,
       int Points,
       string ScreenName,
       string Description,
       bool Protected,
       bool Verified,
       int FollowersCount,
       int FriendsCount,
       int FavouritesCount,
       int StatusesCount,
       DateTime CreatedAt,
       string ProfileBannerUrl,
       string ProfileImageUrlHttps,
       bool DefaultProfile,
       bool DefaultProfileImage
   );
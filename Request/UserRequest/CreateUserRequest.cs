namespace ChatChirp.Request.UserRequest;

public record CreateUserRequest(
       string Name,
       string Email,
       int Points,
       string ScreenName,
       string Description,
       bool Protected,
       bool Verified,
       int FollowersCount,
       int FriendsCount,
       int ListedCount,
       int FavouritesCount,
       int StatusesCount,
       DateTime CreatedAt,
       string ProfileBannerUrl,
       string ProfileImageUrlHttps,
       bool DefaultProfile,
       bool DefaultProfileImage
   );
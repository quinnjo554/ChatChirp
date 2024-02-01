namespace ChatChirp.Requests.PostRequest
{
    public record CreatePostRequest(
        Guid UserId,
        string Text,
        DateTime CreatedAt,
        string Source,
        bool Truncated,
        long? InReplyToStatusId,
        string InReplyToScreenName,
        long? InReplyToUserId,
        long LikeCount,
        long Points
    );
}
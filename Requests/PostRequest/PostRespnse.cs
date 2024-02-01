namespace ChatChirp.Requests.PostRequest
{
    public record PostResponse(
        Guid UserId,
        Guid Id,
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
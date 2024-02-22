using System;
using System.ComponentModel.DataAnnotations;

namespace ChatChirp.Models
{
    public class Post
    {

        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; } // Represents the actual text of the status update
        public DateTime CreatedAt { get; set; }
        public string Source { get; set; }
        public bool Truncated { get; set; }
        public long? InReplyToStatusId { get; set; }
        public string InReplyToScreenName { get; set; }
        public long? InReplyToUserId { get; set; }
        public long LikeCount { get; set; }
        public double Points { get; set; }
        public string? ContentLinkUrl { get; set; }
        public string? VideoUrl { get; set; }
        // Constructor with parameters
        public Post(Guid id, string text, DateTime createdAt, string source, bool truncated,
                      long? inReplyToStatusId, string inReplyToScreenName, long? inReplyToUserId,
                      Guid userId, long likeCount, double points, string? contentLinkUrl, string? videoUrl)
        {
            Id = id;
            Text = text;
            CreatedAt = createdAt;
            Source = source;
            Truncated = truncated;
            InReplyToStatusId = inReplyToStatusId;
            InReplyToScreenName = inReplyToScreenName;
            InReplyToUserId = inReplyToUserId;
            UserId = userId;
            LikeCount = likeCount;
            Points = points;
            ContentLinkUrl = contentLinkUrl;
            VideoUrl = videoUrl;
        }

    }
}

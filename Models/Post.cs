using System;
using System.ComponentModel.DataAnnotations;

namespace ChatChirp.Models
{
    public class Post
    {

        // Foreign key property for the User entity
        public Guid UserId { get; set; }
        // Navigation property to the User entity
        public Guid Id { get; set; } // Using long instead of Guid as Twitter IDs are long integers
        public string Text { get; set; } // Represents the actual text of the status update
        public DateTime CreatedAt { get; set; }
        public string Source { get; set; }
        public bool Truncated { get; set; }
        public long? InReplyToStatusId { get; set; }
        public string InReplyToScreenName { get; set; }
        public long? InReplyToUserId { get; set; }
        public long LikeCount { get; set; }
        public long Points { get; set; }

        // Constructor with parameters
        public Post(Guid id, string text, DateTime createdAt, string source, bool truncated,
                      long? inReplyToStatusId, string inReplyToScreenName, long? inReplyToUserId,
                      Guid userId, // Change the parameter to accept the User's Id
                      long likeCount, long points)
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
        }

    }
}

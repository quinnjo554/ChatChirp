using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatChirp.Migrations
{
    /// <inheritdoc />
    public partial class posttableinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Source = table.Column<string>(type: "text", nullable: false),
                    Truncated = table.Column<bool>(type: "boolean", nullable: false),
                    InReplyToStatusId = table.Column<long>(type: "bigint", nullable: true),
                    InReplyToScreenName = table.Column<string>(type: "text", nullable: false),
                    InReplyToUserId = table.Column<long>(type: "bigint", nullable: true),
                    LikeCount = table.Column<long>(type: "bigint", nullable: false),
                    Points = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}

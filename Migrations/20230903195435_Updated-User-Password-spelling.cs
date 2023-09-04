using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatChirp.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserPasswordspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HasedPassword",
                table: "Users",
                newName: "HashedPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HashedPassword",
                table: "Users",
                newName: "HasedPassword");
        }
    }
}

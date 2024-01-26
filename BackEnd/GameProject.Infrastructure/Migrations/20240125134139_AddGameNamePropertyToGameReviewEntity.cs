using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameProject.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddGameNamePropertyToGameReviewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "GameReviews",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameName",
                table: "GameReviews");
        }
    }
}

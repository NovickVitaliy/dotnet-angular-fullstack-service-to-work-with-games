using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameProject.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddPlatformPropertyToGameEnity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "StartedGames",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "InProgressGames",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "FinishedGames",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "DesiredGames",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "AbandonedGames",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Platform",
                table: "StartedGames");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "InProgressGames");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "FinishedGames");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "DesiredGames");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "AbandonedGames");
        }
    }
}

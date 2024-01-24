using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameProject.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddRawgIDPropertyToBaseGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RawgId",
                table: "StartedGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RawgId",
                table: "InProgressGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RawgId",
                table: "FinishedGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RawgId",
                table: "DesiredGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RawgId",
                table: "AbandonedGames",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawgId",
                table: "StartedGames");

            migrationBuilder.DropColumn(
                name: "RawgId",
                table: "InProgressGames");

            migrationBuilder.DropColumn(
                name: "RawgId",
                table: "FinishedGames");

            migrationBuilder.DropColumn(
                name: "RawgId",
                table: "DesiredGames");

            migrationBuilder.DropColumn(
                name: "RawgId",
                table: "AbandonedGames");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameProject.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddGamesEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbandonedGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BackgroundImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbandonedGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinishedGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BackgroundImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InProgressGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BackgroundImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InProgressGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StartedGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BackgroundImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartedGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersAbandonedGames",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AbandonedGameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAbandonedGames", x => new { x.UserId, x.AbandonedGameId });
                    table.ForeignKey(
                        name: "FK_UsersAbandonedGames_AbandonedGames_AbandonedGameId",
                        column: x => x.AbandonedGameId,
                        principalTable: "AbandonedGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersAbandonedGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersFinishedGames",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FinishedGameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFinishedGames", x => new { x.UserId, x.FinishedGameId });
                    table.ForeignKey(
                        name: "FK_UsersFinishedGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersFinishedGames_FinishedGames_FinishedGameId",
                        column: x => x.FinishedGameId,
                        principalTable: "FinishedGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersInProgressGames",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    InProgressGameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInProgressGames", x => new { x.UserId, x.InProgressGameId });
                    table.ForeignKey(
                        name: "FK_UsersInProgressGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersInProgressGames_InProgressGames_InProgressGameId",
                        column: x => x.InProgressGameId,
                        principalTable: "InProgressGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersStartedGames",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartedGameId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersStartedGames", x => new { x.UserId, x.StartedGameId });
                    table.ForeignKey(
                        name: "FK_UsersStartedGames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersStartedGames_StartedGames_StartedGameId",
                        column: x => x.StartedGameId,
                        principalTable: "StartedGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersAbandonedGames_AbandonedGameId",
                table: "UsersAbandonedGames",
                column: "AbandonedGameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFinishedGames_FinishedGameId",
                table: "UsersFinishedGames",
                column: "FinishedGameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInProgressGames_InProgressGameId",
                table: "UsersInProgressGames",
                column: "InProgressGameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersStartedGames_StartedGameId",
                table: "UsersStartedGames",
                column: "StartedGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersAbandonedGames");

            migrationBuilder.DropTable(
                name: "UsersFinishedGames");

            migrationBuilder.DropTable(
                name: "UsersInProgressGames");

            migrationBuilder.DropTable(
                name: "UsersStartedGames");

            migrationBuilder.DropTable(
                name: "AbandonedGames");

            migrationBuilder.DropTable(
                name: "FinishedGames");

            migrationBuilder.DropTable(
                name: "InProgressGames");

            migrationBuilder.DropTable(
                name: "StartedGames");
        }
    }
}

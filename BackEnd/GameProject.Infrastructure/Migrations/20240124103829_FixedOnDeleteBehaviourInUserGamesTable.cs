using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameProject.Identity.Migrations
{
    /// <inheritdoc />
    public partial class FixedOnDeleteBehaviourInUserGamesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAbandonedGames_AbandonedGames_AbandonedGameId",
                table: "UsersAbandonedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAbandonedGames_AspNetUsers_UserId",
                table: "UsersAbandonedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDesiredGames_AspNetUsers_UserId",
                table: "UsersDesiredGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDesiredGames_DesiredGames_DesiredGameId",
                table: "UsersDesiredGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFinishedGames_AspNetUsers_UserId",
                table: "UsersFinishedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFinishedGames_FinishedGames_FinishedGameId",
                table: "UsersFinishedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInProgressGames_AspNetUsers_UserId",
                table: "UsersInProgressGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInProgressGames_InProgressGames_InProgressGameId",
                table: "UsersInProgressGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStartedGames_AspNetUsers_UserId",
                table: "UsersStartedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStartedGames_StartedGames_StartedGameId",
                table: "UsersStartedGames");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAbandonedGames_AbandonedGames_AbandonedGameId",
                table: "UsersAbandonedGames",
                column: "AbandonedGameId",
                principalTable: "AbandonedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAbandonedGames_AspNetUsers_UserId",
                table: "UsersAbandonedGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDesiredGames_AspNetUsers_UserId",
                table: "UsersDesiredGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDesiredGames_DesiredGames_DesiredGameId",
                table: "UsersDesiredGames",
                column: "DesiredGameId",
                principalTable: "DesiredGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFinishedGames_AspNetUsers_UserId",
                table: "UsersFinishedGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFinishedGames_FinishedGames_FinishedGameId",
                table: "UsersFinishedGames",
                column: "FinishedGameId",
                principalTable: "FinishedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInProgressGames_AspNetUsers_UserId",
                table: "UsersInProgressGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInProgressGames_InProgressGames_InProgressGameId",
                table: "UsersInProgressGames",
                column: "InProgressGameId",
                principalTable: "InProgressGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersStartedGames_AspNetUsers_UserId",
                table: "UsersStartedGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersStartedGames_StartedGames_StartedGameId",
                table: "UsersStartedGames",
                column: "StartedGameId",
                principalTable: "StartedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersAbandonedGames_AbandonedGames_AbandonedGameId",
                table: "UsersAbandonedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAbandonedGames_AspNetUsers_UserId",
                table: "UsersAbandonedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDesiredGames_AspNetUsers_UserId",
                table: "UsersDesiredGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDesiredGames_DesiredGames_DesiredGameId",
                table: "UsersDesiredGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFinishedGames_AspNetUsers_UserId",
                table: "UsersFinishedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersFinishedGames_FinishedGames_FinishedGameId",
                table: "UsersFinishedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInProgressGames_AspNetUsers_UserId",
                table: "UsersInProgressGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersInProgressGames_InProgressGames_InProgressGameId",
                table: "UsersInProgressGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStartedGames_AspNetUsers_UserId",
                table: "UsersStartedGames");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersStartedGames_StartedGames_StartedGameId",
                table: "UsersStartedGames");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAbandonedGames_AbandonedGames_AbandonedGameId",
                table: "UsersAbandonedGames",
                column: "AbandonedGameId",
                principalTable: "AbandonedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAbandonedGames_AspNetUsers_UserId",
                table: "UsersAbandonedGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDesiredGames_AspNetUsers_UserId",
                table: "UsersDesiredGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDesiredGames_DesiredGames_DesiredGameId",
                table: "UsersDesiredGames",
                column: "DesiredGameId",
                principalTable: "DesiredGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFinishedGames_AspNetUsers_UserId",
                table: "UsersFinishedGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFinishedGames_FinishedGames_FinishedGameId",
                table: "UsersFinishedGames",
                column: "FinishedGameId",
                principalTable: "FinishedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInProgressGames_AspNetUsers_UserId",
                table: "UsersInProgressGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInProgressGames_InProgressGames_InProgressGameId",
                table: "UsersInProgressGames",
                column: "InProgressGameId",
                principalTable: "InProgressGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersStartedGames_AspNetUsers_UserId",
                table: "UsersStartedGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersStartedGames_StartedGames_StartedGameId",
                table: "UsersStartedGames",
                column: "StartedGameId",
                principalTable: "StartedGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

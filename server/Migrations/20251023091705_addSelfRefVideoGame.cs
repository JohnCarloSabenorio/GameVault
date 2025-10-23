using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class addSelfRefVideoGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentGameId",
                table: "VideoGames",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_ParentGameId",
                table: "VideoGames",
                column: "ParentGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_VideoGames_ParentGameId",
                table: "VideoGames",
                column: "ParentGameId",
                principalTable: "VideoGames",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_VideoGames_ParentGameId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_ParentGameId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "ParentGameId",
                table: "VideoGames");
        }
    }
}

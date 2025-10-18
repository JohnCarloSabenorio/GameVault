using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class removedModeEngineColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameEngineId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "GameModeId",
                table: "VideoGames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "GameEngineId",
                table: "VideoGames",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GameModeId",
                table: "VideoGames",
                type: "bigint",
                nullable: true);
        }
    }
}

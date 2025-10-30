using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class addNewGameModeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameMode",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    ModeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMode", x => new { x.GameId, x.ModeId });
                    table.ForeignKey(
                        name: "FK_GameMode_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameMode_Mode_ModeId",
                        column: x => x.ModeId,
                        principalTable: "Mode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameMode_ModeId",
                table: "GameMode",
                column: "ModeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameMode");
        }
    }
}

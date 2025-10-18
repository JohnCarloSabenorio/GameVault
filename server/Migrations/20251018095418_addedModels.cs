using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class addedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameStatusId",
                table: "VideoGames",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "CoverImageId",
                table: "VideoGames",
                newName: "ImageId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "VideoGameGenres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "VideoGameGenres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Genres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Genres",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_FranchiseId",
                table: "VideoGames",
                column: "FranchiseId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_ImageId",
                table: "VideoGames",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_StatusId",
                table: "VideoGames",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Franchise_FranchiseId",
                table: "VideoGames",
                column: "FranchiseId",
                principalTable: "Franchise",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Status_ImageId",
                table: "VideoGames",
                column: "ImageId",
                principalTable: "Status",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Status_StatusId",
                table: "VideoGames",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Franchise_FranchiseId",
                table: "VideoGames");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Status_ImageId",
                table: "VideoGames");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Status_StatusId",
                table: "VideoGames");

            migrationBuilder.DropTable(
                name: "Franchise");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_FranchiseId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_ImageId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_StatusId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VideoGameGenres");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VideoGameGenres");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "VideoGames",
                newName: "GameStatusId");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "VideoGames",
                newName: "CoverImageId");
        }
    }
}

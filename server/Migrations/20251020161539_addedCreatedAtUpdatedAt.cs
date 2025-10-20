using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class addedCreatedAtUpdatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Status_ImageId",
                table: "VideoGames");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Image",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Image",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Image_ImageId",
                table: "VideoGames",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Image_ImageId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Status_ImageId",
                table: "VideoGames",
                column: "ImageId",
                principalTable: "Status",
                principalColumn: "Id");
        }
    }
}

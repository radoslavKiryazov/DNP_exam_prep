using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class pleasse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_albums_Title",
                table: "images");

            migrationBuilder.AddColumn<string>(
                name: "AlbumTitle",
                table: "images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_images_AlbumTitle",
                table: "images",
                column: "AlbumTitle");

            migrationBuilder.AddForeignKey(
                name: "FK_images_albums_AlbumTitle",
                table: "images",
                column: "AlbumTitle",
                principalTable: "albums",
                principalColumn: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_images_albums_AlbumTitle",
                table: "images");

            migrationBuilder.DropIndex(
                name: "IX_images_AlbumTitle",
                table: "images");

            migrationBuilder.DropColumn(
                name: "AlbumTitle",
                table: "images");

            migrationBuilder.AddForeignKey(
                name: "FK_images_albums_Title",
                table: "images",
                column: "Title",
                principalTable: "albums",
                principalColumn: "Title",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

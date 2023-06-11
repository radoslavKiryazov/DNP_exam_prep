using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    Title = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.Title);
                });

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Title = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    URI = table.Column<string>(type: "TEXT", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", nullable: false),
                    Album_title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Title);
                    table.ForeignKey(
                        name: "FK_images_albums_Title",
                        column: x => x.Title,
                        principalTable: "albums",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "albums");
        }
    }
}

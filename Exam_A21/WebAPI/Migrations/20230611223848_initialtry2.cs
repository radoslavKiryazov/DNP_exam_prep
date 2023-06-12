using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialtry2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Toy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    IsFavourite = table.Column<bool>(type: "INTEGER", nullable: false),
                    childName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toy", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Toy_Child_childName",
                        column: x => x.childName,
                        principalTable: "Child",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Toy_childName",
                table: "Toy",
                column: "childName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toy");

            migrationBuilder.DropTable(
                name: "Child");
        }
    }
}

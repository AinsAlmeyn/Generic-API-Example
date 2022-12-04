using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThisIsMyProve.DataAccess.Migrations
{
    public partial class Defaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "null", "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "null", "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    { 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "null", "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                    { 4, "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", "null", "Lorem ipsum dolor sit amet, consectetur adipiscing elit." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sliders");
        }
    }
}

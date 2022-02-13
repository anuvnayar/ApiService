using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiService.Data
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Age = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Age", "Name", "State" },
                values: new object[] { 1, "28", "Anu", "Rajasthan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}

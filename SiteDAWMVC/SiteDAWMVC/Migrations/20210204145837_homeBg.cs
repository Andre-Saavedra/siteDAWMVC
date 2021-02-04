using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class homeBg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeBg",
                columns: table => new
                {
                    HomeBgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    HomeBgNome = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeBg", x => x.HomeBgId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeBg");
        }
    }
}

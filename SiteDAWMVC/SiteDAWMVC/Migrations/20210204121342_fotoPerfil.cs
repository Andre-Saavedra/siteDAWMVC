using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class fotoPerfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    FotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FotoNome = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.FotoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");
        }
    }
}

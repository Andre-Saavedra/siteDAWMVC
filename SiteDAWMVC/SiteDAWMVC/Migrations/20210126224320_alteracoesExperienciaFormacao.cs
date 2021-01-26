using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class alteracoesExperienciaFormacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Experiencia",
                table: "FormacaoExperiencia");

            migrationBuilder.RenameColumn(
                name: "Formacao",
                table: "FormacaoExperiencia",
                newName: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "FormacaoExperiencia",
                newName: "Formacao");

            migrationBuilder.AddColumn<int>(
                name: "Experiencia",
                table: "FormacaoExperiencia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

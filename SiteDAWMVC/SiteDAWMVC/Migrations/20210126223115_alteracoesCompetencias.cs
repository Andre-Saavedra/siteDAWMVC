using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class alteracoesCompetencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "CompetenciasPessoais");

            migrationBuilder.RenameColumn(
                name: "OutrasLinguas",
                table: "CompetenciasPessoais",
                newName: "Observacoes");

            migrationBuilder.RenameColumn(
                name: "LinguaMaterna",
                table: "CompetenciasPessoais",
                newName: "Comptencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Observacoes",
                table: "CompetenciasPessoais",
                newName: "OutrasLinguas");

            migrationBuilder.RenameColumn(
                name: "Comptencia",
                table: "CompetenciasPessoais",
                newName: "LinguaMaterna");

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "CompetenciasPessoais",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

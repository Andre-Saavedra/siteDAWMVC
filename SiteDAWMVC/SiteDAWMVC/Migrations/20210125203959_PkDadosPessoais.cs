using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class PkDadosPessoais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DadosPessoaisId",
                table: "DadosPessoais",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DadosPessoais",
                table: "DadosPessoais",
                column: "DadosPessoaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DadosPessoais",
                table: "DadosPessoais");

            migrationBuilder.DropColumn(
                name: "DadosPessoaisId",
                table: "DadosPessoais");
        }
    }
}

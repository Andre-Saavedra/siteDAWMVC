using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class alteracoesExp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormacaoExperiencia_DadosPessoais_DadosPessoaisId",
                table: "FormacaoExperiencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormacaoExperiencia",
                table: "FormacaoExperiencia");

            migrationBuilder.RenameTable(
                name: "FormacaoExperiencia",
                newName: "Formacao");

            migrationBuilder.RenameIndex(
                name: "IX_FormacaoExperiencia_DadosPessoaisId",
                table: "Formacao",
                newName: "IX_Formacao_DadosPessoaisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Formacao",
                table: "Formacao",
                column: "FormacaoExperienciaId");

            migrationBuilder.CreateTable(
                name: "Experiencia",
                columns: table => new
                {
                    ExperienciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DadosPessoaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiencia", x => x.ExperienciaId);
                    table.ForeignKey(
                        name: "FK_Experiencia_DadosPessoais_DadosPessoaisId",
                        column: x => x.DadosPessoaisId,
                        principalTable: "DadosPessoais",
                        principalColumn: "DadosPessoaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiencia_DadosPessoaisId",
                table: "Experiencia",
                column: "DadosPessoaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formacao_DadosPessoais_DadosPessoaisId",
                table: "Formacao",
                column: "DadosPessoaisId",
                principalTable: "DadosPessoais",
                principalColumn: "DadosPessoaisId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formacao_DadosPessoais_DadosPessoaisId",
                table: "Formacao");

            migrationBuilder.DropTable(
                name: "Experiencia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Formacao",
                table: "Formacao");

            migrationBuilder.RenameTable(
                name: "Formacao",
                newName: "FormacaoExperiencia");

            migrationBuilder.RenameIndex(
                name: "IX_Formacao_DadosPessoaisId",
                table: "FormacaoExperiencia",
                newName: "IX_FormacaoExperiencia_DadosPessoaisId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormacaoExperiencia",
                table: "FormacaoExperiencia",
                column: "FormacaoExperienciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormacaoExperiencia_DadosPessoais_DadosPessoaisId",
                table: "FormacaoExperiencia",
                column: "DadosPessoaisId",
                principalTable: "DadosPessoais",
                principalColumn: "DadosPessoaisId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

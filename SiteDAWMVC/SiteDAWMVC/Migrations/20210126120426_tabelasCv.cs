using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class tabelasCv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetenciasDigitais",
                columns: table => new
                {
                    CompetenciasDigitaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Linguagem = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    DadosPessoaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciasDigitais", x => x.CompetenciasDigitaisId);
                    table.ForeignKey(
                        name: "FK_CompetenciasDigitais_DadosPessoais_DadosPessoaisId",
                        column: x => x.DadosPessoaisId,
                        principalTable: "DadosPessoais",
                        principalColumn: "DadosPessoaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetenciasPessoais",
                columns: table => new
                {
                    CompetenciasPessoaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinguaMaterna = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutrasLinguas = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    DadosPessoaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciasPessoais", x => x.CompetenciasPessoaisId);
                    table.ForeignKey(
                        name: "FK_CompetenciasPessoais_DadosPessoais_DadosPessoaisId",
                        column: x => x.DadosPessoaisId,
                        principalTable: "DadosPessoais",
                        principalColumn: "DadosPessoaisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciasDigitais_DadosPessoaisId",
                table: "CompetenciasDigitais",
                column: "DadosPessoaisId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciasPessoais_DadosPessoaisId",
                table: "CompetenciasPessoais",
                column: "DadosPessoaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciasDigitais");

            migrationBuilder.DropTable(
                name: "CompetenciasPessoais");
        }
    }
}

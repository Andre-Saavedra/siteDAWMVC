using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteDAWMVC.Migrations
{
    public partial class tst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "DadosPessoais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "DadosPessoais",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}

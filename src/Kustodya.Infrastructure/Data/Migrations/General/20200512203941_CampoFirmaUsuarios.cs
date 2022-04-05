using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CampoFirmaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Firma",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Firma",
                schema: "seguridad",
                table: "tblUsuarios");
        }
    }
}
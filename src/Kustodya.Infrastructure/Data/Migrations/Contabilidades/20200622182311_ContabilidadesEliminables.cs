using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class ContabilidadesEliminables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Segmento",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Regional",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "CentroCosto",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Segmento");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Regional");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "CentroCosto");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class PucsDefectoNoUnicos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Pucs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Movimientos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Contabilidades",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Pucs");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "DepuracionesContables");

            migrationBuilder.DropColumn(
                name: "Eliminado",
                schema: "Contabilidad",
                table: "Contabilidades");
        }
    }
}

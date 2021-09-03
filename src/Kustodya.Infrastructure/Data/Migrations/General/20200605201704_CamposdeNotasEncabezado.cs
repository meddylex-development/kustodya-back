using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CamposdeNotasEncabezado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoordinadorId",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElaboradoporId",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GerenteId",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterventorId",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "accionesRealizadas",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "anexos",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "disposicionesLegales",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "recomendaciones",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "situacionEncontrada",
                table: "Encabezado",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordinadorId",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "ElaboradoporId",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "GerenteId",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "InterventorId",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "accionesRealizadas",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "anexos",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "disposicionesLegales",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "recomendaciones",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "situacionEncontrada",
                table: "Encabezado");
        }
    }
}

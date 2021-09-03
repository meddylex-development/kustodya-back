using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class EncabezadoFichaTecnica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Encabezado");

            migrationBuilder.AddColumn<string>(
                name: "DescripcionFicha",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FichaTecnicaAprobada",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Folios",
                table: "Encabezado",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionFicha",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "FichaTecnicaAprobada",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "Folios",
                table: "Encabezado");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Encabezado",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

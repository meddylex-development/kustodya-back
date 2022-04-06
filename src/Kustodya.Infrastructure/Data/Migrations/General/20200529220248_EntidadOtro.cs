using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class EntidadOtro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionCampo",
                table: "EntidadOtro");

            migrationBuilder.DropColumn(
                name: "NombreCampo",
                table: "EntidadOtro");

            migrationBuilder.DropColumn(
                name: "ValorCampo",
                table: "EntidadOtro");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "EntidadOtro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "EntidadOtro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "EntidadOtro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Valor",
                table: "EntidadOtro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sucursal",
                table: "Entidad",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "EntidadOtro");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "EntidadOtro");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "EntidadOtro");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "EntidadOtro");

            migrationBuilder.DropColumn(
                name: "Sucursal",
                table: "Entidad");

            migrationBuilder.AddColumn<string>(
                name: "DescripcionCampo",
                table: "EntidadOtro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreCampo",
                table: "EntidadOtro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValorCampo",
                table: "EntidadOtro",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

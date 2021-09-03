using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CambioNombreColumnaSegmento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Segmento",
                table: "Encabezado");

            migrationBuilder.AddColumn<int>(
                name: "SegmentoId",
                table: "Encabezado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encabezado_SegmentoId",
                table: "Encabezado",
                column: "SegmentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encabezado_Segmento_SegmentoId",
                table: "Encabezado",
                column: "SegmentoId",
                principalTable: "Segmento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encabezado_Segmento_SegmentoId",
                table: "Encabezado");

            migrationBuilder.DropIndex(
                name: "IX_Encabezado_SegmentoId",
                table: "Encabezado");

            migrationBuilder.DropColumn(
                name: "SegmentoId",
                table: "Encabezado");

            migrationBuilder.AddColumn<int>(
                name: "Segmento",
                table: "Encabezado",
                type: "int",
                nullable: true);
        }
    }
}

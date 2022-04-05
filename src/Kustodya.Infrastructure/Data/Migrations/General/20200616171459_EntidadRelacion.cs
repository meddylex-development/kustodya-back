using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class EntidadRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Encabezado");

            migrationBuilder.DropColumn(
                name: "PadreId",
                table: "Entidad");

            migrationBuilder.AddColumn<int>(
                name: "EntidadRelacionId",
                table: "Entidad",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoRelacion",
                table: "Entidad",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_EntidadRelacionId",
                table: "Entidad",
                column: "EntidadRelacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidad_Entidad_EntidadRelacionId",
                table: "Entidad",
                column: "EntidadRelacionId",
                principalTable: "Entidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidad_Entidad_EntidadRelacionId",
                table: "Entidad");

            migrationBuilder.DropIndex(
                name: "IX_Entidad_EntidadRelacionId",
                table: "Entidad");

            migrationBuilder.DropColumn(
                name: "EntidadRelacionId",
                table: "Entidad");

            migrationBuilder.DropColumn(
                name: "TipoRelacion",
                table: "Entidad");

            migrationBuilder.AddColumn<int>(
                name: "PadreId",
                table: "Entidad",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Encabezado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaseDocumento = table.Column<int>(type: "int", nullable: false),
                    CoordinadorId = table.Column<int>(type: "int", nullable: true),
                    DescripcionFicha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElaboradoporId = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaElaboracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FichaTecnica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FichaTecnicaAprobada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Folios = table.Column<int>(type: "int", nullable: true),
                    GerenteId = table.Column<int>(type: "int", nullable: true),
                    InterventorId = table.Column<int>(type: "int", nullable: true),
                    SegmentoId = table.Column<int>(type: "int", nullable: true),
                    Subcuenta = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: false),
                    accionesRealizadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anexos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    disposicionesLegales = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    situacionEncontrada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encabezado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encabezado_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CentroBeneficioId = table.Column<int>(type: "int", nullable: false),
                    CodigoContable = table.Column<long>(type: "bigint", nullable: false),
                    Credito = table.Column<int>(type: "int", nullable: true),
                    Debito = table.Column<int>(type: "int", nullable: true),
                    DescripcionMovimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EncabezadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NitTercero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumComprobanteCierre = table.Column<long>(type: "bigint", nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciacionSoportes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAjuste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioCreacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalle_CentroBeneficio_CentroBeneficioId",
                        column: x => x.CentroBeneficioId,
                        principalTable: "CentroBeneficio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Encabezado_EncabezadoId",
                        column: x => x.EncabezadoId,
                        principalTable: "Encabezado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_CentroBeneficioId",
                table: "Detalle",
                column: "CentroBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_EncabezadoId",
                table: "Detalle",
                column: "EncabezadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Encabezado_SegmentoId",
                table: "Encabezado",
                column: "SegmentoId");
        }
    }
}

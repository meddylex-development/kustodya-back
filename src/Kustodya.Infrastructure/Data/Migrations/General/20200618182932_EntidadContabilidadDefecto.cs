using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class EntidadContabilidadDefecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "CentroBeneficio");

            migrationBuilder.DropTable(
                name: "Encabezado");

            migrationBuilder.AddColumn<Guid>(
                name: "ContabilidadPorDefectoId",
                table: "Entidad",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CentroCosto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(nullable: true),
                    SegmentoId = table.Column<int>(nullable: true),
                    RegionalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroCosto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroCosto_Regional_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "Regional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CentroCosto_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroCosto_Codigo",
                table: "CentroCosto",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCosto_RegionalId",
                table: "CentroCosto",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCosto_SegmentoId",
                table: "CentroCosto",
                column: "SegmentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CentroCosto");

            migrationBuilder.DropColumn(
                name: "ContabilidadPorDefectoId",
                table: "Entidad");

            migrationBuilder.CreateTable(
                name: "CentroBeneficio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegionalId = table.Column<int>(type: "int", nullable: true),
                    SegmentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentroBeneficio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CentroBeneficio_Regional_RegionalId",
                        column: x => x.RegionalId,
                        principalTable: "Regional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CentroBeneficio_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_CentroBeneficio_Codigo",
                table: "CentroBeneficio",
                column: "Codigo",
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CentroBeneficio_RegionalId",
                table: "CentroBeneficio",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroBeneficio_SegmentoId",
                table: "CentroBeneficio",
                column: "SegmentoId");

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

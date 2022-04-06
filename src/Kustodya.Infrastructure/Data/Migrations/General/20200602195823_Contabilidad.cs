using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class Contabilidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encabezado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaElaboracion = table.Column<DateTime>(nullable: false),
                    FichaTecnica = table.Column<string>(nullable: true),
                    Subcuenta = table.Column<int>(nullable: true),
                    Segmento = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ClaseDocumento = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    UsuarioCreacion = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encabezado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segmento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcuenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentroBeneficio",
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
                name: "Detalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncabezadoId = table.Column<int>(nullable: false),
                    CodigoContable = table.Column<int>(nullable: false),
                    DescripcionMovimiento = table.Column<string>(nullable: true),
                    CentroBeneficioId = table.Column<int>(nullable: false),
                    NitTercero = table.Column<string>(nullable: true),
                    Debito = table.Column<int>(nullable: false),
                    Credito = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: true),
                    NumComprobanteCierre = table.Column<long>(nullable: false),
                    ReferenciacionSoportes = table.Column<string>(nullable: true),
                    TipoAjuste = table.Column<string>(nullable: true),
                    UsuarioCreacion = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
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
                name: "IX_Regional_Codigo",
                table: "Regional",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Segmento_Codigo",
                table: "Segmento",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcuenta_Codigo",
                table: "Subcuenta",
                column: "Codigo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Subcuenta");

            migrationBuilder.DropTable(
                name: "CentroBeneficio");

            migrationBuilder.DropTable(
                name: "Encabezado");

            migrationBuilder.DropTable(
                name: "Regional");

            migrationBuilder.DropTable(
                name: "Segmento");
        }
    }
}

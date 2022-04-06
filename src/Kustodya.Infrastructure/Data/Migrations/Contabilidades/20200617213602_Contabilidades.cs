using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class ContabilidadesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Contabilidad");

            migrationBuilder.CreateTable(
                name: "Regional",
                schema: "Contabilidad",
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
                schema: "Contabilidad",
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
                name: "CentroCosto",
                schema: "Contabilidad",
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
                        principalSchema: "Contabilidad",
                        principalTable: "Regional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CentroCosto_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalSchema: "Contabilidad",
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepuracionContableId = table.Column<Guid>(nullable: false),
                    CodigoContable = table.Column<long>(nullable: false),
                    DescripcionMovimiento = table.Column<string>(nullable: true),
                    CentroBeneficioId = table.Column<int>(nullable: false),
                    NitTercero = table.Column<string>(nullable: true),
                    Debito = table.Column<int>(nullable: true),
                    Credito = table.Column<int>(nullable: true),
                    Referencia = table.Column<string>(nullable: true),
                    NumComprobanteCierre = table.Column<long>(nullable: false),
                    ReferenciacionSoportes = table.Column<string>(nullable: true),
                    TipoAjuste = table.Column<string>(nullable: true),
                    UsuarioCreacion = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    EntidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_CentroCosto_CentroBeneficioId",
                        column: x => x.CentroBeneficioId,
                        principalSchema: "Contabilidad",
                        principalTable: "CentroCosto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepuracionesContables",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FechaElaboracion = table.Column<DateTime>(nullable: false),
                    FichaTecnica = table.Column<string>(nullable: true),
                    DescripcionFicha = table.Column<string>(nullable: true),
                    FichaTecnicaAprobada = table.Column<string>(nullable: true),
                    Subcuenta = table.Column<int>(nullable: true),
                    SegmentoId = table.Column<int>(nullable: true),
                    Folios = table.Column<int>(nullable: true),
                    SituacionEncontrada = table.Column<string>(nullable: true),
                    DisposicionesLegales = table.Column<string>(nullable: true),
                    AccionesRealizadas = table.Column<string>(nullable: true),
                    Recomendaciones = table.Column<string>(nullable: true),
                    Anexos = table.Column<string>(nullable: true),
                    ElaboradoporId = table.Column<int>(nullable: true),
                    CoordinadorId = table.Column<int>(nullable: true),
                    GerenteId = table.Column<int>(nullable: true),
                    InterventorId = table.Column<int>(nullable: true),
                    ClaseDocumento = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    UsuarioCreacion = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    ContabilidadId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepuracionesContables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepuracionesContables_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalSchema: "Contabilidad",
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pucs",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ContabilidadId = table.Column<Guid>(nullable: false),
                    TipoContabilidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pucs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contabilidades",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    EntidadId = table.Column<int>(nullable: false),
                    CodigoPucDebitoMovimientoPorDefecto = table.Column<Guid>(nullable: false),
                    CodigoPucCreditoMovimientoPorDefecto = table.Column<Guid>(nullable: false),
                    ReferenciaMovimientoPorDefecto = table.Column<string>(nullable: true),
                    DescripcionMovimientoPorDefecto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contabilidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contabilidades_Pucs_CodigoPucCreditoMovimientoPorDefecto",
                        column: x => x.CodigoPucCreditoMovimientoPorDefecto,
                        principalSchema: "Contabilidad",
                        principalTable: "Pucs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contabilidades_Pucs_CodigoPucDebitoMovimientoPorDefecto",
                        column: x => x.CodigoPucDebitoMovimientoPorDefecto,
                        principalSchema: "Contabilidad",
                        principalTable: "Pucs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CentroCosto_RegionalId",
                schema: "Contabilidad",
                table: "CentroCosto",
                column: "RegionalId");

            migrationBuilder.CreateIndex(
                name: "IX_CentroCosto_SegmentoId",
                schema: "Contabilidad",
                table: "CentroCosto",
                column: "SegmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contabilidades_CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                column: "CodigoPucCreditoMovimientoPorDefecto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contabilidades_CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                column: "CodigoPucDebitoMovimientoPorDefecto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contabilidades_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "Contabilidades",
                columns: new[] { "EntidadId", "Codigo" },
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DepuracionesContables_ContabilidadId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                column: "ContabilidadId");

            migrationBuilder.CreateIndex(
                name: "IX_DepuracionesContables_SegmentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                column: "SegmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CentroBeneficioId",
                schema: "Contabilidad",
                table: "Movimientos",
                column: "CentroBeneficioId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_DepuracionContableId",
                schema: "Contabilidad",
                table: "Movimientos",
                column: "DepuracionContableId");

            migrationBuilder.CreateIndex(
                name: "IX_Pucs_ContabilidadId",
                schema: "Contabilidad",
                table: "Pucs",
                column: "ContabilidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_DepuracionesContables_DepuracionContableId",
                schema: "Contabilidad",
                table: "Movimientos",
                column: "DepuracionContableId",
                principalSchema: "Contabilidad",
                principalTable: "DepuracionesContables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepuracionesContables_Contabilidades_ContabilidadId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                column: "ContabilidadId",
                principalSchema: "Contabilidad",
                principalTable: "Contabilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pucs_Contabilidades_ContabilidadId",
                schema: "Contabilidad",
                table: "Pucs",
                column: "ContabilidadId",
                principalSchema: "Contabilidad",
                principalTable: "Contabilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contabilidades_Pucs_CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Contabilidades_Pucs_CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades");

            migrationBuilder.DropTable(
                name: "Movimientos",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "CentroCosto",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "DepuracionesContables",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "Regional",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "Segmento",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "Pucs",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "Contabilidades",
                schema: "Contabilidad");
        }
    }
}

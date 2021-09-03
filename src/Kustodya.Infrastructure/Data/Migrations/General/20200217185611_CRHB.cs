using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CRHB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Conceptos");

            migrationBuilder.CreateTable(
                name: "Cie10DiagnosticosConceptos",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cie10DiagnosticoConcepto = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Activo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cie10DiagnosticosConceptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conceptos",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Concepto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conceptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptosMedicos",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConceptoMedico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptosMedicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescripcionSecuelas",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionSecuelas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiologias",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Etiologia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiologias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinalidadTratamientos",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FinalidadTratamiento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalidadTratamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotaRemisiones",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NotaRemision = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaRemisiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlazoCorto",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plazo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlazoCorto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlazoLargo",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plazo = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlazoLargo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pronosticos",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pronostico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pronosticos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Remisiones",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Remision = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remisiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerapeuticaPosibles",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TerapeuticaPosible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerapeuticaPosibles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSecuelas",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoSecuela = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSecuelas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Afiliado",
                schema: "Incapacidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoAfiliacion = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: true),
                    Sexo = table.Column<int>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    PermisoTrabajo = table.Column<bool>(nullable: true),
                    Pensionado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConceptoRehabilitacion",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcetosMedicosId = table.Column<long>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    PacientesId = table.Column<int>(nullable: false),
                    DiagnosticoId = table.Column<long>(nullable: false),
                    DescripcionSecuelasId = table.Column<long>(nullable: false),
                    EsFarmacologico = table.Column<bool>(nullable: false),
                    EsQuirurgico = table.Column<bool>(nullable: false),
                    EsTerapiaFisica = table.Column<bool>(nullable: false),
                    EsTerapiaOcupaciona = table.Column<bool>(nullable: false),
                    EsFonoaudiologia = table.Column<bool>(nullable: false),
                    EsOtrosTratamientos = table.Column<bool>(nullable: false),
                    DescripcionTratamientos = table.Column<string>(nullable: true),
                    ResumenHistoriaClinica = table.Column<string>(nullable: true),
                    OtrosTramites = table.Column<string>(nullable: true),
                    Origen = table.Column<string>(nullable: true),
                    FinalidadTratamientosId = table.Column<long>(nullable: false),
                    PlazoCortoId = table.Column<long>(nullable: false),
                    PlazoLargoId = table.Column<long>(nullable: false),
                    RemisionesId = table.Column<long>(nullable: false),
                    ConceptosId = table.Column<long>(nullable: false),
                    NotaRemisionesId = table.Column<long>(nullable: false),
                    PronosticosId = table.Column<long>(nullable: false),
                    MedicosId = table.Column<long>(nullable: false),
                    EtiologiasId = table.Column<long>(nullable: false),
                    TipoSecuelasId = table.Column<long>(nullable: false),
                    PronosticoFavorable = table.Column<bool>(nullable: false),
                    DesPronosticoFavorable = table.Column<string>(nullable: true),
                    PronosticoDesfavorableAcumulados = table.Column<bool>(nullable: false),
                    DesPronosticoDesfavorableAcumulados = table.Column<string>(nullable: true),
                    PronosticoDesfavorable = table.Column<bool>(nullable: false),
                    DesPronosticoDesfavorable = table.Column<string>(nullable: true),
                    ConceptosMedicosId = table.Column<long>(nullable: true),
                    TblPacientesIIdpaciente = table.Column<int>(nullable: true),
                    TblDiagnosticosIIddiagnostico = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptoRehabilitacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_Conceptos_ConceptosId",
                        column: x => x.ConceptosId,
                        principalSchema: "Conceptos",
                        principalTable: "Conceptos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_ConceptosMedicos_ConceptosMedicosId",
                        column: x => x.ConceptosMedicosId,
                        principalSchema: "Conceptos",
                        principalTable: "ConceptosMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId",
                        column: x => x.DescripcionSecuelasId,
                        principalSchema: "Conceptos",
                        principalTable: "DescripcionSecuelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_Etiologias_EtiologiasId",
                        column: x => x.EtiologiasId,
                        principalSchema: "Conceptos",
                        principalTable: "Etiologias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_FinalidadTratamientos_FinalidadTratamientosId",
                        column: x => x.FinalidadTratamientosId,
                        principalSchema: "Conceptos",
                        principalTable: "FinalidadTratamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_NotaRemisiones_NotaRemisionesId",
                        column: x => x.NotaRemisionesId,
                        principalSchema: "Conceptos",
                        principalTable: "NotaRemisiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_PlazoCorto_PlazoCortoId",
                        column: x => x.PlazoCortoId,
                        principalSchema: "Conceptos",
                        principalTable: "PlazoCorto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId",
                        column: x => x.PlazoLargoId,
                        principalSchema: "Conceptos",
                        principalTable: "PlazoLargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_Pronosticos_PronosticosId",
                        column: x => x.PronosticosId,
                        principalSchema: "Conceptos",
                        principalTable: "Pronosticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_Remisiones_RemisionesId",
                        column: x => x.RemisionesId,
                        principalSchema: "Conceptos",
                        principalTable: "Remisiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_tblDiagnosticos_TblDiagnosticosIIddiagnostico",
                        column: x => x.TblDiagnosticosIIddiagnostico,
                        principalSchema: "administracion",
                        principalTable: "tblDiagnosticos",
                        principalColumn: "iIDDiagnostico",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_tblPacientes_TblPacientesIIdpaciente",
                        column: x => x.TblPacientesIIdpaciente,
                        principalSchema: "Incapacidades",
                        principalTable: "tblPacientes",
                        principalColumn: "iIDPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId",
                        column: x => x.TipoSecuelasId,
                        principalSchema: "Conceptos",
                        principalTable: "TipoSecuelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incapacidad",
                schema: "Incapacidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IpsNit = table.Column<string>(nullable: true),
                    FechaAfiliacion = table.Column<DateTime>(nullable: true),
                    Sexo = table.Column<int>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: true),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    FechaRadicacion = table.Column<DateTime>(nullable: true),
                    AfiliadoId = table.Column<int>(nullable: false),
                    Prorroga = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incapacidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incapacidad_Afiliado_AfiliadoId",
                        column: x => x.AfiliadoId,
                        principalSchema: "Incapacidades",
                        principalTable: "Afiliado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "ConceptosId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_ConceptosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "ConceptosMedicosId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "DescripcionSecuelasId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "EtiologiasId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_FinalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "FinalidadTratamientosId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "NotaRemisionesId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoCortoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoLargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_PronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PronosticosId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_RemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "RemisionesId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_TblDiagnosticosIIddiagnostico",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TblDiagnosticosIIddiagnostico");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_TblPacientesIIdpaciente",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TblPacientesIIdpaciente");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TipoSecuelasId");

            migrationBuilder.CreateIndex(
                name: "IX_Incapacidad_AfiliadoId",
                schema: "Incapacidades",
                table: "Incapacidad",
                column: "AfiliadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cie10DiagnosticosConceptos",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "ConceptoRehabilitacion",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "TerapeuticaPosibles",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "Incapacidad",
                schema: "Incapacidades");

            migrationBuilder.DropTable(
                name: "Conceptos",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "ConceptosMedicos",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "DescripcionSecuelas",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "Etiologias",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "FinalidadTratamientos",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "NotaRemisiones",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "PlazoCorto",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "PlazoLargo",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "Pronosticos",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "Remisiones",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "TipoSecuelas",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "Afiliado",
                schema: "Incapacidades");
        }
    }
}

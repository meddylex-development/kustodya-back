using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class QuitarMallaValidadora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cie10Correlacion");

            migrationBuilder.DropTable(
                name: "Incapacidad",
                schema: "Incapacidades");

            migrationBuilder.DropTable(
                name: "Afiliado",
                schema: "Incapacidades");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.AddColumn<bool>(
                name: "EsReporte",
                schema: "seguridad",
                table: "tblMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ReporteGroupId",
                schema: "seguridad",
                table: "tblMenu",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReporteId",
                schema: "seguridad",
                table: "tblMenu",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsReporte",
                schema: "seguridad",
                table: "tblMenu");

            migrationBuilder.DropColumn(
                name: "ReporteGroupId",
                schema: "seguridad",
                table: "tblMenu");

            migrationBuilder.DropColumn(
                name: "ReporteId",
                schema: "seguridad",
                table: "tblMenu");

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capitulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caracter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoCie10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiasMaxAcumulados = table.Column<int>(type: "int", nullable: false),
                    DiasMaxConsulta = table.Column<int>(type: "int", nullable: false),
                    EdadMaxima = table.Column<int>(type: "int", nullable: true),
                    EdadMinima = table.Column<int>(type: "int", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    TipoCie = table.Column<int>(type: "int", nullable: false),
                    TipoCieId = table.Column<int>(type: "int", nullable: true),
                    TituloCapitulo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Afiliado",
                schema: "Incapacidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActividadimpideRecuperacion = table.Column<bool>(type: "bit", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    AsisteAExamenes = table.Column<bool>(type: "bit", nullable: true),
                    AsisteATratamientos = table.Column<bool>(type: "bit", nullable: true),
                    CalificacionAtel = table.Column<bool>(type: "bit", nullable: true),
                    CalificacionPcl = table.Column<int>(type: "int", nullable: true),
                    ChrbDesfavorable = table.Column<bool>(type: "bit", nullable: true),
                    ConductasContrarias = table.Column<bool>(type: "bit", nullable: true),
                    DatosFalsos = table.Column<bool>(type: "bit", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Pensionado = table.Column<bool>(type: "bit", nullable: true),
                    PermisoTrabajo = table.Column<bool>(type: "bit", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: true),
                    TipoAfiliacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cie10Correlacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cie10Id = table.Column<int>(type: "int", nullable: false),
                    CorrelacionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cie10Correlacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cie10Correlacion_Diagnostico_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnostico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incapacidad",
                schema: "Incapacidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfiliadoId = table.Column<int>(type: "int", nullable: false),
                    AlteracionOFraude = table.Column<bool>(type: "bit", nullable: true),
                    DiagnosticoId = table.Column<int>(type: "int", nullable: false),
                    DobleCobro = table.Column<bool>(type: "bit", nullable: true),
                    FechaAfiliacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRadicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FraudeEnOtorgacion = table.Column<bool>(type: "bit", nullable: true),
                    IpsNit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prorroga = table.Column<bool>(type: "bit", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Incapacidad_Diagnostico_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnostico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cie10Correlacion_DiagnosticoId",
                table: "Cie10Correlacion",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incapacidad_AfiliadoId",
                schema: "Incapacidades",
                table: "Incapacidad",
                column: "AfiliadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incapacidad_DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad",
                column: "DiagnosticoId");
        }
    }
}

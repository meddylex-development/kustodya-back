using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CRHB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoCorto_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropTable(
                name: "Cie10DiagnosticosConceptos",
                schema: "Conceptos");

            migrationBuilder.DropTable(
                name: "TerapeuticaPosibles",
                schema: "Conceptos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlazoCorto",
                schema: "Conceptos",
                table: "PlazoCorto");

            migrationBuilder.RenameTable(
                name: "TipoSecuelas",
                schema: "Conceptos",
                newName: "TipoSecuelas");

            migrationBuilder.RenameTable(
                name: "Remisiones",
                schema: "Conceptos",
                newName: "Remisiones");

            migrationBuilder.RenameTable(
                name: "Pronosticos",
                schema: "Conceptos",
                newName: "Pronosticos");

            migrationBuilder.RenameTable(
                name: "PlazoLargo",
                schema: "Conceptos",
                newName: "PlazoLargo");

            migrationBuilder.RenameTable(
                name: "PlazoCorto",
                schema: "Conceptos",
                newName: "PLazoCorto");

            migrationBuilder.RenameTable(
                name: "NotaRemisiones",
                schema: "Conceptos",
                newName: "NotaRemisiones");

            migrationBuilder.RenameTable(
                name: "FinalidadTratamientos",
                schema: "Conceptos",
                newName: "FinalidadTratamientos");

            migrationBuilder.RenameTable(
                name: "Etiologias",
                schema: "Conceptos",
                newName: "Etiologias");

            migrationBuilder.RenameTable(
                name: "DescripcionSecuelas",
                schema: "Conceptos",
                newName: "DescripcionSecuelas");

            migrationBuilder.RenameTable(
                name: "ConceptosMedicos",
                schema: "Conceptos",
                newName: "ConceptosMedicos");

            migrationBuilder.RenameTable(
                name: "Conceptos",
                schema: "Conceptos",
                newName: "Conceptos");

            migrationBuilder.AddColumn<bool>(
                name: "AlteracionOFraude",
                schema: "Incapacidades",
                table: "Incapacidad",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DobleCobro",
                schema: "Incapacidades",
                table: "Incapacidad",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FraudeEnOtorgacion",
                schema: "Incapacidades",
                table: "Incapacidad",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActividadimpideRecuperacion",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AsisteAExamenes",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AsisteATratamientos",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalificacionPcl",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CalificacionAtel",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ChrbDesfavorable",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConductasContrarias",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DatosFalsos",
                schema: "Incapacidades",
                table: "Afiliado",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLazoCorto",
                table: "PLazoCorto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConceptoRehabilitacionId = table.Column<string>(nullable: true),
                    Cie10Id = table.Column<int>(nullable: false),
                    tblCie10IIdcie10 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostico_tblCIE10_tblCie10IIdcie10",
                        column: x => x.tblCie10IIdcie10,
                        principalSchema: "Incapacidades",
                        principalTable: "tblCIE10",
                        principalColumn: "iIDCIE10",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_DiagnosticoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "DiagnosticoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_tblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                column: "tblCie10IIdcie10");

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Diagnostico_DiagnosticoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "DiagnosticoId",
                principalSchema: "Conceptos",
                principalTable: "Diagnostico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_PLazoCorto_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoCortoId",
                principalTable: "PLazoCorto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Diagnostico_DiagnosticoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_PLazoCorto_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropTable(
                name: "Diagnostico",
                schema: "Conceptos");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_DiagnosticoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PLazoCorto",
                table: "PLazoCorto");

            migrationBuilder.DropColumn(
                name: "AlteracionOFraude",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropColumn(
                name: "DobleCobro",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropColumn(
                name: "FraudeEnOtorgacion",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropColumn(
                name: "ActividadimpideRecuperacion",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "AsisteAExamenes",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "AsisteATratamientos",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "CalificacionPcl",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "CalificacionAtel",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "ChrbDesfavorable",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "ConductasContrarias",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.DropColumn(
                name: "DatosFalsos",
                schema: "Incapacidades",
                table: "Afiliado");

            migrationBuilder.RenameTable(
                name: "TipoSecuelas",
                newName: "TipoSecuelas",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "Remisiones",
                newName: "Remisiones",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "Pronosticos",
                newName: "Pronosticos",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "PlazoLargo",
                newName: "PlazoLargo",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "PLazoCorto",
                newName: "PlazoCorto",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "NotaRemisiones",
                newName: "NotaRemisiones",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "FinalidadTratamientos",
                newName: "FinalidadTratamientos",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "Etiologias",
                newName: "Etiologias",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "DescripcionSecuelas",
                newName: "DescripcionSecuelas",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "ConceptosMedicos",
                newName: "ConceptosMedicos",
                newSchema: "Conceptos");

            migrationBuilder.RenameTable(
                name: "Conceptos",
                newName: "Conceptos",
                newSchema: "Conceptos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlazoCorto",
                schema: "Conceptos",
                table: "PlazoCorto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cie10DiagnosticosConceptos",
                schema: "Conceptos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<int>(nullable: false),
                    Cie10DiagnosticoConcepto = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cie10DiagnosticosConceptos", x => x.Id);
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

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoCorto_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoCortoId",
                principalSchema: "Conceptos",
                principalTable: "PlazoCorto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

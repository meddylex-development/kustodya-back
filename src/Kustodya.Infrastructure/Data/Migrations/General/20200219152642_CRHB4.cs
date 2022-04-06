using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CRHB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexo",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropColumn(
                name: "Etiologia",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "Etiologias",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "pronosticos",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.AddColumn<int>(
                name: "DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoCie10 = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Capitulo = table.Column<string>(nullable: true),
                    TituloCapitulo = table.Column<string>(nullable: true),
                    Caracter = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true),
                    Cie = table.Column<string>(nullable: true),
                    DiasMaxConsulta = table.Column<int>(nullable: false),
                    DiasMaxAcumulados = table.Column<int>(nullable: false),
                    TipoCieId = table.Column<int>(nullable: true),
                    Sexo = table.Column<int>(nullable: false),
                    EdadInferior = table.Column<int>(nullable: false),
                    EdadSuperior = table.Column<int>(nullable: false),
                    TipoCie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiologias",
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
                name: "Pronosticos",
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
                name: "Cie10Correlacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cie10Id = table.Column<int>(nullable: false),
                    CorrelacionId = table.Column<string>(nullable: true),
                    DiagnosticoId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Incapacidad_DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico",
                column: "EtiologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "EtiologiasId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "pronosticosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cie10Correlacion_DiagnosticoId",
                table: "Cie10Correlacion",
                column: "DiagnosticoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Etiologias_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "EtiologiasId",
                principalTable: "Etiologias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Pronosticos_pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "pronosticosId",
                principalTable: "Pronosticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Etiologias_EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico",
                column: "EtiologiaId",
                principalTable: "Etiologias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Incapacidad_Diagnostico_DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad",
                column: "DiagnosticoId",
                principalTable: "Diagnostico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Etiologias_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Pronosticos_pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Etiologias_EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropForeignKey(
                name: "FK_Incapacidad_Diagnostico_DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropTable(
                name: "Cie10Correlacion");

            migrationBuilder.DropTable(
                name: "Etiologias");

            migrationBuilder.DropTable(
                name: "Pronosticos");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropIndex(
                name: "IX_Incapacidad_DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropIndex(
                name: "IX_Diagnostico_EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "DiagnosticoId",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropColumn(
                name: "EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.AddColumn<int>(
                name: "Sexo",
                schema: "Incapacidades",
                table: "Incapacidad",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Etiologia",
                schema: "Conceptos",
                table: "Diagnostico",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Etiologias",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "pronosticos",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}

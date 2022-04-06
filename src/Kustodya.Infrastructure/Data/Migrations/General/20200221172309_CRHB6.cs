using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CRHB6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                schema: "Incapacidades",
                table: "Incapacidad");

            migrationBuilder.DropColumn(
                name: "DescripcionSecuelas",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "FechaIncapacidad",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "EdadInferior",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "EdadSuperior",
                table: "Diagnostico");

            migrationBuilder.AddColumn<long>(
                name: "DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "EdadMaxima",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdadMinima",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DescripcionSecuelas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConceptoRehabilitacionId = table.Column<string>(nullable: true),
                    TipoSecuelas = table.Column<byte>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Pronosticos = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionSecuelas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "DescripcionSecuelasId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "DescripcionSecuelasId",
                principalTable: "DescripcionSecuelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropTable(
                name: "DescripcionSecuelas");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "Etiologia",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "PlazoLargo",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "finalidadTratamientos",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "plazoCorto",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "EdadMaxima",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "EdadMinima",
                table: "Diagnostico");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "Incapacidades",
                table: "Incapacidad",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EtiologiaId",
                schema: "Conceptos",
                table: "Diagnostico",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescripcionSecuelas",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIncapacidad",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EdadInferior",
                table: "Diagnostico",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EdadSuperior",
                table: "Diagnostico",
                nullable: false,
                defaultValue: 0);

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
                name: "FinalidadTratamientos",
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
                name: "PLazoCorto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Plazo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLazoCorto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlazoLargo",
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
                name: "TipoSecuelas",
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
                name: "IX_ConceptoRehabilitacion_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoLargoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TipoSecuelasId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "finalidadTratamientosId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "plazoCortoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_pronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "pronosticosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Etiologias_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "EtiologiasId",
                principalTable: "Etiologias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoLargoId",
                principalTable: "PlazoLargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TipoSecuelasId",
                principalTable: "TipoSecuelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_FinalidadTratamientos_finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "finalidadTratamientosId",
                principalTable: "FinalidadTratamientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_PLazoCorto_plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "plazoCortoId",
                principalTable: "PLazoCorto",
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
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class CRHB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Conceptos_ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_ConceptosMedicos_ConceptosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Etiologias_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_FinalidadTratamientos_FinalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_NotaRemisiones_NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_PLazoCorto_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Pronosticos_PronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_Remisiones_RemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_tblDiagnosticos_TblDiagnosticosIIddiagnostico",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_tblCIE10_tblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Conceptos");

            migrationBuilder.DropTable(
                name: "ConceptosMedicos");

            migrationBuilder.DropTable(
                name: "DescripcionSecuelas");

            migrationBuilder.DropTable(
                name: "Etiologias");

            migrationBuilder.DropTable(
                name: "NotaRemisiones");

            migrationBuilder.DropTable(
                name: "Pronosticos");

            migrationBuilder.DropTable(
                name: "Remisiones");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_PronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_RemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropIndex(
                name: "IX_ConceptoRehabilitacion_TblDiagnosticosIIddiagnostico",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "ConcetosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "DesPronosticoDesfavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "DesPronosticoDesfavorableAcumulados",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "DesPronosticoFavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "MedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "PronosticoDesfavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "PronosticoDesfavorableAcumulados",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "PronosticoFavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "PronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "TblDiagnosticosIIddiagnostico",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.RenameColumn(
                name: "tblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                newName: "TblCie10IIdcie10");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnostico_tblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                newName: "IX_Diagnostico_TblCie10IIdcie10");

            migrationBuilder.RenameColumn(
                name: "PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "plazoCortoId");

            migrationBuilder.RenameColumn(
                name: "Origen",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "origen");

            migrationBuilder.RenameColumn(
                name: "FinalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "finalidadTratamientosId");

            migrationBuilder.RenameColumn(
                name: "RemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "empleadoId");

            migrationBuilder.RenameColumn(
                name: "OtrosTramites",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "DescripcionSecuelas");

            migrationBuilder.RenameColumn(
                name: "DescripcionTratamientos",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "DescripcionOtrosTramites");

            migrationBuilder.RenameColumn(
                name: "ConceptosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "TblEmpleadosIIdempleado");

            migrationBuilder.RenameIndex(
                name: "IX_ConceptoRehabilitacion_PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "IX_ConceptoRehabilitacion_plazoCortoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConceptoRehabilitacion_FinalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "IX_ConceptoRehabilitacion_finalidadTratamientosId");

            migrationBuilder.RenameIndex(
                name: "IX_ConceptoRehabilitacion_ConceptosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "IX_ConceptoRehabilitacion_TblEmpleadosIIdempleado");

            migrationBuilder.AddColumn<byte>(
                name: "Etiologia",
                schema: "Conceptos",
                table: "Diagnostico",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIncapacidad",
                schema: "Conceptos",
                table: "Diagnostico",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "origen",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<byte>(
                name: "Etiologias",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIncapacidad",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "pronosticos",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoLargoId",
                principalTable: "PlazoLargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_tblEmpleados_TblEmpleadosIIdempleado",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TblEmpleadosIIdempleado",
                principalSchema: "negocio",
                principalTable: "tblEmpleados",
                principalColumn: "iIDEmpleado",
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
                name: "FK_Diagnostico_tblCIE10_TblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                column: "TblCie10IIdcie10",
                principalSchema: "Incapacidades",
                principalTable: "tblCIE10",
                principalColumn: "iIDCIE10",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_tblEmpleados_TblEmpleadosIIdempleado",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_FinalidadTratamientos_finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ConceptoRehabilitacion_PLazoCorto_plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_tblCIE10_TblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "Etiologia",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "FechaIncapacidad",
                schema: "Conceptos",
                table: "Diagnostico");

            migrationBuilder.DropColumn(
                name: "Etiologias",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "FechaIncapacidad",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.DropColumn(
                name: "pronosticos",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion");

            migrationBuilder.RenameColumn(
                name: "TblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                newName: "tblCie10IIdcie10");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnostico_TblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                newName: "IX_Diagnostico_tblCie10IIdcie10");

            migrationBuilder.RenameColumn(
                name: "plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "PlazoCortoId");

            migrationBuilder.RenameColumn(
                name: "origen",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "Origen");

            migrationBuilder.RenameColumn(
                name: "finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "FinalidadTratamientosId");

            migrationBuilder.RenameColumn(
                name: "empleadoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "RemisionesId");

            migrationBuilder.RenameColumn(
                name: "TblEmpleadosIIdempleado",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "ConceptosMedicosId");

            migrationBuilder.RenameColumn(
                name: "DescripcionSecuelas",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "OtrosTramites");

            migrationBuilder.RenameColumn(
                name: "DescripcionOtrosTramites",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "DescripcionTratamientos");

            migrationBuilder.RenameIndex(
                name: "IX_ConceptoRehabilitacion_plazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "IX_ConceptoRehabilitacion_PlazoCortoId");

            migrationBuilder.RenameIndex(
                name: "IX_ConceptoRehabilitacion_finalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "IX_ConceptoRehabilitacion_FinalidadTratamientosId");

            migrationBuilder.RenameIndex(
                name: "IX_ConceptoRehabilitacion_TblEmpleadosIIdempleado",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                newName: "IX_ConceptoRehabilitacion_ConceptosMedicosId");

            migrationBuilder.AlterColumn<long>(
                name: "PlazoCortoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Origen",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "FinalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ConcetosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DesPronosticoDesfavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesPronosticoDesfavorableAcumulados",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesPronosticoFavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "PronosticoDesfavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PronosticoDesfavorableAcumulados",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PronosticoFavorable",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "PronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "TblDiagnosticosIIddiagnostico",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Conceptos",
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
                name: "NotaRemisiones",
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
                name: "Remisiones",
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

            migrationBuilder.CreateIndex(
                name: "IX_ConceptoRehabilitacion_ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "ConceptosId");

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
                name: "IX_ConceptoRehabilitacion_NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "NotaRemisionesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Conceptos_ConceptosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "ConceptosId",
                principalTable: "Conceptos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_ConceptosMedicos_ConceptosMedicosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "ConceptosMedicosId",
                principalTable: "ConceptosMedicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_DescripcionSecuelas_DescripcionSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "DescripcionSecuelasId",
                principalTable: "DescripcionSecuelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Etiologias_EtiologiasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "EtiologiasId",
                principalTable: "Etiologias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_FinalidadTratamientos_FinalidadTratamientosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "FinalidadTratamientosId",
                principalTable: "FinalidadTratamientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_NotaRemisiones_NotaRemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "NotaRemisionesId",
                principalTable: "NotaRemisiones",
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

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_PlazoLargo_PlazoLargoId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PlazoLargoId",
                principalTable: "PlazoLargo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Pronosticos_PronosticosId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "PronosticosId",
                principalTable: "Pronosticos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_Remisiones_RemisionesId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "RemisionesId",
                principalTable: "Remisiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_tblDiagnosticos_TblDiagnosticosIIddiagnostico",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TblDiagnosticosIIddiagnostico",
                principalSchema: "administracion",
                principalTable: "tblDiagnosticos",
                principalColumn: "iIDDiagnostico",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptoRehabilitacion_TipoSecuelas_TipoSecuelasId",
                schema: "Conceptos",
                table: "ConceptoRehabilitacion",
                column: "TipoSecuelasId",
                principalTable: "TipoSecuelas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_tblCIE10_tblCie10IIdcie10",
                schema: "Conceptos",
                table: "Diagnostico",
                column: "tblCie10IIdcie10",
                principalSchema: "Incapacidades",
                principalTable: "tblCIE10",
                principalColumn: "iIDCIE10",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "iIDSecuela",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "iIDRemision",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "iIDPronostico",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "iIDPlazoLargo",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "iIDPlazoCorto",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "iIDFinalidadTratamiento",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<long>(
                name: "iIDConcepto",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "iIDSecuela",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "iIDRemision",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "iIDPronostico",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "iIDPlazoLargo",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "iIDPlazoCorto",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "iIDFinalidadTratamiento",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<byte>(
                name: "iIDConcepto",
                schema: "Incapacidades",
                table: "tblConceptoRehabilitacion",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}

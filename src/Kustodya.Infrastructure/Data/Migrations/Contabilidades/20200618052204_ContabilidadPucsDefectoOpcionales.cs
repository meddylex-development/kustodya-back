using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class ContabilidadPucsDefectoOpcionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contabilidades_CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades");

            migrationBuilder.DropIndex(
                name: "IX_Contabilidades_CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades");

            migrationBuilder.AlterColumn<Guid>(
                name: "CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Contabilidades_CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                column: "CodigoPucCreditoMovimientoPorDefecto",
                // unique: true,
                filter: "[CodigoPucCreditoMovimientoPorDefecto] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contabilidades_CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                column: "CodigoPucDebitoMovimientoPorDefecto",
                // unique: true,
                filter: "[CodigoPucDebitoMovimientoPorDefecto] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Contabilidades_CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades");

            migrationBuilder.DropIndex(
                name: "IX_Contabilidades_CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades");

            migrationBuilder.AlterColumn<Guid>(
                name: "CodigoPucDebitoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CodigoPucCreditoMovimientoPorDefecto",
                schema: "Contabilidad",
                table: "Contabilidades",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

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
        }
    }
}

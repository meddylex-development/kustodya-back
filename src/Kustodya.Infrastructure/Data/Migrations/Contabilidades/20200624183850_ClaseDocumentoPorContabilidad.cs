using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class ClaseDocumentoPorContabilidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ClasesDocumento_EntidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.DropColumn(
                name: "EntidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.AddColumn<Guid>(
                name: "ContabilidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ClasesDocumento_ContabilidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                column: "ContabilidadId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ClasesDocumento_Contabilidades_ContabilidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                column: "ContabilidadId",
                principalSchema: "Contabilidad",
                principalTable: "Contabilidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClasesDocumento_Contabilidades_ContabilidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.DropIndex(
                name: "IX_ClasesDocumento_ContabilidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.DropColumn(
                name: "ContabilidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.AddColumn<int>(
                name: "EntidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClasesDocumento_EntidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                column: "EntidadId",
                unique: false);
        }
    }
}

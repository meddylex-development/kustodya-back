using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class ClaseDocumentoYTipoAjusteSinCodigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TiposAjuste_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "TiposAjuste");

            // migrationBuilder.DropIndex(
            //     name: "IX_Movimientos_TipoAjusteId",
            //     schema: "Contabilidad",
            //     table: "Movimientos");

            // migrationBuilder.DropIndex(
            //     name: "IX_DepuracionesContables_ClaseDocumentoId",
            //     schema: "Contabilidad",
            //     table: "DepuracionesContables");

            migrationBuilder.DropIndex(
                name: "IX_ClasesDocumento_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "Contabilidad",
                table: "TiposAjuste");

            migrationBuilder.DropColumn(
                name: "Codigo",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_TiposAjuste_EntidadId",
                schema: "Contabilidad",
                table: "TiposAjuste",
                column: "EntidadId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_TipoAjusteId",
                schema: "Contabilidad",
                table: "Movimientos",
                column: "TipoAjusteId");

            migrationBuilder.CreateIndex(
                name: "IX_DepuracionesContables_ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                column: "ClaseDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasesDocumento_EntidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                column: "EntidadId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TiposAjuste_EntidadId",
                schema: "Contabilidad",
                table: "TiposAjuste");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_TipoAjusteId",
                schema: "Contabilidad",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_DepuracionesContables_ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables");

            migrationBuilder.DropIndex(
                name: "IX_ClasesDocumento_EntidadId",
                schema: "Contabilidad",
                table: "ClasesDocumento");

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "Contabilidad",
                table: "TiposAjuste",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TiposAjuste_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "TiposAjuste",
                columns: new[] { "EntidadId", "Codigo" },
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Movimientos_TipoAjusteId",
            //     schema: "Contabilidad",
            //     table: "Movimientos",
            //     column: "TipoAjusteId",
            //     unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepuracionesContables_ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                column: "ClaseDocumentoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClasesDocumento_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                columns: new[] { "EntidadId", "Codigo" },
                unique: true,
                filter: "[Codigo] IS NOT NULL");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations.Contabilidades
{
    public partial class ClaseDocumento_TipoAjuste_Terceros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoAjuste",
                schema: "Contabilidad",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "ClaseDocumento",
                schema: "Contabilidad",
                table: "DepuracionesContables");

            migrationBuilder.AddColumn<Guid>(
                name: "TipoAjusteId",
                schema: "Contabilidad",
                table: "Movimientos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ClasesDocumento",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EntidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasesDocumento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tercero",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    TipoPersona = table.Column<int>(nullable: false),
                    TipoId = table.Column<int>(nullable: false),
                    NumeroId = table.Column<string>(nullable: true),
                    EntidadId = table.Column<int>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    DigitoVerificacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAjuste",
                schema: "Contabilidad",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Eliminado = table.Column<bool>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    EntidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAjuste", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClasesDocumento_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "ClasesDocumento",
                columns: new[] { "EntidadId", "Codigo" },
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tercero_TipoId_NumeroId_EntidadId",
                schema: "Contabilidad",
                table: "Tercero",
                columns: new[] { "TipoId", "NumeroId", "EntidadId" },
                unique: true,
                filter: "[NumeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TiposAjuste_EntidadId_Codigo",
                schema: "Contabilidad",
                table: "TiposAjuste",
                columns: new[] { "EntidadId", "Codigo" },
                unique: true,
                filter: "[Codigo] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DepuracionesContables_ClasesDocumento_ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                column: "ClaseDocumentoId",
                principalSchema: "Contabilidad",
                principalTable: "ClasesDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_TiposAjuste_TipoAjusteId",
                schema: "Contabilidad",
                table: "Movimientos",
                column: "TipoAjusteId",
                principalSchema: "Contabilidad",
                principalTable: "TiposAjuste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepuracionesContables_ClasesDocumento_ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_TiposAjuste_TipoAjusteId",
                schema: "Contabilidad",
                table: "Movimientos");

            migrationBuilder.DropTable(
                name: "ClasesDocumento",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "Tercero",
                schema: "Contabilidad");

            migrationBuilder.DropTable(
                name: "TiposAjuste",
                schema: "Contabilidad");

            migrationBuilder.DropColumn(
                name: "TipoAjusteId",
                schema: "Contabilidad",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "ClaseDocumentoId",
                schema: "Contabilidad",
                table: "DepuracionesContables");

            migrationBuilder.AddColumn<string>(
                name: "TipoAjuste",
                schema: "Contabilidad",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClaseDocumento",
                schema: "Contabilidad",
                table: "DepuracionesContables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

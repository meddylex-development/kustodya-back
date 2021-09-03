using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Reportes.Data.Migrations
{
    public partial class Primera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsosReporte");

            migrationBuilder.EnsureSchema(
                name: "Reportes");

            migrationBuilder.RenameTable(
                name: "Reportes",
                newName: "Reportes",
                newSchema: "Reportes");

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                schema: "Reportes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    EntidadId = table.Column<int>(nullable: false),
                    Solicitado = table.Column<DateTime>(nullable: false),
                    Aprobada = table.Column<bool>(nullable: false),
                    ReporteId = table.Column<Guid>(nullable: false),
                    WorkspaceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Reportes_ReporteId",
                        column: x => x.ReporteId,
                        principalSchema: "Reportes",
                        principalTable: "Reportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_ReporteId",
                schema: "Reportes",
                table: "Solicitudes",
                column: "ReporteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitudes",
                schema: "Reportes");

            migrationBuilder.RenameTable(
                name: "Reportes",
                schema: "Reportes",
                newName: "Reportes");

            migrationBuilder.CreateTable(
                name: "UsosReporte",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Aprobada = table.Column<bool>(type: "bit", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    ReporteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Solicitado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsosReporte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsosReporte_Reportes_ReporteId",
                        column: x => x.ReporteId,
                        principalTable: "Reportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsosReporte_ReporteId",
                table: "UsosReporte",
                column: "ReporteId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Reportes.Data.Migrations.Contabilidades
{
    public partial class Plantillas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkspaceId = table.Column<Guid>(nullable: false),
                    Horario_FechaInicio = table.Column<DateTimeOffset>(nullable: true),
                    Horario_FechaFin = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsosReporte",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsosReporte");

            migrationBuilder.DropTable(
                name: "Reportes");
        }
    }
}

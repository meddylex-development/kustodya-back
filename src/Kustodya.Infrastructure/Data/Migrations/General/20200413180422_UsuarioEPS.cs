using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class UsuarioEPS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuarioEPS",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TblEpsId = table.Column<long>(nullable: false),
                    TblUsuariosId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEPS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEPS_tblEPS_TblEpsId",
                        column: x => x.TblEpsId,
                        principalSchema: "negocio",
                        principalTable: "tblEPS",
                        principalColumn: "iIDEPS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEPS_tblUsuarios_TblUsuariosId",
                        column: x => x.TblUsuariosId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEPS_TblEpsId",
                schema: "seguridad",
                table: "UsuarioEPS",
                column: "TblEpsId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEPS_TblUsuariosId",
                schema: "seguridad",
                table: "UsuarioEPS",
                column: "TblUsuariosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioEPS",
                schema: "seguridad");
        }
    }
}

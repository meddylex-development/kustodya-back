using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class FormularioUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EsMedico",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "OtrosTratamientos",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistroMedico",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCorreos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCorreos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioCorreos_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRedesSociales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    RedSocial = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRedesSociales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRedesSociales_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTelefonos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    CodigoPais = table.Column<string>(nullable: true),
                    CodigoArea = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioTelefonos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefonos_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDirecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    CiudadId = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    Indicaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDirecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDirecciones_Ciudad_CiudadId",
                        column: x => x.CiudadId,
                        principalTable: "Ciudad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioDirecciones_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUsuarios_PerfilId",
                schema: "seguridad",
                table: "tblUsuarios",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCorreos_UsuarioId",
                table: "UsuarioCorreos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDirecciones_CiudadId",
                table: "UsuarioDirecciones",
                column: "CiudadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDirecciones_UsuarioId",
                table: "UsuarioDirecciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedesSociales_UsuarioId",
                table: "UsuarioRedesSociales",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefonos_UsuarioId",
                table: "UsuarioTelefonos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUsuarios_tblPerfiles_PerfilId",
                schema: "seguridad",
                table: "tblUsuarios",
                column: "PerfilId",
                principalSchema: "seguridad",
                principalTable: "tblPerfiles",
                principalColumn: "iIDPerfil",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsuarios_tblPerfiles_PerfilId",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropTable(
                name: "UsuarioCorreos");

            migrationBuilder.DropTable(
                name: "UsuarioDirecciones");

            migrationBuilder.DropTable(
                name: "UsuarioRedesSociales");

            migrationBuilder.DropTable(
                name: "UsuarioTelefonos");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_tblUsuarios_PerfilId",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "EsMedico",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "OtrosTratamientos",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "RegistroMedico",
                schema: "seguridad",
                table: "tblUsuarios");
        }
    }
}

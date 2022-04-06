using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kustodya.Infrastructure.Data.Migrations
{
    public partial class ModuloAdministrativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUsuarios_tblPerfiles_PerfilId",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropTable(
                name: "UsuarioClientes");

            migrationBuilder.DropTable(
                name: "UsuarioCorreos");

            migrationBuilder.DropTable(
                name: "UsuarioDirecciones");

            migrationBuilder.DropTable(
                name: "UsuarioRedesSociales");

            migrationBuilder.DropTable(
                name: "UsuarioTelefonos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Ciudad");

            migrationBuilder.DropIndex(
                name: "IX_tblUsuarios_PerfilId",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.AddColumn<bool>(
                name: "EsSuperAdmin",
                schema: "seguridad",
                table: "tblUsuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(nullable: false),
                    NumeroId = table.Column<string>(nullable: false),
                    TipoEntidad = table.Column<int>(nullable: true),
                    PadreId = table.Column<int>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    CorreoPrincipal = table.Column<string>(nullable: false),
                    DigitoVerificacion = table.Column<int>(nullable: false),
                    Regimen = table.Column<int>(nullable: false),
                    Naturaleza = table.Column<int>(nullable: false),
                    DiasContrasena = table.Column<int>(nullable: false),
                    NombreCompania = table.Column<string>(nullable: true),
                    CodigoExterno = table.Column<string>(nullable: true),
                    CodigoHabilitacion = table.Column<string>(nullable: true),
                    CodigoCIIU = table.Column<int>(nullable: false),
                    TipoSociedad = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCorreo",
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
                    table.PrimaryKey("PK_UsuarioCorreo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioCorreo_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioDireccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    DivipolaId = table.Column<long>(nullable: false),
                    TipoViaPrincipal = table.Column<int>(nullable: false),
                    NumeroViaPrincipal = table.Column<int>(nullable: false),
                    LetraViaPrincipal = table.Column<string>(nullable: true),
                    NumeroViaSecundaria = table.Column<int>(nullable: false),
                    LetraViaSecundaria = table.Column<string>(nullable: true),
                    DistanciaInterseccion = table.Column<int>(nullable: false),
                    Indicaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDireccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDireccion_tblDivipola_DivipolaId",
                        column: x => x.DivipolaId,
                        principalTable: "tblDivipola",
                        principalColumn: "IDDIVIPOLA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioDireccion_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRedSocial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    TipoRedSocial = table.Column<int>(nullable: false),
                    UsuariooLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRedSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRedSocial_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioTelefono",
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
                    table.PrimaryKey("PK_UsuarioTelefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioTelefono_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoId = table.Column<int>(nullable: false),
                    NumeroId = table.Column<string>(nullable: true),
                    EntidadId = table.Column<int>(nullable: false),
                    TipoCliente = table.Column<int>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    CorreoPrincipal = table.Column<string>(nullable: true),
                    DigitoVerificacion = table.Column<int>(nullable: true),
                    Regimen = table.Column<int>(nullable: false),
                    Naturaleza = table.Column<int>(nullable: false),
                    NombreCompania = table.Column<string>(nullable: true),
                    CodigoExterno = table.Column<string>(nullable: true),
                    CodigoHabilitacion = table.Column<string>(nullable: true),
                    CodigoCIIU = table.Column<int>(nullable: false),
                    TipoSociedad = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<int>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    UsuarioActualizacion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadCorreo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(nullable: false),
                    Correo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadCorreo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadCorreo_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadDireccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(nullable: false),
                    DivipolaId = table.Column<long>(nullable: false),
                    TipoViaPrincipal = table.Column<int>(nullable: false),
                    NumeroViaPrincipal = table.Column<int>(nullable: false),
                    LetraViaPrincipal = table.Column<string>(nullable: true),
                    NumeroViaSecundaria = table.Column<int>(nullable: false),
                    LetraViaSecundaria = table.Column<string>(nullable: true),
                    DistanciaInterseccion = table.Column<int>(nullable: false),
                    Indicaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadDireccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadDireccion_tblDivipola_DivipolaId",
                        column: x => x.DivipolaId,
                        principalTable: "tblDivipola",
                        principalColumn: "IDDIVIPOLA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadDireccion_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadOtro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(nullable: false),
                    NombreCampo = table.Column<string>(nullable: true),
                    ValorCampo = table.Column<string>(nullable: true),
                    DescripcionCampo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadOtro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadOtro_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadRedSocial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(nullable: false),
                    TipoRedSocial = table.Column<int>(nullable: false),
                    usuarioOLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadRedSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadRedSocial_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntidadId = table.Column<int>(nullable: false),
                    CodigoPais = table.Column<int>(nullable: false),
                    CodigoArea = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadTelefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadTelefono_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEntidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    EntidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEntidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEntidad_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEntidad_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteCorreo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    Correo = table.Column<int>(nullable: false),
                    Descripcion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteCorreo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteCorreo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteDireccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    DivipolaId = table.Column<long>(nullable: false),
                    TipoViaPrincipal = table.Column<int>(nullable: false),
                    NumeroViaPrincipal = table.Column<int>(nullable: false),
                    LetraViaPrincipal = table.Column<string>(nullable: true),
                    NumeroViaSecundaria = table.Column<int>(nullable: false),
                    LetraViaSecundaria = table.Column<string>(nullable: true),
                    DistanciaInterseccion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteDireccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteDireccion_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteDireccion_tblDivipola_DivipolaId",
                        column: x => x.DivipolaId,
                        principalTable: "tblDivipola",
                        principalColumn: "IDDIVIPOLA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteRedSocial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    TipoRedSocial = table.Column<int>(nullable: false),
                    UsuarioOLink = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteRedSocial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteRedSocial_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClienteTelefono",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    CodigoPais = table.Column<int>(nullable: false),
                    CodigoArea = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteTelefono", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteTelefono_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioCliente_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioCliente_tblUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "seguridad",
                        principalTable: "tblUsuarios",
                        principalColumn: "iIDUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEntidadPerfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioEntidadId = table.Column<int>(nullable: false),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEntidadPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEntidadPerfil_tblPerfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "seguridad",
                        principalTable: "tblPerfiles",
                        principalColumn: "iIDPerfil",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEntidadPerfil_UsuarioEntidad_UsuarioEntidadId",
                        column: x => x.UsuarioEntidadId,
                        principalTable: "UsuarioEntidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUsuarios_tEmail",
                schema: "seguridad",
                table: "tblUsuarios",
                column: "tEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EntidadId_TipoId_NumeroId",
                table: "Cliente",
                columns: new[] { "EntidadId", "TipoId", "NumeroId" },
                unique: true,
                filter: "[NumeroId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteCorreo_ClienteId",
                table: "ClienteCorreo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDireccion_ClienteId",
                table: "ClienteDireccion",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteDireccion_DivipolaId",
                table: "ClienteDireccion",
                column: "DivipolaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteRedSocial_ClienteId",
                table: "ClienteRedSocial",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteTelefono_ClienteId",
                table: "ClienteTelefono",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_TipoId_NumeroId_NombreCompania",
                table: "Entidad",
                columns: new[] { "TipoId", "NumeroId", "NombreCompania" },
                unique: true,
                filter: "[NombreCompania] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadCorreo_EntidadId",
                table: "EntidadCorreo",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadDireccion_DivipolaId",
                table: "EntidadDireccion",
                column: "DivipolaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadDireccion_EntidadId",
                table: "EntidadDireccion",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadOtro_EntidadId",
                table: "EntidadOtro",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadRedSocial_EntidadId",
                table: "EntidadRedSocial",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadTelefono_EntidadId",
                table: "EntidadTelefono",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCliente_ClienteId",
                table: "UsuarioCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCliente_UsuarioId",
                table: "UsuarioCliente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCorreo_UsuarioId",
                table: "UsuarioCorreo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDireccion_DivipolaId",
                table: "UsuarioDireccion",
                column: "DivipolaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDireccion_UsuarioId",
                table: "UsuarioDireccion",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEntidad_UsuarioId",
                table: "UsuarioEntidad",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEntidad_EntidadId_UsuarioId",
                table: "UsuarioEntidad",
                columns: new[] { "EntidadId", "UsuarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEntidadPerfil_PerfilId",
                table: "UsuarioEntidadPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEntidadPerfil_UsuarioEntidadId",
                table: "UsuarioEntidadPerfil",
                column: "UsuarioEntidadId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRedSocial_UsuarioId",
                table: "UsuarioRedSocial",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioTelefono_UsuarioId",
                table: "UsuarioTelefono",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteCorreo");

            migrationBuilder.DropTable(
                name: "ClienteDireccion");

            migrationBuilder.DropTable(
                name: "ClienteRedSocial");

            migrationBuilder.DropTable(
                name: "ClienteTelefono");

            migrationBuilder.DropTable(
                name: "EntidadCorreo");

            migrationBuilder.DropTable(
                name: "EntidadDireccion");

            migrationBuilder.DropTable(
                name: "EntidadOtro");

            migrationBuilder.DropTable(
                name: "EntidadRedSocial");

            migrationBuilder.DropTable(
                name: "EntidadTelefono");

            migrationBuilder.DropTable(
                name: "UsuarioCliente");

            migrationBuilder.DropTable(
                name: "UsuarioCorreo");

            migrationBuilder.DropTable(
                name: "UsuarioDireccion");

            migrationBuilder.DropTable(
                name: "UsuarioEntidadPerfil");

            migrationBuilder.DropTable(
                name: "UsuarioRedSocial");

            migrationBuilder.DropTable(
                name: "UsuarioTelefono");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "UsuarioEntidad");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropIndex(
                name: "IX_tblUsuarios_tEmail",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.DropColumn(
                name: "EsSuperAdmin",
                schema: "seguridad",
                table: "tblUsuarios");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                schema: "seguridad",
                table: "tblUsuarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCorreos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoPais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CiudadId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indicaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UsuarioClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioClientes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioClientes_tblUsuarios_UsuarioId",
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
                name: "IX_UsuarioClientes_ClienteId",
                table: "UsuarioClientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioClientes_UsuarioId",
                table: "UsuarioClientes",
                column: "UsuarioId");

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
    }
}

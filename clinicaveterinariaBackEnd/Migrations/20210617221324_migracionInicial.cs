using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace clinicaveterinariaBackEnd.Migrations
{
    public partial class migracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "examenlaboratorio",
                columns: table => new
                {
                    idLaboratorio = table.Column<int>(type: "int(11)", nullable: false),
                    Hemograma = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ECG = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Radiologia = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ecografia = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deshidratacion = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idLaboratorio);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    idMedia = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NombreMedia = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UrlMedia = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaIngresoMedia = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacionMedia = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idMedia);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "raza",
                columns: table => new
                {
                    idRaza = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombreRaza = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcionRaza = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idRaza);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "telefono",
                columns: table => new
                {
                    tipoTelefono = table.Column<int>(type: "int(1)", nullable: false),
                    numeroTelefono = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientesTelefonos = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    idEmpresa = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombreEmpresa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccionEmpresa = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefonoEmpresa = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rucEmpresa = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaMedia = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idEmpresa);
                    table.ForeignKey(
                        name: "fk_Empresa_Media1",
                        column: x => x.EmpresaMedia,
                        principalTable: "media",
                        principalColumn: "idMedia",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    idCliente = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cedulaCliente = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombreCliente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccionCliente = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    emailCliente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpresaCliente = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idCliente);
                    table.ForeignKey(
                        name: "fk_Cliente_Empresa1",
                        column: x => x.EmpresaCliente,
                        principalTable: "empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    idProducto = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    codigoventa = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descripcion = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precio = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: true),
                    precioventa = table.Column<decimal>(type: "decimal(6,4)", precision: 6, scale: 4, nullable: true),
                    Empresa = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idProducto);
                    table.ForeignKey(
                        name: "fk_Producto_Empresa1",
                        column: x => x.Empresa,
                        principalTable: "empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cedulaUsuario = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombresUsuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    apellidosUsuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    emailUsuario = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefonoUsuario = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cargoUsuario = table.Column<int>(type: "int(2)", nullable: true),
                    EmpresaUsuarios = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idUsuario);
                    table.ForeignKey(
                        name: "fk_Usuario_Empresa1",
                        column: x => x.EmpresaUsuarios,
                        principalTable: "empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "mascota",
                columns: table => new
                {
                    idPaciente = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nombrePaciente = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    especiePaciente = table.Column<int>(type: "int(1)", nullable: true),
                    sexoPaciente = table.Column<int>(type: "int(1)", nullable: true),
                    pesoPaciente = table.Column<decimal>(type: "decimal(2,2)", precision: 2, scale: 2, nullable: true),
                    RazaPaciente = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientePaciente = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alergias = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idPaciente);
                    table.ForeignKey(
                        name: "fk_Mascota_Cliente",
                        column: x => x.ClientePaciente,
                        principalTable: "cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Paciente_raza1",
                        column: x => x.RazaPaciente,
                        principalTable: "raza",
                        principalColumn: "idRaza",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "fichaclinica",
                columns: table => new
                {
                    idFichaClinica = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaIngresoFichaClinica = table.Column<DateTime>(type: "datetime", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cliente = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mascota = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExamenLaboratorio = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idFichaClinica);
                    table.ForeignKey(
                        name: "fk_FichaClinica_ExamenLaboratorio1",
                        column: x => x.ExamenLaboratorio,
                        principalTable: "examenlaboratorio",
                        principalColumn: "idLaboratorio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_FichaClinica_Paciente1",
                        column: x => x.Mascota,
                        principalTable: "mascota",
                        principalColumn: "idPaciente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_FichaClinica_Usuarios1",
                        column: x => x.Usuario,
                        principalTable: "usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "anamnesis",
                columns: table => new
                {
                    idAnamnesis = table.Column<int>(type: "int(11)", nullable: false),
                    liquido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    solido = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tratamiento = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    horas = table.Column<int>(type: "int(2)", nullable: true),
                    FichaClinica = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idAnamnesis);
                    table.ForeignKey(
                        name: "fk_Anamnesis_FichaClinica1",
                        column: x => x.FichaClinica,
                        principalTable: "fichaclinica",
                        principalColumn: "idFichaClinica",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_Anamnesis_FichaClinica1_idx",
                table: "anamnesis",
                column: "FichaClinica");

            migrationBuilder.CreateIndex(
                name: "cedulaCliente_UNIQUE",
                table: "cliente",
                column: "cedulaCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Cliente_Empresa1_idx",
                table: "cliente",
                column: "EmpresaCliente");

            migrationBuilder.CreateIndex(
                name: "fk_Empresa_Media1_idx",
                table: "empresa",
                column: "EmpresaMedia");

            migrationBuilder.CreateIndex(
                name: "fk_FichaClinica_ExamenLaboratorio1_idx",
                table: "fichaclinica",
                column: "ExamenLaboratorio");

            migrationBuilder.CreateIndex(
                name: "fk_FichaClinica_Paciente1_idx",
                table: "fichaclinica",
                column: "Mascota");

            migrationBuilder.CreateIndex(
                name: "fk_FichaClinica_Usuarios1_idx",
                table: "fichaclinica",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "fk_Paciente_raza1_idx",
                table: "mascota",
                column: "RazaPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_mascota_ClientePaciente",
                table: "mascota",
                column: "ClientePaciente");

            migrationBuilder.CreateIndex(
                name: "pesoPaciente_UNIQUE",
                table: "mascota",
                column: "pesoPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "sexoPaciente_UNIQUE",
                table: "mascota",
                column: "sexoPaciente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Producto_Empresa1_idx",
                table: "producto",
                column: "Empresa");

            migrationBuilder.CreateIndex(
                name: "fk_Usuario_Empresa1_idx",
                table: "usuarios",
                column: "EmpresaUsuarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anamnesis");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "telefono");

            migrationBuilder.DropTable(
                name: "fichaclinica");

            migrationBuilder.DropTable(
                name: "examenlaboratorio");

            migrationBuilder.DropTable(
                name: "mascota");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "raza");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "media");
        }
    }
}

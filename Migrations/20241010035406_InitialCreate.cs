using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Atenciones_Enfermeria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Derivaciones",
                columns: table => new
                {
                    Id_derivacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo_traslado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Destino = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derivaciones", x => x.Id_derivacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Efectores",
                columns: table => new
                {
                    Id_efector = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Localidad = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Programa = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Efectores", x => x.Id_efector);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id_paciente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DNI = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id_paciente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposPrestacion",
                columns: table => new
                {
                    Id_tipo_prestacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo_prestacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPrestacion", x => x.Id_tipo_prestacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_efector = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DNI = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Correo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hash_Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rol = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EfectorId_efector = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id_usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Efectores_EfectorId_efector",
                        column: x => x.EfectorId_efector,
                        principalTable: "Efectores",
                        principalColumn: "Id_efector");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prestaciones",
                columns: table => new
                {
                    Id_prestacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_tipo_prestacion = table.Column<int>(type: "int", nullable: false),
                    PrestacionNombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoPrestacionId_tipo_prestacion = table.Column<int>(type: "int", nullable: true),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestaciones", x => x.Id_prestacion);
                    table.ForeignKey(
                        name: "FK_Prestaciones_TiposPrestacion_TipoPrestacionId_tipo_prestacion",
                        column: x => x.TipoPrestacionId_tipo_prestacion,
                        principalTable: "TiposPrestacion",
                        principalColumn: "Id_tipo_prestacion");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Atenciones",
                columns: table => new
                {
                    Id_atencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_usuario = table.Column<int>(type: "int", nullable: false),
                    Id_paciente = table.Column<int>(type: "int", nullable: false),
                    Id_derivacion = table.Column<int>(type: "int", nullable: true),
                    Tipo_atencion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha_atencion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Hora_atencion = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    UsuarioId_usuario = table.Column<int>(type: "int", nullable: true),
                    PacienteId_paciente = table.Column<int>(type: "int", nullable: true),
                    DerivacionId_derivacion = table.Column<int>(type: "int", nullable: true),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atenciones", x => x.Id_atencion);
                    table.ForeignKey(
                        name: "FK_Atenciones_Derivaciones_DerivacionId_derivacion",
                        column: x => x.DerivacionId_derivacion,
                        principalTable: "Derivaciones",
                        principalColumn: "Id_derivacion");
                    table.ForeignKey(
                        name: "FK_Atenciones_Pacientes_PacienteId_paciente",
                        column: x => x.PacienteId_paciente,
                        principalTable: "Pacientes",
                        principalColumn: "Id_paciente");
                    table.ForeignKey(
                        name: "FK_Atenciones_Usuarios_UsuarioId_usuario",
                        column: x => x.UsuarioId_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id_usuario");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistrosAtencion",
                columns: table => new
                {
                    Id_registro_atencion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_atencion = table.Column<int>(type: "int", nullable: false),
                    Id_prestacion = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Borrado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AtencionId_atencion = table.Column<int>(type: "int", nullable: true),
                    PrestacionId_prestacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosAtencion", x => x.Id_registro_atencion);
                    table.ForeignKey(
                        name: "FK_RegistrosAtencion_Atenciones_AtencionId_atencion",
                        column: x => x.AtencionId_atencion,
                        principalTable: "Atenciones",
                        principalColumn: "Id_atencion");
                    table.ForeignKey(
                        name: "FK_RegistrosAtencion_Prestaciones_PrestacionId_prestacion",
                        column: x => x.PrestacionId_prestacion,
                        principalTable: "Prestaciones",
                        principalColumn: "Id_prestacion");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_DerivacionId_derivacion",
                table: "Atenciones",
                column: "DerivacionId_derivacion");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_PacienteId_paciente",
                table: "Atenciones",
                column: "PacienteId_paciente");

            migrationBuilder.CreateIndex(
                name: "IX_Atenciones_UsuarioId_usuario",
                table: "Atenciones",
                column: "UsuarioId_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Prestaciones_TipoPrestacionId_tipo_prestacion",
                table: "Prestaciones",
                column: "TipoPrestacionId_tipo_prestacion");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAtencion_AtencionId_atencion",
                table: "RegistrosAtencion",
                column: "AtencionId_atencion");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAtencion_PrestacionId_prestacion",
                table: "RegistrosAtencion",
                column: "PrestacionId_prestacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EfectorId_efector",
                table: "Usuarios",
                column: "EfectorId_efector");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosAtencion");

            migrationBuilder.DropTable(
                name: "Atenciones");

            migrationBuilder.DropTable(
                name: "Prestaciones");

            migrationBuilder.DropTable(
                name: "Derivaciones");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TiposPrestacion");

            migrationBuilder.DropTable(
                name: "Efectores");
        }
    }
}

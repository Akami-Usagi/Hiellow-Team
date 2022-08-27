using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogarGestor.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familiares",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registro = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecialidadMedica = table.Column<int>(type: "int", nullable: false),
                    Rethus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    DocumentoTipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatronesCrecimientoJoven",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicion = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatronesCrecimientoJoven", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatronesCrecimientoJoven_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SugerenciasCuidado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SugerenciasCuidado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SugerenciasCuidado_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Jovenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    longitud = table.Column<float>(type: "real", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FamiliarDesignadoId = table.Column<int>(type: "int", nullable: false),
                    PediatraId = table.Column<int>(type: "int", nullable: false),
                    NutricionistaId = table.Column<int>(type: "int", nullable: false),
                    HistoriaJovenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jovenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jovenes_Familiares_FamiliarDesignadoId",
                        column: x => x.FamiliarDesignadoId,
                        principalTable: "Familiares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Jovenes_Historias_HistoriaJovenId",
                        column: x => x.HistoriaJovenId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Jovenes_Medicos_NutricionistaId",
                        column: x => x.NutricionistaId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Jovenes_Medicos_PediatraId",
                        column: x => x.PediatraId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jovenes_FamiliarDesignadoId",
                table: "Jovenes",
                column: "FamiliarDesignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jovenes_HistoriaJovenId",
                table: "Jovenes",
                column: "HistoriaJovenId");

            migrationBuilder.CreateIndex(
                name: "IX_Jovenes_NutricionistaId",
                table: "Jovenes",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Jovenes_PediatraId",
                table: "Jovenes",
                column: "PediatraId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronesCrecimientoJoven_HistoriaId",
                table: "PatronesCrecimientoJoven",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SugerenciasCuidado_HistoriaId",
                table: "SugerenciasCuidado",
                column: "HistoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jovenes");

            migrationBuilder.DropTable(
                name: "PatronesCrecimientoJoven");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "SugerenciasCuidado");

            migrationBuilder.DropTable(
                name: "Familiares");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Historias");
        }
    }
}

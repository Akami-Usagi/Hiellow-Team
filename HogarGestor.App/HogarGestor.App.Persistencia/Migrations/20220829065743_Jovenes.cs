using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HogarGestor.App.Persistencia.Migrations
{
    public partial class Jovenes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FamiliarId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitud",
                table: "Personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "longitud",
                table: "Personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JovenId",
                table: "PatronesCrecimiento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JovenId",
                table: "AsignarMedicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_FamiliarId",
                table: "Personas",
                column: "FamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_HistoriaId",
                table: "Personas",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronesCrecimiento_JovenId",
                table: "PatronesCrecimiento",
                column: "JovenId");

            migrationBuilder.CreateIndex(
                name: "IX_AsignarMedicos_JovenId",
                table: "AsignarMedicos",
                column: "JovenId");

            migrationBuilder.AddForeignKey(
                name: "FK_AsignarMedicos_Personas_JovenId",
                table: "AsignarMedicos",
                column: "JovenId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatronesCrecimiento_Personas_JovenId",
                table: "PatronesCrecimiento",
                column: "JovenId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Historias_HistoriaId",
                table: "Personas",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_FamiliarId",
                table: "Personas",
                column: "FamiliarId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsignarMedicos_Personas_JovenId",
                table: "AsignarMedicos");

            migrationBuilder.DropForeignKey(
                name: "FK_PatronesCrecimiento_Personas_JovenId",
                table: "PatronesCrecimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Historias_HistoriaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_FamiliarId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_FamiliarId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_HistoriaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_PatronesCrecimiento_JovenId",
                table: "PatronesCrecimiento");

            migrationBuilder.DropIndex(
                name: "IX_AsignarMedicos_JovenId",
                table: "AsignarMedicos");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "FamiliarId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "longitud",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "JovenId",
                table: "PatronesCrecimiento");

            migrationBuilder.DropColumn(
                name: "JovenId",
                table: "AsignarMedicos");
        }
    }
}

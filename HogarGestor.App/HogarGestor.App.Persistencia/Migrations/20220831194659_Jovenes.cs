using System;
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

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Personas",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitud",
                table: "Personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Longitud",
                table: "Personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NutricionistaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PediatraId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JovenId",
                table: "PatronesCrecimiento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JovenId",
                table: "Historias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_FamiliarId",
                table: "Personas",
                column: "FamiliarId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_NutricionistaId",
                table: "Personas",
                column: "NutricionistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_PediatraId",
                table: "Personas",
                column: "PediatraId");

            migrationBuilder.CreateIndex(
                name: "IX_PatronesCrecimiento_JovenId",
                table: "PatronesCrecimiento",
                column: "JovenId");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_JovenId",
                table: "Historias",
                column: "JovenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Historias_Personas_JovenId",
                table: "Historias",
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
                name: "FK_Personas_Personas_FamiliarId",
                table: "Personas",
                column: "FamiliarId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_NutricionistaId",
                table: "Personas",
                column: "NutricionistaId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_PediatraId",
                table: "Personas",
                column: "PediatraId",
                principalTable: "Personas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historias_Personas_JovenId",
                table: "Historias");

            migrationBuilder.DropForeignKey(
                name: "FK_PatronesCrecimiento_Personas_JovenId",
                table: "PatronesCrecimiento");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_FamiliarId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_NutricionistaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_PediatraId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_FamiliarId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_NutricionistaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_PediatraId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_PatronesCrecimiento_JovenId",
                table: "PatronesCrecimiento");

            migrationBuilder.DropIndex(
                name: "IX_Historias_JovenId",
                table: "Historias");

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
                name: "FechaNacimiento",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "NutricionistaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PediatraId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "JovenId",
                table: "PatronesCrecimiento");

            migrationBuilder.DropColumn(
                name: "JovenId",
                table: "Historias");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetemsiarch.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Semestres_FiliereId",
                table: "Semestres");

            migrationBuilder.DeleteData(
                table: "Etudiants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Etudiants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Etudiants",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Examens");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Modules",
                newName: "ModuleId");

            migrationBuilder.RenameColumn(
                name: "NomFichier",
                table: "Archives",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Archives",
                newName: "ArchiveId");

            migrationBuilder.AlterColumn<int>(
                name: "SemestreId",
                table: "Modules",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Filieres",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModuleId",
                table: "Archives",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Archives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Semestres_FiliereId",
                table: "Semestres",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_SemestreId",
                table: "Modules",
                column: "SemestreId");

            migrationBuilder.CreateIndex(
                name: "IX_Archives_ModuleId",
                table: "Archives",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archives_Modules_ModuleId",
                table: "Archives",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Semestres_SemestreId",
                table: "Modules",
                column: "SemestreId",
                principalTable: "Semestres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archives_Modules_ModuleId",
                table: "Archives");

            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Semestres_SemestreId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Semestres_FiliereId",
                table: "Semestres");

            migrationBuilder.DropIndex(
                name: "IX_Modules_SemestreId",
                table: "Modules");

            migrationBuilder.DropIndex(
                name: "IX_Archives_ModuleId",
                table: "Archives");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Archives");

            migrationBuilder.RenameColumn(
                name: "ModuleId",
                table: "Modules",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Archives",
                newName: "NomFichier");

            migrationBuilder.RenameColumn(
                name: "ArchiveId",
                table: "Archives",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "SemestreId",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Filieres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Examens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ModuleId",
                table: "Archives",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "Id", "Email", "Nom", "Password", "Prenom" },
                values: new object[,]
                {
                    { 3, "jean.lemoine@example.com", "Lemoine", "Password789", "Jean" },
                    { 4, "lucie.dufresne@example.com", "Dufresne", "Password101", "Lucie" },
                    { 5, "clement.beaufort@example.com", "Beaufort", "Password112", "Clément" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Semestres_FiliereId",
                table: "Semestres",
                column: "FiliereId",
                unique: true);
        }
    }
}

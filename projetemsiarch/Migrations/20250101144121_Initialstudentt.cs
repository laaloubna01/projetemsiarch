using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projetemsiarch.Migrations
{
    /// <inheritdoc />
    public partial class Initialstudentt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filiere",
                table: "Etudiants");

            migrationBuilder.DropColumn(
                name: "Semestre",
                table: "Etudiants");

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "Id", "Email", "Nom", "Password", "Prenom" },
                values: new object[,]
                {
                    { 1, "pierre.dupont@example.com", "Dupont", "Password123", "Pierre" },
                    { 2, "sophie.martin@example.com", "Martin", "Password456", "Sophie" },
                    { 3, "jean.lemoine@example.com", "Lemoine", "Password789", "Jean" },
                    { 4, "lucie.dufresne@example.com", "Dufresne", "Password101", "Lucie" },
                    { 5, "clement.beaufort@example.com", "Beaufort", "Password112", "Clément" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etudiants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Etudiants",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.AddColumn<string>(
                name: "Filiere",
                table: "Etudiants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Semestre",
                table: "Etudiants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}

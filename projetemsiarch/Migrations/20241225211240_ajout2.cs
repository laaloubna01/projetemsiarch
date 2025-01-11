using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetemsiarch.Migrations
{
    /// <inheritdoc />
    public partial class ajout2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FiliereId",
                table: "Semestre",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Examens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SemestreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examens_Semestre_SemestreId",
                        column: x => x.SemestreId,
                        principalTable: "Semestre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Semestre_FiliereId",
                table: "Semestre",
                column: "FiliereId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examens_SemestreId",
                table: "Examens",
                column: "SemestreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Semestre_Filiere_FiliereId",
                table: "Semestre",
                column: "FiliereId",
                principalTable: "Filiere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Semestre_Filiere_FiliereId",
                table: "Semestre");

            migrationBuilder.DropTable(
                name: "Examens");

            migrationBuilder.DropIndex(
                name: "IX_Semestre_FiliereId",
                table: "Semestre");

            migrationBuilder.AlterColumn<string>(
                name: "FiliereId",
                table: "Semestre",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

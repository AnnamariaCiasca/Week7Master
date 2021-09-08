using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Week7Master.RepositoryEF.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corso",
                columns: table => new
                {
                    CodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corso", x => x.CodiceCorso);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Studente_Corso_CodiceCorso",
                        column: x => x.CodiceCorso,
                        principalTable: "Corso",
                        principalColumn: "CodiceCorso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lezione",
                columns: table => new
                {
                    IdLezione = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    Aula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDocente = table.Column<int>(type: "int", nullable: false),
                    CodiceCorso = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lezione", x => x.IdLezione);
                    table.ForeignKey(
                        name: "FK_Lezione_Corso_CodiceCorso",
                        column: x => x.CodiceCorso,
                        principalTable: "Corso",
                        principalColumn: "CodiceCorso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lezione_Docente_IdDocente",
                        column: x => x.IdDocente,
                        principalTable: "Docente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lezione_CodiceCorso",
                table: "Lezione",
                column: "CodiceCorso");

            migrationBuilder.CreateIndex(
                name: "IX_Lezione_IdDocente",
                table: "Lezione",
                column: "IdDocente");

            migrationBuilder.CreateIndex(
                name: "IX_Studente_CodiceCorso",
                table: "Studente",
                column: "CodiceCorso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lezione");

            migrationBuilder.DropTable(
                name: "Studente");

            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Corso");
        }
    }
}

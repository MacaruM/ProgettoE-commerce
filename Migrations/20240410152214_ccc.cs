using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace massimo.macaru._5i.FORMDotNetMVC.Migrations
{
    /// <inheritdoc />
    public partial class ccc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prodotti");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utente",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "IdUtente",
                table: "Utente");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "Utente",
                newName: "DataNascita");

            migrationBuilder.AddColumn<int>(
                name: "UtenteId",
                table: "Utente",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Cognome",
                table: "Utente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Utente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Utente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeUtente",
                table: "Utente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sesso",
                table: "Utente",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utente",
                table: "Utente",
                column: "UtenteId");

            migrationBuilder.CreateTable(
                name: "Carrello",
                columns: table => new
                {
                    CarrelloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Articolo = table.Column<string>(type: "TEXT", nullable: true),
                    Quantita = table.Column<int>(type: "INTEGER", nullable: false),
                    Prezzo = table.Column<double>(type: "REAL", nullable: false),
                    Immagine = table.Column<string>(type: "TEXT", nullable: true),
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrello", x => x.CarrelloId);
                    table.ForeignKey(
                        name: "FK_Carrello_Utente_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utente",
                        principalColumn: "UtenteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrello_UtenteId",
                table: "Carrello",
                column: "UtenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrello");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Utente",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "UtenteId",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Cognome",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "NomeUtente",
                table: "Utente");

            migrationBuilder.DropColumn(
                name: "Sesso",
                table: "Utente");

            migrationBuilder.RenameColumn(
                name: "DataNascita",
                table: "Utente",
                newName: "NickName");

            migrationBuilder.AddColumn<string>(
                name: "IdUtente",
                table: "Utente",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Utente",
                table: "Utente",
                column: "IdUtente");

            migrationBuilder.CreateTable(
                name: "Prodotti",
                columns: table => new
                {
                    IdProdotto = table.Column<string>(type: "TEXT", nullable: false),
                    Articolo = table.Column<string>(type: "TEXT", nullable: true),
                    Quantità = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodotti", x => x.IdProdotto);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    IdRegistrazione = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    DataDiNascita = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    NickName = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Sesso = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.IdRegistrazione);
                });
        }
    }
}

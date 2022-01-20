using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proj2._0.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    zanr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    datumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    datumKraja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bioskopi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bioskopi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bioskopi_Filmovi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrRedova = table.Column<int>(type: "int", nullable: false),
                    BrSedistaPoRedu = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BioskopId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Bioskopi_BioskopId",
                        column: x => x.BioskopId,
                        principalTable: "Bioskopi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projkecije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filmId = table.Column<int>(type: "int", nullable: false),
                    vreme = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projkecije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projkecije_Filmovi_filmId",
                        column: x => x.filmId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projkecije_Sale_salaId",
                        column: x => x.salaId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sedista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salaId = table.Column<int>(type: "int", nullable: true),
                    BrReda = table.Column<int>(type: "int", nullable: false),
                    BrSedistaURedu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sedista_Sale_salaId",
                        column: x => x.salaId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Karte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sedisteId = table.Column<int>(type: "int", nullable: true),
                    korisnikId = table.Column<int>(type: "int", nullable: true),
                    ProjekcijaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Karte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Karte_Korisnici_korisnikId",
                        column: x => x.korisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karte_Projkecije_ProjekcijaId",
                        column: x => x.ProjekcijaId,
                        principalTable: "Projkecije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Karte_Sedista_sedisteId",
                        column: x => x.sedisteId,
                        principalTable: "Sedista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bioskopi_FilmId",
                table: "Bioskopi",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_korisnikId",
                table: "Karte",
                column: "korisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_ProjekcijaId",
                table: "Karte",
                column: "ProjekcijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Karte_sedisteId",
                table: "Karte",
                column: "sedisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Projkecije_filmId",
                table: "Projkecije",
                column: "filmId");

            migrationBuilder.CreateIndex(
                name: "IX_Projkecije_salaId",
                table: "Projkecije",
                column: "salaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_BioskopId",
                table: "Sale",
                column: "BioskopId");

            migrationBuilder.CreateIndex(
                name: "IX_Sedista_salaId",
                table: "Sedista",
                column: "salaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Karte");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Projkecije");

            migrationBuilder.DropTable(
                name: "Sedista");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Bioskopi");

            migrationBuilder.DropTable(
                name: "Filmovi");
        }
    }
}

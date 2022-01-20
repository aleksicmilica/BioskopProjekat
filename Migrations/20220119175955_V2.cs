using Microsoft.EntityFrameworkCore.Migrations;

namespace proj2._0.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bioskopi_Filmovi_FilmId",
                table: "Bioskopi");

            migrationBuilder.DropIndex(
                name: "IX_Bioskopi_FilmId",
                table: "Bioskopi");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Bioskopi");

            migrationBuilder.CreateTable(
                name: "BioskopiFilmovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BioskopiFilmovi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BioskopiFilmovi_Filmovi_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filmovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BioskopiFilmovi_FilmId",
                table: "BioskopiFilmovi",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BioskopiFilmovi");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Bioskopi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bioskopi_FilmId",
                table: "Bioskopi",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bioskopi_Filmovi_FilmId",
                table: "Bioskopi",
                column: "FilmId",
                principalTable: "Filmovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

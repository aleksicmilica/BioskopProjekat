using Microsoft.EntityFrameworkCore.Migrations;

namespace proj2._0.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BioskopiFilmovi_Bioskopi_BioskopId",
                table: "BioskopiFilmovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Projkecije_Filmovi_filmId",
                table: "Projkecije");

            migrationBuilder.DropIndex(
                name: "IX_BioskopiFilmovi_BioskopId",
                table: "BioskopiFilmovi");

            migrationBuilder.DropColumn(
                name: "BioskopId",
                table: "BioskopiFilmovi");

            migrationBuilder.RenameColumn(
                name: "filmId",
                table: "Projkecije",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Projkecije_filmId",
                table: "Projkecije",
                newName: "IX_Projkecije_FilmId");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Projkecije",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BioskopId",
                table: "Projkecije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projkecije_BioskopId",
                table: "Projkecije",
                column: "BioskopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projkecije_Bioskopi_BioskopId",
                table: "Projkecije",
                column: "BioskopId",
                principalTable: "Bioskopi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projkecije_Filmovi_FilmId",
                table: "Projkecije",
                column: "FilmId",
                principalTable: "Filmovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projkecije_Bioskopi_BioskopId",
                table: "Projkecije");

            migrationBuilder.DropForeignKey(
                name: "FK_Projkecije_Filmovi_FilmId",
                table: "Projkecije");

            migrationBuilder.DropIndex(
                name: "IX_Projkecije_BioskopId",
                table: "Projkecije");

            migrationBuilder.DropColumn(
                name: "BioskopId",
                table: "Projkecije");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Projkecije",
                newName: "filmId");

            migrationBuilder.RenameIndex(
                name: "IX_Projkecije_FilmId",
                table: "Projkecije",
                newName: "IX_Projkecije_filmId");

            migrationBuilder.AlterColumn<int>(
                name: "filmId",
                table: "Projkecije",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BioskopId",
                table: "BioskopiFilmovi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BioskopiFilmovi_BioskopId",
                table: "BioskopiFilmovi",
                column: "BioskopId");

            migrationBuilder.AddForeignKey(
                name: "FK_BioskopiFilmovi_Bioskopi_BioskopId",
                table: "BioskopiFilmovi",
                column: "BioskopId",
                principalTable: "Bioskopi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projkecije_Filmovi_filmId",
                table: "Projkecije",
                column: "filmId",
                principalTable: "Filmovi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

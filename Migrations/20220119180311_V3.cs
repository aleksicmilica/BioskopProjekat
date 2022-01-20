using Microsoft.EntityFrameworkCore.Migrations;

namespace proj2._0.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BioskopiFilmovi_Bioskopi_BioskopId",
                table: "BioskopiFilmovi");

            migrationBuilder.DropIndex(
                name: "IX_BioskopiFilmovi_BioskopId",
                table: "BioskopiFilmovi");

            migrationBuilder.DropColumn(
                name: "BioskopId",
                table: "BioskopiFilmovi");
        }
    }
}

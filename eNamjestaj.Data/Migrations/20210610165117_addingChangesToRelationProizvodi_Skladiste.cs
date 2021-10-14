using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addingChangesToRelationProizvodi_Skladiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProizvodSkladiste_ProizvodId",
                table: "ProizvodSkladiste");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodSkladiste_ProizvodId",
                table: "ProizvodSkladiste",
                column: "ProizvodId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProizvodSkladiste_ProizvodId",
                table: "ProizvodSkladiste");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodSkladiste_ProizvodId",
                table: "ProizvodSkladiste",
                column: "ProizvodId");
        }
    }
}

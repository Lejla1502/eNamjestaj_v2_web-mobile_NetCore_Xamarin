using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class removedKorisnikIdFromNabavkastavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NabavkaStavka_Korisnik_KorisnikId",
                table: "NabavkaStavka");

            migrationBuilder.DropIndex(
                name: "IX_NabavkaStavka_KorisnikId",
                table: "NabavkaStavka");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "NabavkaStavka");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "NabavkaStavka",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavka_KorisnikId",
                table: "NabavkaStavka",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_NabavkaStavka_Korisnik_KorisnikId",
                table: "NabavkaStavka",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

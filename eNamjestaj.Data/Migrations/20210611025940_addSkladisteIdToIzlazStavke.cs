using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addSkladisteIdToIzlazStavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkladisteId",
                table: "IzlaziStavka",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IzlaziStavka_SkladisteId",
                table: "IzlaziStavka",
                column: "SkladisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_IzlaziStavka_Skladiste_SkladisteId",
                table: "IzlaziStavka",
                column: "SkladisteId",
                principalTable: "Skladiste",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IzlaziStavka_Skladiste_SkladisteId",
                table: "IzlaziStavka");

            migrationBuilder.DropIndex(
                name: "IX_IzlaziStavka_SkladisteId",
                table: "IzlaziStavka");

            migrationBuilder.DropColumn(
                name: "SkladisteId",
                table: "IzlaziStavka");
        }
    }
}

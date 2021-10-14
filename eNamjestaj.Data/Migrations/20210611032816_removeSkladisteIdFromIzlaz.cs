using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class removeSkladisteIdFromIzlaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izlaz_Skladiste_SkladisteId",
                table: "Izlaz");

            migrationBuilder.DropIndex(
                name: "IX_Izlaz_SkladisteId",
                table: "Izlaz");

            migrationBuilder.DropColumn(
                name: "SkladisteId",
                table: "Izlaz");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SkladisteId",
                table: "Izlaz",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Izlaz_SkladisteId",
                table: "Izlaz",
                column: "SkladisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Izlaz_Skladiste_SkladisteId",
                table: "Izlaz",
                column: "SkladisteId",
                principalTable: "Skladiste",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addPoslanaTONabavka_addBrojFaktureToIzlaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Poslana",
                table: "Nabavka",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BrojFakture",
                table: "Izlaz",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poslana",
                table: "Nabavka");

            migrationBuilder.DropColumn(
                name: "BrojFakture",
                table: "Izlaz");
        }
    }
}

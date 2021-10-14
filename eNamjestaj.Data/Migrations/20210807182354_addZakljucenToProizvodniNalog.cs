using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addZakljucenToProizvodniNalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proizvodivo",
                table: "Normativ");

            migrationBuilder.AddColumn<bool>(
                name: "Zakljucen",
                table: "Normativ",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zakljucen",
                table: "Normativ");

            migrationBuilder.AddColumn<int>(
                name: "Proizvodivo",
                table: "Normativ",
                nullable: false,
                defaultValue: 0);
        }
    }
}

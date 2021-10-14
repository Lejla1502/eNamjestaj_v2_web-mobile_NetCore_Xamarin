using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addTotalDostavaID_To_Narudzba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DostavaId",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Narudzba",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_DostavaId",
                table: "Narudzba",
                column: "DostavaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba",
                column: "DostavaId",
                principalTable: "Dostava",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_DostavaId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "DostavaId",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Narudzba");
        }
    }
}

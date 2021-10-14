using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class add_ProizvodId_To_ProizvodniNalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProizvodId",
                table: "ProizvodniNalog",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodniNalog_ProizvodId",
                table: "ProizvodniNalog",
                column: "ProizvodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProizvodniNalog_Proizvod_ProizvodId",
                table: "ProizvodniNalog",
                column: "ProizvodId",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProizvodniNalog_Proizvod_ProizvodId",
                table: "ProizvodniNalog");

            migrationBuilder.DropIndex(
                name: "IX_ProizvodniNalog_ProizvodId",
                table: "ProizvodniNalog");

            migrationBuilder.DropColumn(
                name: "ProizvodId",
                table: "ProizvodniNalog");
        }
    }
}

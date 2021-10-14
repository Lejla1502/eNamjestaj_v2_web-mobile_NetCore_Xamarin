using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addVirtualDobavljacInNabavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_DobavljacId",
                table: "Nabavka",
                column: "DobavljacId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nabavka_Dobavljac_DobavljacId",
                table: "Nabavka",
                column: "DobavljacId",
                principalTable: "Dobavljac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nabavka_Dobavljac_DobavljacId",
                table: "Nabavka");

            migrationBuilder.DropIndex(
                name: "IX_Nabavka_DobavljacId",
                table: "Nabavka");
        }
    }
}

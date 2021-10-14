using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class changeDostavaID_Int_To_String_in_Narudzbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Dostava_DostavaId",
                table: "Narudzba");

            migrationBuilder.DropIndex(
                name: "IX_Narudzba_DostavaId",
                table: "Narudzba");

            migrationBuilder.AlterColumn<string>(
                name: "DostavaId",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DostavaId",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class delete_Opis_From_Skladiste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_VrstaSkladista_VrstaSkladistaId",
                table: "Skladiste");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Skladiste");

            migrationBuilder.AlterColumn<int>(
                name: "VrstaSkladistaId",
                table: "Skladiste",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_VrstaSkladista_VrstaSkladistaId",
                table: "Skladiste",
                column: "VrstaSkladistaId",
                principalTable: "VrstaSkladista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_VrstaSkladista_VrstaSkladistaId",
                table: "Skladiste");

            migrationBuilder.AlterColumn<int>(
                name: "VrstaSkladistaId",
                table: "Skladiste",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Skladiste",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_VrstaSkladista_VrstaSkladistaId",
                table: "Skladiste",
                column: "VrstaSkladistaId",
                principalTable: "VrstaSkladista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

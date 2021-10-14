using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addOpisProizvoda_IspravnaKonvencija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpisProizvodaId",
                table: "Proizvod",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OpisProizvoda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpisProizvoda", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_OpisProizvodaId",
                table: "Proizvod",
                column: "OpisProizvodaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_OpisProizvoda_OpisProizvodaId",
                table: "Proizvod",
                column: "OpisProizvodaId",
                principalTable: "OpisProizvoda",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_OpisProizvoda_OpisProizvodaId",
                table: "Proizvod");

            migrationBuilder.DropTable(
                name: "OpisProizvoda");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_OpisProizvodaId",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "OpisProizvodaId",
                table: "Proizvod");
        }
    }
}

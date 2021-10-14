using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addTipNabavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipNabavkeId",
                table: "Nabavka",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipNabavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipNabavke", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_TipNabavkeId",
                table: "Nabavka",
                column: "TipNabavkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nabavka_TipNabavke_TipNabavkeId",
                table: "Nabavka",
                column: "TipNabavkeId",
                principalTable: "TipNabavke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nabavka_TipNabavke_TipNabavkeId",
                table: "Nabavka");

            migrationBuilder.DropTable(
                name: "TipNabavke");

            migrationBuilder.DropIndex(
                name: "IX_Nabavka_TipNabavkeId",
                table: "Nabavka");

            migrationBuilder.DropColumn(
                name: "TipNabavkeId",
                table: "Nabavka");
        }
    }
}

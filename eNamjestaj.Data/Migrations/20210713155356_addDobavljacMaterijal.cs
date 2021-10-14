using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addDobavljacMaterijal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DobavljacMaterijalId",
                table: "Proizvod",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DobavljacMaterijal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    MaterijalId = table.Column<int>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobavljacMaterijal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DobavljacMaterijal_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DobavljacMaterijal_Materijal_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_DobavljacMaterijalId",
                table: "Proizvod",
                column: "DobavljacMaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_DobavljacMaterijal_DobavljacId",
                table: "DobavljacMaterijal",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_DobavljacMaterijal_MaterijalId",
                table: "DobavljacMaterijal",
                column: "MaterijalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_DobavljacMaterijal_DobavljacMaterijalId",
                table: "Proizvod",
                column: "DobavljacMaterijalId",
                principalTable: "DobavljacMaterijal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_DobavljacMaterijal_DobavljacMaterijalId",
                table: "Proizvod");

            migrationBuilder.DropTable(
                name: "DobavljacMaterijal");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_DobavljacMaterijalId",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "DobavljacMaterijalId",
                table: "Proizvod");
        }
    }
}

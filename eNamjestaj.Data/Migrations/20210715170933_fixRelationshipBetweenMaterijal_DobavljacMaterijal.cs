using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class fixRelationshipBetweenMaterijal_DobavljacMaterijal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_DobavljacMaterijal_DobavljacMaterijalId",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_DobavljacMaterijalId",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_DobavljacMaterijal_MaterijalId",
                table: "DobavljacMaterijal");

            migrationBuilder.DropColumn(
                name: "DobavljacMaterijalId",
                table: "Proizvod");

            migrationBuilder.CreateIndex(
                name: "IX_DobavljacMaterijal_MaterijalId",
                table: "DobavljacMaterijal",
                column: "MaterijalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DobavljacMaterijal_MaterijalId",
                table: "DobavljacMaterijal");

            migrationBuilder.AddColumn<int>(
                name: "DobavljacMaterijalId",
                table: "Proizvod",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_DobavljacMaterijalId",
                table: "Proizvod",
                column: "DobavljacMaterijalId");

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
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class renameNormativStavkas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormativStavkas_Materijal_MaterijalId",
                table: "NormativStavkas");

            migrationBuilder.DropForeignKey(
                name: "FK_NormativStavkas_Normativ_NormativId",
                table: "NormativStavkas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NormativStavkas",
                table: "NormativStavkas");

            migrationBuilder.RenameTable(
                name: "NormativStavkas",
                newName: "NormativStavka");

            migrationBuilder.RenameIndex(
                name: "IX_NormativStavkas_NormativId",
                table: "NormativStavka",
                newName: "IX_NormativStavka_NormativId");

            migrationBuilder.RenameIndex(
                name: "IX_NormativStavkas_MaterijalId",
                table: "NormativStavka",
                newName: "IX_NormativStavka_MaterijalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NormativStavka",
                table: "NormativStavka",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NormativStavka_Materijal_MaterijalId",
                table: "NormativStavka",
                column: "MaterijalId",
                principalTable: "Materijal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormativStavka_Normativ_NormativId",
                table: "NormativStavka",
                column: "NormativId",
                principalTable: "Normativ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NormativStavka_Materijal_MaterijalId",
                table: "NormativStavka");

            migrationBuilder.DropForeignKey(
                name: "FK_NormativStavka_Normativ_NormativId",
                table: "NormativStavka");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NormativStavka",
                table: "NormativStavka");

            migrationBuilder.RenameTable(
                name: "NormativStavka",
                newName: "NormativStavkas");

            migrationBuilder.RenameIndex(
                name: "IX_NormativStavka_NormativId",
                table: "NormativStavkas",
                newName: "IX_NormativStavkas_NormativId");

            migrationBuilder.RenameIndex(
                name: "IX_NormativStavka_MaterijalId",
                table: "NormativStavkas",
                newName: "IX_NormativStavkas_MaterijalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NormativStavkas",
                table: "NormativStavkas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NormativStavkas_Materijal_MaterijalId",
                table: "NormativStavkas",
                column: "MaterijalId",
                principalTable: "Materijal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NormativStavkas_Normativ_NormativId",
                table: "NormativStavkas",
                column: "NormativId",
                principalTable: "Normativ",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

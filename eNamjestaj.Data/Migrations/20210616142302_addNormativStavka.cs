using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addNormativStavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormativStavkas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterijalId = table.Column<int>(nullable: false),
                    NormativId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormativStavkas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormativStavkas_Materijal_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormativStavkas_Normativ_NormativId",
                        column: x => x.NormativId,
                        principalTable: "Normativ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormativStavkas_MaterijalId",
                table: "NormativStavkas",
                column: "MaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_NormativStavkas_NormativId",
                table: "NormativStavkas",
                column: "NormativId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormativStavkas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addMaterijalSkladiste_AND_NabavkaMaterijalStavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterijalSkladiste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false),
                    MaterijalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterijalSkladiste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterijalSkladiste_Materijal_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterijalSkladiste_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaMaterijalStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    MaterijalId = table.Column<int>(nullable: false),
                    NabavkaId = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false),
                    TotalStavka = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaMaterijalStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaMaterijalStavka_Materijal_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaMaterijalStavka_Nabavka_NabavkaId",
                        column: x => x.NabavkaId,
                        principalTable: "Nabavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterijalSkladiste_MaterijalId",
                table: "MaterijalSkladiste",
                column: "MaterijalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaterijalSkladiste_SkladisteId",
                table: "MaterijalSkladiste",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaMaterijalStavka_MaterijalId",
                table: "NabavkaMaterijalStavka",
                column: "MaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaMaterijalStavka_NabavkaId",
                table: "NabavkaMaterijalStavka",
                column: "NabavkaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterijalSkladiste");

            migrationBuilder.DropTable(
                name: "NabavkaMaterijalStavka");
        }
    }
}

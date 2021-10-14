using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addOpisProizvoda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KategorijaVrsta");

            migrationBuilder.DropTable(
                name: "TopKategorija");

            migrationBuilder.CreateTable(
                name: "OpisProizvoda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpisProizvoda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpisProizvoda_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpisProizvoda_ProizvodId",
                table: "OpisProizvoda",
                column: "ProizvodId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpisProizvoda");

            migrationBuilder.CreateTable(
                name: "TopKategorija",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopKategorija", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KategorijaVrsta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TopKategorijaId = table.Column<int>(nullable: false),
                    VrstaProizvodaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KategorijaVrsta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KategorijaVrsta_TopKategorija_TopKategorijaId",
                        column: x => x.TopKategorijaId,
                        principalTable: "TopKategorija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KategorijaVrsta_VrstaProizvoda_VrstaProizvodaId",
                        column: x => x.VrstaProizvodaId,
                        principalTable: "VrstaProizvoda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaVrsta_TopKategorijaId",
                table: "KategorijaVrsta",
                column: "TopKategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_KategorijaVrsta_VrstaProizvodaId",
                table: "KategorijaVrsta",
                column: "VrstaProizvodaId");
        }
    }
}

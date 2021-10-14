using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addProdajniNalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProizvodniNalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojNaloga = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    SkladisteMaterijalaId = table.Column<int>(nullable: false),
                    SkladisteProizvodaId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    TrosakPoProizvodu = table.Column<decimal>(nullable: false),
                    UkupnaCijena = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodniNalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProizvodniNalog_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodniNalog_Skladiste_SkladisteMaterijalaId",
                        column: x => x.SkladisteMaterijalaId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProizvodniNalog_Skladiste_SkladisteProizvodaId",
                        column: x => x.SkladisteProizvodaId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodniNalog_KorisnikId",
                table: "ProizvodniNalog",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodniNalog_SkladisteMaterijalaId",
                table: "ProizvodniNalog",
                column: "SkladisteMaterijalaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProizvodniNalog_SkladisteProizvodaId",
                table: "ProizvodniNalog",
                column: "SkladisteProizvodaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProizvodniNalog");
        }
    }
}

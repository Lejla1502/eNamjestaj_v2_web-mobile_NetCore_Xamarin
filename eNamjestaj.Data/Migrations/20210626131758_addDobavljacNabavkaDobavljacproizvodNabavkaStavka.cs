using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class addDobavljacNabavkaDobavljacproizvodNabavkaStavka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dobavljac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nabavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojNabavke = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nabavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nabavka_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nabavka_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DobavljacProizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DobavljacProizvod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DobavljacProizvod_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DobavljacProizvod_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    NabavkaId = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false),
                    TotalStavka = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaStavka_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaStavka_Nabavka_NabavkaId",
                        column: x => x.NabavkaId,
                        principalTable: "Nabavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_NabavkaStavka_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DobavljacProizvod_DobavljacId",
                table: "DobavljacProizvod",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_DobavljacProizvod_ProizvodId",
                table: "DobavljacProizvod",
                column: "ProizvodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_KorisnikId",
                table: "Nabavka",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_SkladisteId",
                table: "Nabavka",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavka_KorisnikId",
                table: "NabavkaStavka",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavka_NabavkaId",
                table: "NabavkaStavka",
                column: "NabavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavka_ProizvodId",
                table: "NabavkaStavka",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DobavljacProizvod");

            migrationBuilder.DropTable(
                name: "NabavkaStavka");

            migrationBuilder.DropTable(
                name: "Dobavljac");

            migrationBuilder.DropTable(
                name: "Nabavka");
        }
    }
}

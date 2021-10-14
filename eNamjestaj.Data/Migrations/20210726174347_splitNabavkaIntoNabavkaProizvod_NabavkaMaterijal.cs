using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class splitNabavkaIntoNabavkaProizvod_NabavkaMaterijal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NabavkaMaterijalStavka_Nabavka_NabavkaId",
                table: "NabavkaMaterijalStavka");

            migrationBuilder.DropTable(
                name: "NabavkaStavka");

            migrationBuilder.DropTable(
                name: "UlazStavke");

            migrationBuilder.DropTable(
                name: "Nabavka");

            migrationBuilder.DropTable(
                name: "Ulaz");

            migrationBuilder.DropTable(
                name: "TipNabavke");

            migrationBuilder.RenameColumn(
                name: "NabavkaId",
                table: "NabavkaMaterijalStavka",
                newName: "NabavkaMaterijalId");

            migrationBuilder.RenameIndex(
                name: "IX_NabavkaMaterijalStavka_NabavkaId",
                table: "NabavkaMaterijalStavka",
                newName: "IX_NabavkaMaterijalStavka_NabavkaMaterijalId");

            migrationBuilder.CreateTable(
                name: "NabavkaMaterijal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojNabavke = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Poslana = table.Column<bool>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaMaterijal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaMaterijal_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaMaterijal_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaMaterijal_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaProizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojNabavke = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Poslana = table.Column<bool>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaProizvod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaProizvod_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaProizvod_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaProizvod_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlazMaterijal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFakture = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    IznosRacuna = table.Column<decimal>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PDV = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false),
                    NabavkaMaterijalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazMaterijal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazMaterijal_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlazMaterijal_NabavkaMaterijal_NabavkaMaterijalId",
                        column: x => x.NabavkaMaterijalId,
                        principalTable: "NabavkaMaterijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UlazMaterijal_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaProizvodStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    NabavkaProizvodId = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false),
                    TotalStavka = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaProizvodStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaProizvodStavka_NabavkaProizvod_NabavkaProizvodId",
                        column: x => x.NabavkaProizvodId,
                        principalTable: "NabavkaProizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaProizvodStavka_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UlazProizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFakture = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    IznosRacuna = table.Column<decimal>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PDV = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false),
                    NabavkaProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazProizvod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazProizvod_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlazProizvod_NabavkaProizvod_NabavkaProizvodId",
                        column: x => x.NabavkaProizvodId,
                        principalTable: "NabavkaProizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UlazProizvod_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlazMaterijalStavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    MaterijalId = table.Column<int>(nullable: false),
                    UlazMaterijalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazMaterijalStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazMaterijalStavke_Materijal_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlazMaterijalStavke_UlazMaterijal_UlazMaterijalId",
                        column: x => x.UlazMaterijalId,
                        principalTable: "UlazMaterijal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlazProizvodStavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    UlazProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazProizvodStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazProizvodStavke_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlazProizvodStavke_UlazProizvod_UlazProizvodId",
                        column: x => x.UlazProizvodId,
                        principalTable: "UlazProizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaMaterijal_DobavljacId",
                table: "NabavkaMaterijal",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaMaterijal_KorisnikId",
                table: "NabavkaMaterijal",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaMaterijal_SkladisteId",
                table: "NabavkaMaterijal",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaProizvod_DobavljacId",
                table: "NabavkaProizvod",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaProizvod_KorisnikId",
                table: "NabavkaProizvod",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaProizvod_SkladisteId",
                table: "NabavkaProizvod",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaProizvodStavka_NabavkaProizvodId",
                table: "NabavkaProizvodStavka",
                column: "NabavkaProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaProizvodStavka_ProizvodId",
                table: "NabavkaProizvodStavka",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazMaterijal_KorisnikId",
                table: "UlazMaterijal",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazMaterijal_NabavkaMaterijalId",
                table: "UlazMaterijal",
                column: "NabavkaMaterijalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UlazMaterijal_SkladisteId",
                table: "UlazMaterijal",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazMaterijalStavke_MaterijalId",
                table: "UlazMaterijalStavke",
                column: "MaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazMaterijalStavke_UlazMaterijalId",
                table: "UlazMaterijalStavke",
                column: "UlazMaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazProizvod_KorisnikId",
                table: "UlazProizvod",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazProizvod_NabavkaProizvodId",
                table: "UlazProizvod",
                column: "NabavkaProizvodId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UlazProizvod_SkladisteId",
                table: "UlazProizvod",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazProizvodStavke_ProizvodId",
                table: "UlazProizvodStavke",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazProizvodStavke_UlazProizvodId",
                table: "UlazProizvodStavke",
                column: "UlazProizvodId");

            migrationBuilder.AddForeignKey(
                name: "FK_NabavkaMaterijalStavka_NabavkaMaterijal_NabavkaMaterijalId",
                table: "NabavkaMaterijalStavka",
                column: "NabavkaMaterijalId",
                principalTable: "NabavkaMaterijal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NabavkaMaterijalStavka_NabavkaMaterijal_NabavkaMaterijalId",
                table: "NabavkaMaterijalStavka");

            migrationBuilder.DropTable(
                name: "NabavkaProizvodStavka");

            migrationBuilder.DropTable(
                name: "UlazMaterijalStavke");

            migrationBuilder.DropTable(
                name: "UlazProizvodStavke");

            migrationBuilder.DropTable(
                name: "UlazMaterijal");

            migrationBuilder.DropTable(
                name: "UlazProizvod");

            migrationBuilder.DropTable(
                name: "NabavkaMaterijal");

            migrationBuilder.DropTable(
                name: "NabavkaProizvod");

            migrationBuilder.RenameColumn(
                name: "NabavkaMaterijalId",
                table: "NabavkaMaterijalStavka",
                newName: "NabavkaId");

            migrationBuilder.RenameIndex(
                name: "IX_NabavkaMaterijalStavka_NabavkaMaterijalId",
                table: "NabavkaMaterijalStavka",
                newName: "IX_NabavkaMaterijalStavka_NabavkaId");

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

            migrationBuilder.CreateTable(
                name: "Ulaz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojFakture = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    IznosRacuna = table.Column<decimal>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    PDV = table.Column<decimal>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulaz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ulaz_Korisnik_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ulaz_Skladiste_SkladisteId",
                        column: x => x.SkladisteId,
                        principalTable: "Skladiste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nabavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojNabavke = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    DobavljacId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false),
                    Poslana = table.Column<bool>(nullable: false),
                    SkladisteId = table.Column<int>(nullable: false),
                    TipNabavkeId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nabavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nabavka_Dobavljac_DobavljacId",
                        column: x => x.DobavljacId,
                        principalTable: "Dobavljac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_Nabavka_TipNabavke_TipNabavkeId",
                        column: x => x.TipNabavkeId,
                        principalTable: "TipNabavke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UlazStavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    UlazId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UlazStavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UlazStavke_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UlazStavke_Ulaz_UlazId",
                        column: x => x.UlazId,
                        principalTable: "Ulaz",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NabavkaStavka",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<decimal>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false),
                    NabavkaId = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    TotalStavka = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NabavkaStavka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NabavkaStavka_Nabavka_NabavkaId",
                        column: x => x.NabavkaId,
                        principalTable: "Nabavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NabavkaStavka_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_DobavljacId",
                table: "Nabavka",
                column: "DobavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_KorisnikId",
                table: "Nabavka",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_SkladisteId",
                table: "Nabavka",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_Nabavka_TipNabavkeId",
                table: "Nabavka",
                column: "TipNabavkeId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavka_NabavkaId",
                table: "NabavkaStavka",
                column: "NabavkaId");

            migrationBuilder.CreateIndex(
                name: "IX_NabavkaStavka_ProizvodId",
                table: "NabavkaStavka",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaz_KorisnikId",
                table: "Ulaz",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ulaz_SkladisteId",
                table: "Ulaz",
                column: "SkladisteId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazStavke_ProizvodId",
                table: "UlazStavke",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_UlazStavke_UlazId",
                table: "UlazStavke",
                column: "UlazId");

            migrationBuilder.AddForeignKey(
                name: "FK_NabavkaMaterijalStavka_Nabavka_NabavkaId",
                table: "NabavkaMaterijalStavka",
                column: "NabavkaId",
                principalTable: "Nabavka",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

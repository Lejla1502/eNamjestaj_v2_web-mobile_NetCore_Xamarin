using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class add_VrstaSkladista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_Korisnik_KorisnikId",
                table: "Skladiste");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Skladiste",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VrstaSkladistaId",
                table: "Skladiste",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VrstaSkladista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaSkladista", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skladiste_VrstaSkladistaId",
                table: "Skladiste",
                column: "VrstaSkladistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_Korisnik_KorisnikId",
                table: "Skladiste",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_VrstaSkladista_VrstaSkladistaId",
                table: "Skladiste",
                column: "VrstaSkladistaId",
                principalTable: "VrstaSkladista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_Korisnik_KorisnikId",
                table: "Skladiste");

            migrationBuilder.DropForeignKey(
                name: "FK_Skladiste_VrstaSkladista_VrstaSkladistaId",
                table: "Skladiste");

            migrationBuilder.DropTable(
                name: "VrstaSkladista");

            migrationBuilder.DropIndex(
                name: "IX_Skladiste_VrstaSkladistaId",
                table: "Skladiste");

            migrationBuilder.DropColumn(
                name: "VrstaSkladistaId",
                table: "Skladiste");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Skladiste",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Skladiste_Korisnik_KorisnikId",
                table: "Skladiste",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

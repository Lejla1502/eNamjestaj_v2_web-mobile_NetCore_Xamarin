using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eNamjestaj.Data.Migrations
{
    public partial class changingOpisToDatumInNormativ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Normativ");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Normativ",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Normativ");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Normativ",
                nullable: true);
        }
    }
}

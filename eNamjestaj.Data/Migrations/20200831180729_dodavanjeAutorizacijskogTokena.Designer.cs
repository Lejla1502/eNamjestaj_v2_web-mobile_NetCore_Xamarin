﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eNamjestaj.Data;

namespace eNamjestaj.Data.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20200831180729_dodavanjeAutorizacijskogTokena")]
    partial class dodavanjeAutorizacijskogTokena
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eNamjestaj.Data.Models.AkcijskiKatalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivan");

                    b.Property<DateTime>("DatumPocetka");

                    b.Property<DateTime>("DatumZavrsetka");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("AkcijskiKatalog");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.AutorizacijskiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAdresa");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Vrijednost");

                    b.Property<DateTime>("VrijemeEvidentiranja");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("AutorizacijskiToken");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Boja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Boja");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Dostava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<string>("Opis");

                    b.Property<string>("Tip");

                    b.HasKey("Id");

                    b.ToTable("Dostava");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Dostavljac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Telefon");

                    b.Property<string>("ZiroRacun");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Dostavljac");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Izlaz", b =>
                {
                    b.Property<int>("IzlazId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojNarudzbe");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("DostavaId");

                    b.Property<decimal>("IznosBezPDV");

                    b.Property<decimal>("IznosSaPDV");

                    b.Property<int?>("KorisnikId");

                    b.Property<int>("NarudzbaId");

                    b.Property<bool>("PovratNovca");

                    b.Property<int>("SkladisteId");

                    b.Property<bool>("Zakljucena");

                    b.HasKey("IzlazId");

                    b.HasIndex("DostavaId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("NarudzbaId")
                        .IsUnique();

                    b.HasIndex("SkladisteId");

                    b.ToTable("Izlaz");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.IzlazStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<int>("IzlazId");

                    b.Property<int>("Kolicina");

                    b.Property<decimal>("Konacnacijena");

                    b.Property<int>("Popust");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("IzlazId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("IzlaziStavka");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Kanton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Kanton");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.KatalogStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AkcijskiKatalogId");

                    b.Property<int>("PopustProcent");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("AkcijskiKatalogId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("KatalogStavka");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Komentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KupacId");

                    b.Property<string>("Sadrzaj");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.ToTable("Komentar");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KorisnickoIme");

                    b.Property<string>("Lozinka");

                    b.Property<int>("OpstinaId");

                    b.Property<int>("UlogaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnickoIme")
                        .IsUnique()
                        .HasFilter("[KorisnickoIme] IS NOT NULL");

                    b.HasIndex("OpstinaId");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Kupac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AreaAccessed");

                    b.Property<string>("IPAddress");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivna");

                    b.Property<string>("BrojNarudzbe");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KupacId");

                    b.Property<bool>("NaCekanju");

                    b.Property<bool>("Otkazano");

                    b.Property<bool>("Status");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.NarudzbaStavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BojaId");

                    b.Property<decimal>("CijenaProizvoda");

                    b.Property<int>("Kolicina");

                    b.Property<int>("NarudzbaId");

                    b.Property<int>("PopustNaCijenu");

                    b.Property<int>("ProizvodId");

                    b.Property<decimal>("TotalStavke");

                    b.HasKey("Id");

                    b.HasIndex("BojaId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaStavka");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Ocjena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("KupacId");

                    b.Property<int>("OcjenaBr");

                    b.HasKey("Id");

                    b.HasIndex("KupacId");

                    b.ToTable("Ocjena");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Opstina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KantonId");

                    b.Property<string>("Naziv");

                    b.Property<string>("PostanskiBroj");

                    b.HasKey("Id");

                    b.HasIndex("KantonId");

                    b.ToTable("Opstina");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Proizvod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Sifra");

                    b.Property<string>("Slika");

                    b.Property<int>("VrstaProizvodaId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("Sifra")
                        .IsUnique()
                        .HasFilter("[Sifra] IS NOT NULL");

                    b.HasIndex("VrstaProizvodaId");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.ProizvodBoja", b =>
                {
                    b.Property<int>("ProizvodId");

                    b.Property<int>("BojaId");

                    b.HasKey("ProizvodId", "BojaId");

                    b.HasAlternateKey("BojaId", "ProizvodId");

                    b.ToTable("ProizvodBoja");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.ProizvodSkladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.Property<int>("SkladisteId");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("ProizvodSkladiste");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.RadniNalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datum");

                    b.Property<int>("DostavljacId");

                    b.Property<int?>("NarudzbaId");

                    b.HasKey("Id");

                    b.HasIndex("DostavljacId");

                    b.HasIndex("NarudzbaId");

                    b.ToTable("RadniNalog");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Skladiste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<int?>("KorisnikId");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Skladiste");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Ulaz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojFakture");

                    b.Property<DateTime>("Datum");

                    b.Property<decimal>("IznosRacuna");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Napomena");

                    b.Property<decimal>("PDV");

                    b.Property<int>("SkladisteId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("SkladisteId");

                    b.ToTable("Ulaz");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.UlazStavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.Property<int>("UlazId");

                    b.HasKey("Id");

                    b.HasIndex("ProizvodId");

                    b.HasIndex("UlazId");

                    b.ToTable("UlazStavke");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Uloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipUloge");

                    b.HasKey("Id");

                    b.ToTable("Uloga");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.VrstaProizvoda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaProizvoda");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Zaposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa");

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<int>("KorisnikId");

                    b.Property<string>("Prezime");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("KorisnikId");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.AutorizacijskiToken", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Dostavljac", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Izlaz", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Dostava", "Dostava")
                        .WithMany()
                        .HasForeignKey("DostavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");

                    b.HasOne("eNamjestaj.Data.Models.Narudzba", "Narudzba")
                        .WithOne("Izlaz")
                        .HasForeignKey("eNamjestaj.Data.Models.Izlaz", "NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.IzlazStavka", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Izlaz", "Izlaz")
                        .WithMany()
                        .HasForeignKey("IzlazId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Kanton", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.KatalogStavka", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.AkcijskiKatalog", "AkcijskiKatalog")
                        .WithMany()
                        .HasForeignKey("AkcijskiKatalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Komentar", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Korisnik", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("OpstinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Kupac", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Narudzba", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.NarudzbaStavka", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Boja", "Boja")
                        .WithMany()
                        .HasForeignKey("BojaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Ocjena", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Opstina", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Kanton", "Kanton")
                        .WithMany()
                        .HasForeignKey("KantonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Proizvod", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.VrstaProizvoda", "VrstaProizvoda")
                        .WithMany()
                        .HasForeignKey("VrstaProizvodaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.ProizvodBoja", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Boja", "Boja")
                        .WithMany("ProizvodBojas")
                        .HasForeignKey("BojaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Proizvod", "Proizvod")
                        .WithMany("ProizvodBojas")
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.ProizvodSkladiste", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.RadniNalog", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Dostavljac", "Dostavljac")
                        .WithMany()
                        .HasForeignKey("DostavljacId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Skladiste", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId");
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Ulaz", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Skladiste", "Skladiste")
                        .WithMany()
                        .HasForeignKey("SkladisteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.UlazStavke", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eNamjestaj.Data.Models.Ulaz", "Ulaz")
                        .WithMany()
                        .HasForeignKey("UlazId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("eNamjestaj.Data.Models.Zaposlenik", b =>
                {
                    b.HasOne("eNamjestaj.Data.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
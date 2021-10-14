using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eNamjestaj.WebAPI.Database
{
    public partial class eNamjestaj_v2Context : DbContext
    {
        public eNamjestaj_v2Context()
        {
        }

        public eNamjestaj_v2Context(DbContextOptions<eNamjestaj_v2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AkcijskiKatalog> AkcijskiKatalog { get; set; }
        public virtual DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public virtual DbSet<Boja> Boja { get; set; }
        public virtual DbSet<Dobavljac> Dobavljac { get; set; }
        public virtual DbSet<DobavljacMaterijal> DobavljacMaterijal { get; set; }
        public virtual DbSet<DobavljacProizvod> DobavljacProizvod { get; set; }
        public virtual DbSet<Dostava> Dostava { get; set; }
        public virtual DbSet<Dostavljac> Dostavljac { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Izlaz> Izlaz { get; set; }
        public virtual DbSet<IzlaziStavka> IzlaziStavka { get; set; }
        public virtual DbSet<Kanton> Kanton { get; set; }
        public virtual DbSet<KatalogStavka> KatalogStavka { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<Materijal> Materijal { get; set; }
        public virtual DbSet<MaterijalSkladiste> MaterijalSkladiste { get; set; }
        public virtual DbSet<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public virtual DbSet<NabavkaMaterijalStavka> NabavkaMaterijalStavka { get; set; }
        public virtual DbSet<NabavkaProizvod> NabavkaProizvod { get; set; }
        public virtual DbSet<NabavkaProizvodStavka> NabavkaProizvodStavka { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual DbSet<Normativ> Normativ { get; set; }
        public virtual DbSet<NormativStavka> NormativStavka { get; set; }
        public virtual DbSet<OpisProizvoda> OpisProizvoda { get; set; }
        public virtual DbSet<Opstina> Opstina { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<ProizvodBoja> ProizvodBoja { get; set; }
        public virtual DbSet<ProizvodSkladiste> ProizvodSkladiste { get; set; }
        public virtual DbSet<ProizvodniNalog> ProizvodniNalog { get; set; }
        public virtual DbSet<RadniNalog> RadniNalog { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Skladiste> Skladiste { get; set; }
        public virtual DbSet<UlazMaterijal> UlazMaterijal { get; set; }
        public virtual DbSet<UlazMaterijalStavke> UlazMaterijalStavke { get; set; }
        public virtual DbSet<UlazProizvod> UlazProizvod { get; set; }
        public virtual DbSet<UlazProizvodStavke> UlazProizvodStavke { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<VrstaProizvoda> VrstaProizvoda { get; set; }
        public virtual DbSet<VrstaSkladista> VrstaSkladista { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=eNamjestaj_v2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AutorizacijskiToken>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.AutorizacijskiToken)
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<DobavljacMaterijal>(entity =>
            {
                entity.HasIndex(e => e.DobavljacId);

                entity.HasIndex(e => e.MaterijalId)
                    .IsUnique();

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.DobavljacMaterijal)
                    .HasForeignKey(d => d.DobavljacId);

                entity.HasOne(d => d.Materijal)
                    .WithOne(p => p.DobavljacMaterijal)
                    .HasForeignKey<DobavljacMaterijal>(d => d.MaterijalId);
            });

            modelBuilder.Entity<DobavljacProizvod>(entity =>
            {
                entity.HasIndex(e => e.DobavljacId);

                entity.HasIndex(e => e.ProizvodId)
                    .IsUnique();

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.DobavljacProizvod)
                    .HasForeignKey(d => d.DobavljacId);

                entity.HasOne(d => d.Proizvod)
                    .WithOne(p => p.DobavljacProizvod)
                    .HasForeignKey<DobavljacProizvod>(d => d.ProizvodId);
            });

            modelBuilder.Entity<Dostava>(entity =>
            {
                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Dostavljac>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.HasIndex(e => e.KorisnikId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Dostavljac)
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<Izlaz>(entity =>
            {
                entity.HasIndex(e => e.DostavaId);

                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.NarudzbaId)
                    .IsUnique();

                entity.Property(e => e.IznosBezPdv)
                    .HasColumnName("IznosBezPDV")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IznosSaPdv)
                    .HasColumnName("IznosSaPDV")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Dostava)
                    .WithMany(p => p.Izlaz)
                    .HasForeignKey(d => d.DostavaId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Izlaz)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.Narudzba)
                    .WithOne(p => p.Izlaz)
                    .HasForeignKey<Izlaz>(d => d.NarudzbaId);
            });

            modelBuilder.Entity<IzlaziStavka>(entity =>
            {
                entity.HasIndex(e => e.IzlazId);

                entity.HasIndex(e => e.ProizvodId);

                entity.HasIndex(e => e.SkladisteId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Konacnacijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Izlaz)
                    .WithMany(p => p.IzlaziStavka)
                    .HasForeignKey(d => d.IzlazId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.IzlaziStavka)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.IzlaziStavka)
                    .HasForeignKey(d => d.SkladisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Kanton>(entity =>
            {
                entity.HasIndex(e => e.DrzavaId);

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Kanton)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<KatalogStavka>(entity =>
            {
                entity.HasIndex(e => e.AkcijskiKatalogId);

                entity.HasIndex(e => e.ProizvodId);

                entity.HasOne(d => d.AkcijskiKatalog)
                    .WithMany(p => p.KatalogStavka)
                    .HasForeignKey(d => d.AkcijskiKatalogId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.KatalogStavka)
                    .HasForeignKey(d => d.ProizvodId);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasIndex(e => e.OpstinaId);

                entity.HasIndex(e => e.UlogaId);

                entity.Property(e => e.KorisnickoIme).HasMaxLength(450);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'')");

                entity.HasOne(d => d.Opstina)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.OpstinaId);

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.UlogaId);
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.HasIndex(e => e.KorisnikId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Kupac)
                    .HasForeignKey(d => d.KorisnikId);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");
            });

            modelBuilder.Entity<Materijal>(entity =>
            {
                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<MaterijalSkladiste>(entity =>
            {
                entity.HasIndex(e => e.MaterijalId)
                    .IsUnique();

                entity.HasIndex(e => e.SkladisteId);

                entity.HasOne(d => d.Materijal)
                    .WithOne(p => p.MaterijalSkladiste)
                    .HasForeignKey<MaterijalSkladiste>(d => d.MaterijalId);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.MaterijalSkladiste)
                    .HasForeignKey(d => d.SkladisteId);
            });

            modelBuilder.Entity<NabavkaMaterijal>(entity =>
            {
                entity.HasIndex(e => e.DobavljacId);

                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.SkladisteId);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.NabavkaMaterijal)
                    .HasForeignKey(d => d.DobavljacId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.NabavkaMaterijal)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.NabavkaMaterijal)
                    .HasForeignKey(d => d.SkladisteId);
            });

            modelBuilder.Entity<NabavkaMaterijalStavka>(entity =>
            {
                entity.HasIndex(e => e.MaterijalId);

                entity.HasIndex(e => e.NabavkaMaterijalId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalStavka).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Materijal)
                    .WithMany(p => p.NabavkaMaterijalStavka)
                    .HasForeignKey(d => d.MaterijalId);

                entity.HasOne(d => d.NabavkaMaterijal)
                    .WithMany(p => p.NabavkaMaterijalStavka)
                    .HasForeignKey(d => d.NabavkaMaterijalId);
            });

            modelBuilder.Entity<NabavkaProizvod>(entity =>
            {
                entity.HasIndex(e => e.DobavljacId);

                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.SkladisteId);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.NabavkaProizvod)
                    .HasForeignKey(d => d.DobavljacId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.NabavkaProizvod)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.NabavkaProizvod)
                    .HasForeignKey(d => d.SkladisteId);
            });

            modelBuilder.Entity<NabavkaProizvodStavka>(entity =>
            {
                entity.HasIndex(e => e.NabavkaProizvodId);

                entity.HasIndex(e => e.ProizvodId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalStavka).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.NabavkaProizvod)
                    .WithMany(p => p.NabavkaProizvodStavka)
                    .HasForeignKey(d => d.NabavkaProizvodId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.NabavkaProizvodStavka)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Narudzba>(entity =>
            {
                entity.HasIndex(e => e.KupacId);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Narudzba)
                    .HasForeignKey(d => d.KupacId);
            });

            modelBuilder.Entity<NarudzbaStavka>(entity =>
            {
                entity.HasIndex(e => e.BojaId);

                entity.HasIndex(e => e.NarudzbaId);

                entity.HasIndex(e => e.ProizvodId);

                entity.Property(e => e.CijenaProizvoda).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalStavke).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Boja)
                    .WithMany(p => p.NarudzbaStavka)
                    .HasForeignKey(d => d.BojaId);

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbaStavka)
                    .HasForeignKey(d => d.NarudzbaId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.NarudzbaStavka)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Normativ>(entity =>
            {
                entity.HasIndex(e => e.ProizvodId)
                    .IsUnique();

                entity.Property(e => e.Datum).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.HasOne(d => d.Proizvod)
                    .WithOne(p => p.Normativ)
                    .HasForeignKey<Normativ>(d => d.ProizvodId);
            });

            modelBuilder.Entity<NormativStavka>(entity =>
            {
                entity.HasIndex(e => e.MaterijalId);

                entity.HasIndex(e => e.NormativId);

                entity.HasOne(d => d.Materijal)
                    .WithMany(p => p.NormativStavka)
                    .HasForeignKey(d => d.MaterijalId);

                entity.HasOne(d => d.Normativ)
                    .WithMany(p => p.NormativStavka)
                    .HasForeignKey(d => d.NormativId);
            });

            modelBuilder.Entity<Opstina>(entity =>
            {
                entity.HasIndex(e => e.KantonId);

                entity.HasOne(d => d.Kanton)
                    .WithMany(p => p.Opstina)
                    .HasForeignKey(d => d.KantonId);
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.OpisProizvodaId);

                entity.HasIndex(e => e.Sifra)
                    .IsUnique()
                    .HasFilter("([Sifra] IS NOT NULL)");

                entity.HasIndex(e => e.VrstaProizvodaId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Proizvod)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.OpisProizvoda)
                    .WithMany(p => p.Proizvod)
                    .HasForeignKey(d => d.OpisProizvodaId);

                entity.HasOne(d => d.VrstaProizvoda)
                    .WithMany(p => p.Proizvod)
                    .HasForeignKey(d => d.VrstaProizvodaId);
            });

            modelBuilder.Entity<ProizvodBoja>(entity =>
            {
                entity.HasKey(e => new { e.ProizvodId, e.BojaId });

                entity.HasIndex(e => new { e.BojaId, e.ProizvodId })
                    .HasName("AK_ProizvodBoja_BojaId_ProizvodId")
                    .IsUnique();

                entity.HasOne(d => d.Boja)
                    .WithMany(p => p.ProizvodBoja)
                    .HasForeignKey(d => d.BojaId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.ProizvodBoja)
                    .HasForeignKey(d => d.ProizvodId);
            });

            modelBuilder.Entity<ProizvodSkladiste>(entity =>
            {
                entity.HasIndex(e => e.ProizvodId)
                    .IsUnique();

                entity.HasIndex(e => e.SkladisteId);

                entity.HasOne(d => d.Proizvod)
                    .WithOne(p => p.ProizvodSkladiste)
                    .HasForeignKey<ProizvodSkladiste>(d => d.ProizvodId);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.ProizvodSkladiste)
                    .HasForeignKey(d => d.SkladisteId);
            });

            modelBuilder.Entity<ProizvodniNalog>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.ProizvodId);

                entity.HasIndex(e => e.SkladisteMaterijalaId);

                entity.HasIndex(e => e.SkladisteProizvodaId);

                entity.Property(e => e.TrosakPoProizvodu).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UkupnaCijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.ProizvodniNalog)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.ProizvodniNalog)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SkladisteMaterijala)
                    .WithMany(p => p.ProizvodniNalogSkladisteMaterijala)
                    .HasForeignKey(d => d.SkladisteMaterijalaId);

                entity.HasOne(d => d.SkladisteProizvoda)
                    .WithMany(p => p.ProizvodniNalogSkladisteProizvoda)
                    .HasForeignKey(d => d.SkladisteProizvodaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RadniNalog>(entity =>
            {
                entity.HasIndex(e => e.DostavljacId);

                entity.HasIndex(e => e.NarudzbaId);

                entity.HasOne(d => d.Dostavljac)
                    .WithMany(p => p.RadniNalog)
                    .HasForeignKey(d => d.DostavljacId);

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.RadniNalog)
                    .HasForeignKey(d => d.NarudzbaId);
            });

            modelBuilder.Entity<Recenzija>(entity =>
            {
                entity.HasIndex(e => e.KupacId);

                entity.HasIndex(e => e.ProizvodId);

                entity.Property(e => e.Ocjena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.KupacId);

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Recenzija)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Skladiste>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.VrstaSkladistaId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Skladiste)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VrstaSkladista)
                    .WithMany(p => p.Skladiste)
                    .HasForeignKey(d => d.VrstaSkladistaId);
            });

            modelBuilder.Entity<UlazMaterijal>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.NabavkaMaterijalId)
                    .IsUnique();

                entity.HasIndex(e => e.SkladisteId);

                entity.Property(e => e.IznosRacuna).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pdv)
                    .HasColumnName("PDV")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.UlazMaterijal)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.NabavkaMaterijal)
                    .WithOne(p => p.UlazMaterijal)
                    .HasForeignKey<UlazMaterijal>(d => d.NabavkaMaterijalId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.UlazMaterijal)
                    .HasForeignKey(d => d.SkladisteId);
            });

            modelBuilder.Entity<UlazMaterijalStavke>(entity =>
            {
                entity.HasIndex(e => e.MaterijalId);

                entity.HasIndex(e => e.UlazMaterijalId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Materijal)
                    .WithMany(p => p.UlazMaterijalStavke)
                    .HasForeignKey(d => d.MaterijalId);

                entity.HasOne(d => d.UlazMaterijal)
                    .WithMany(p => p.UlazMaterijalStavke)
                    .HasForeignKey(d => d.UlazMaterijalId);
            });

            modelBuilder.Entity<UlazProizvod>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.NabavkaProizvodId)
                    .IsUnique();

                entity.HasIndex(e => e.SkladisteId);

                entity.Property(e => e.IznosRacuna).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Pdv)
                    .HasColumnName("PDV")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.UlazProizvod)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.NabavkaProizvod)
                    .WithOne(p => p.UlazProizvod)
                    .HasForeignKey<UlazProizvod>(d => d.NabavkaProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.UlazProizvod)
                    .HasForeignKey(d => d.SkladisteId);
            });

            modelBuilder.Entity<UlazProizvodStavke>(entity =>
            {
                entity.HasIndex(e => e.ProizvodId);

                entity.HasIndex(e => e.UlazProizvodId);

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.UlazProizvodStavke)
                    .HasForeignKey(d => d.ProizvodId);

                entity.HasOne(d => d.UlazProizvod)
                    .WithMany(p => p.UlazProizvodStavke)
                    .HasForeignKey(d => d.UlazProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Zaposlenik>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasFilter("([Email] IS NOT NULL)");

                entity.HasIndex(e => e.KorisnikId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Zaposlenik)
                    .HasForeignKey(d => d.KorisnikId);
            });
        }
    }
}

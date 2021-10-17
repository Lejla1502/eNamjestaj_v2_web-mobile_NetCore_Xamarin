using eNamjestaj.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data
{
    public class MojContext : DbContext
    {
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=enamjestaj-server,1433,Database=eNamjestaj;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=enamjestaj-server-admin;Password=76OT5KE8D86UD64T$");
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {

            base.OnConfiguring(optionsbuilder);

            optionsbuilder.UseSqlServer("server=localhost;database=enamjestaj_v2;trusted_connection=true;multipleactiveresultsets=true;user id=aa;password=aa; connection timeout=9000");

        }



        public MojContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<Dostavljac>()
               .HasOne(x => x.Korisnik)
               .WithMany()
               .HasForeignKey(x => x.KorisnikId);

            modelBuilder
              .Entity<Zaposlenik>()
              .HasOne(x => x.Korisnik)
              .WithMany()
              .HasForeignKey(x => x.KorisnikId);

            modelBuilder
               .Entity<Kupac>()
               .HasOne(x => x.Korisnik)
               .WithMany()
               .HasForeignKey(x => x.KorisnikId);

            modelBuilder.Entity<ProizvodBoja>().HasKey(pb => new { pb.ProizvodId, pb.BojaId });

       

            modelBuilder.Entity<Dostavljac>()
            .HasIndex(b => b.Email).IsUnique();

            modelBuilder.Entity<Korisnik>()
            .HasIndex(b => b.KorisnickoIme).IsUnique();

            

            modelBuilder.Entity<Kupac>()
            .HasIndex(b => b.Email).IsUnique();


            modelBuilder.Entity<Zaposlenik>()
            .HasIndex(b => b.Email).IsUnique();


            modelBuilder.Entity<Proizvod>()
                .HasIndex(b => b.Sifra).IsUnique();


            modelBuilder.Entity<IzlazStavka>()
                .HasOne(pt => pt.Proizvod)
                .WithMany()
                .HasForeignKey(pt => pt.ProizvodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UlazProizvodStavke>()
               .HasOne(pt => pt.UlazProizvod)
               .WithMany()
               .HasForeignKey(pt => pt.UlazProizvodId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Narudzba>()
                .HasOne(a => a.Izlaz)
                .WithOne(b => b.Narudzba)
                .HasForeignKey<Izlaz>(b => b.NarudzbaId);

            modelBuilder.Entity<NabavkaProizvod>()
               .HasOne(a => a.UlazProizvod)
               .WithOne(b => b.NabavkaProizvod)
               .HasForeignKey<UlazProizvod>(b => b.NabavkaProizvodId);

            modelBuilder.Entity<NabavkaMaterijal>()
               .HasOne(a => a.UlazMaterijal)
               .WithOne(b => b.NabavkaMaterijal)
               .HasForeignKey<UlazMaterijal>(b => b.NabavkaMaterijalId);

            modelBuilder.Entity<NarudzbaStavka>()
               .HasOne(p => p.Proizvod)
               .WithMany()
               .HasForeignKey(p => p.ProizvodId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Proizvod>()
        .HasOne(a => a.ProizvodSkladiste)
        .WithOne(b => b.Proizvod)
        .HasForeignKey<ProizvodSkladiste>(b => b.ProizvodId);

            modelBuilder.Entity<Proizvod>()
        .HasOne(a => a.Normativ)
        .WithOne(b => b.Proizvod)
        .HasForeignKey<Normativ>(b => b.ProizvodId);

            modelBuilder.Entity<DobavljacMaterijal>()
           .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DobavljacProizvod>()
           .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Dostava>()
           .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Izlaz>()
           .Property(b => b.IznosBezPDV).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Izlaz>()
          .Property(b => b.IznosSaPDV).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<IzlazStavka>()
         .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<IzlazStavka>()
         .Property(b => b.Konacnacijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Materijal>()
        .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NabavkaMaterijal>()
        .Property(b => b.Total).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NabavkaMaterijalStavka>()
       .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NabavkaMaterijalStavka>()
       .Property(b => b.TotalStavka).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NabavkaProizvod>()
       .Property(b => b.Total).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NabavkaProizvodStavka>()
        .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NabavkaProizvodStavka>()
        .Property(b => b.TotalStavka).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Narudzba>()
        .Property(b => b.Total).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NarudzbaStavka>()
        .Property(b => b.CijenaProizvoda).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<NarudzbaStavka>()
      .Property(b => b.TotalStavke).HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Proizvod>()
        .Property(b => b.Cijena).HasColumnType("decimal(18,2)");


            modelBuilder.Entity<ProizvodniNalog>()
        .Property(b => b.TrosakPoProizvodu).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ProizvodniNalog>()
        .Property(b => b.UkupnaCijena).HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Recenzija>()
        .Property(b => b.Ocjena).HasColumnType("decimal");

            modelBuilder.Entity<UlazMaterijal>()
        .Property(b => b.IznosRacuna).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<UlazMaterijal>()
       .Property(b => b.PDV).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<UlazMaterijalStavke>()
       .Property(b => b.Cijena).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<UlazProizvod>()
       .Property(b => b.IznosRacuna).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<UlazProizvod>()
          .Property(b => b.PDV).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<UlazProizvodStavke>()
      .Property(b => b.Cijena).HasColumnType("decimal(18,2)");
        
    }

        public virtual DbSet<Dostavljac> Dostavljac { get; set; }
        public virtual DbSet<Izlaz> Izlaz { get; set; }
        public virtual DbSet<IzlazStavka> IzlaziStavka { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Skladiste> Skladiste { get; set; }
        public virtual DbSet<ProizvodSkladiste> ProizvodSkladiste { get; set; }
        public virtual DbSet<UlazProizvod> UlazProizvod { get; set; }
        public virtual DbSet<UlazProizvodStavke> UlazProizvodStavke { get; set; }
        public virtual DbSet<UlazMaterijal> UlazMaterijal { get; set; }
        public virtual DbSet<UlazMaterijalStavke> UlazMaterijalStavke { get; set; }
        public virtual DbSet<VrstaProizvoda> VrstaProizvoda { get; set; }
        public virtual DbSet<AkcijskiKatalog> AkcijskiKatalog { get; set; }
        public virtual DbSet<Boja> Boja { get; set; }
        public virtual DbSet<Dostava> Dostava { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Kanton> Kanton { get; set; }
        public virtual DbSet<KatalogStavka> KatalogStavka { get; set; }
        public virtual DbSet<Opstina> Opstina { get; set; }
        public virtual DbSet<RadniNalog> RadniNalog { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<ProizvodBoja> ProizvodBoja { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Zaposlenik> Zaposlenik { get; set; }
        public virtual DbSet<OpisProizvoda> OpisProizvoda { get; set; }
        public virtual DbSet<Normativ> Normativ { get; set; }
        public virtual DbSet<Materijal> Materijal { get; set; }
        public virtual DbSet<NormativStavka> NormativStavka { get; set; }
        public virtual DbSet<NabavkaProizvod> NabavkaProizvod { get; set; }
        public virtual DbSet<NabavkaProizvodStavka> NabavkaProizvodStavka { get; set; }
        public virtual DbSet<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public virtual DbSet<NabavkaMaterijalStavka> NabavkaMaterijalStavka { get; set; }
        public virtual DbSet<Dobavljac> Dobavljac { get; set; }
        public virtual DbSet<DobavljacProizvod> DobavljacProizvod { get; set; }
        public virtual DbSet<DobavljacMaterijal> DobavljacMaterijal { get; set; }
        public virtual DbSet<MaterijalSkladiste> MaterijalSkladiste { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<ProizvodniNalog> ProizvodniNalog { get; set; }
        public DbSet<VrstaSkladista> VrstaSkladista { get; set; }

        public MojContext(DbContextOptions<MojContext> options): base(options)
        {
           // Database.SetCommandTimeout(950000);
        }

    }
}

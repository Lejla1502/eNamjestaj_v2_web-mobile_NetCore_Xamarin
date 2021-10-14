using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class UlazProizvod
    {
        public UlazProizvod()
        {
            UlazProizvodStavke = new HashSet<UlazProizvodStavke>();
        }

        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
        public string Napomena { get; set; }
        public decimal Pdv { get; set; }
        public int KorisnikId { get; set; }
        public int SkladisteId { get; set; }
        public int NabavkaProizvodId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual NabavkaProizvod NabavkaProizvod { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public virtual ICollection<UlazProizvodStavke> UlazProizvodStavke { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Izlaz
    {
        public Izlaz()
        {
            IzlaziStavka = new HashSet<IzlaziStavka>();
        }

        public int IzlazId { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Zakljucena { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal IznosSaPdv { get; set; }
        public bool PovratNovca { get; set; }
        public int? KorisnikId { get; set; }
        public int NarudzbaId { get; set; }
        public int DostavaId { get; set; }
        public string BrojFakture { get; set; }

        public virtual Dostava Dostava { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Narudzba Narudzba { get; set; }
        public virtual ICollection<IzlaziStavka> IzlaziStavka { get; set; }
    }
}

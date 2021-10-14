using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class NabavkaProizvod
    {
        public NabavkaProizvod()
        {
            NabavkaProizvodStavka = new HashSet<NabavkaProizvodStavka>();
        }

        public int Id { get; set; }
        public string BrojNabavke { get; set; }
        public DateTime Datum { get; set; }
        public decimal Total { get; set; }
        public bool Poslana { get; set; }
        public int KorisnikId { get; set; }
        public int DobavljacId { get; set; }
        public int SkladisteId { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public virtual UlazProizvod UlazProizvod { get; set; }
        public virtual ICollection<NabavkaProizvodStavka> NabavkaProizvodStavka { get; set; }
    }
}

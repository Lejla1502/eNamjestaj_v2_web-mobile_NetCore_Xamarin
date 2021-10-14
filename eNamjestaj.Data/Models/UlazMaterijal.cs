using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class UlazMaterijal
    {
        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
        public string Napomena { get; set; }
        public decimal PDV { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int SkladisteId { get; set; }
        public virtual Skladiste Skladiste { get; set; }

        public int NabavkaMaterijalId { get; set; }
        public virtual NabavkaMaterijal NabavkaMaterijal { get; set; }
    }
}

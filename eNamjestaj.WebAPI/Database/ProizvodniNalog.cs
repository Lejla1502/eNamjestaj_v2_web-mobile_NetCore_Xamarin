using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class ProizvodniNalog
    {
        public int Id { get; set; }
        public string BrojNaloga { get; set; }
        public DateTime Datum { get; set; }
        public int SkladisteMaterijalaId { get; set; }
        public int SkladisteProizvodaId { get; set; }
        public int KorisnikId { get; set; }
        public int Kolicina { get; set; }
        public decimal TrosakPoProizvodu { get; set; }
        public decimal UkupnaCijena { get; set; }
        public bool Zakljucen { get; set; }
        public int ProizvodId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public virtual Skladiste SkladisteMaterijala { get; set; }
        public virtual Skladiste SkladisteProizvoda { get; set; }
    }
}

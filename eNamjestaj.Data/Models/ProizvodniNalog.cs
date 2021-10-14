using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public  class ProizvodniNalog
    {
        public int Id { get; set; }
        public string BrojNaloga { get; set; }
        public DateTime Datum { get; set; }
        public int SkladisteMaterijalaId { get; set; }
        [ForeignKey("SkladisteMaterijalaId")]
        public virtual Skladiste SkladisteMaterijala { get; set; }

        public int SkladisteProizvodaId { get; set; }
        [ForeignKey("SkladisteProizvodaId")]

        public virtual Skladiste SkladisteProizvoda { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
        public decimal TrosakPoProizvodu { get; set; }
        public decimal UkupnaCijena { get; set; }
        public bool Zakljucen { get; set; }
    }

}

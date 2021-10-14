using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class NabavkaProizvod
    {
        public int Id { get; set; }
        public  string BrojNabavke { get; set; }
        public decimal Total { get; set; }
        public DateTime Datum { get; set; }
        public bool Poslana { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int DobavljacId { get; set; }
        public virtual Dobavljac Dobavljac { get; set; }
        public int SkladisteId { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public virtual UlazProizvod UlazProizvod { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class UlazMaterijal
    {
        public UlazMaterijal()
        {
            UlazMaterijalStavke = new HashSet<UlazMaterijalStavke>();
        }

        public int Id { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
        public string Napomena { get; set; }
        public decimal Pdv { get; set; }
        public int KorisnikId { get; set; }
        public int SkladisteId { get; set; }
        public int NabavkaMaterijalId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual NabavkaMaterijal NabavkaMaterijal { get; set; }
        public virtual Skladiste Skladiste { get; set; }
        public virtual ICollection<UlazMaterijalStavke> UlazMaterijalStavke { get; set; }
    }
}

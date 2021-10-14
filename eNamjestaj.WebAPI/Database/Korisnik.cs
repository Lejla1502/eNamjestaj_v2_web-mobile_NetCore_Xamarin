using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            AutorizacijskiToken = new HashSet<AutorizacijskiToken>();
            Dostavljac = new HashSet<Dostavljac>();
            Izlaz = new HashSet<Izlaz>();
            Kupac = new HashSet<Kupac>();
            NabavkaMaterijal = new HashSet<NabavkaMaterijal>();
            NabavkaProizvod = new HashSet<NabavkaProizvod>();
            Proizvod = new HashSet<Proizvod>();
            ProizvodniNalog = new HashSet<ProizvodniNalog>();
            Skladiste = new HashSet<Skladiste>();
            UlazMaterijal = new HashSet<UlazMaterijal>();
            UlazProizvod = new HashSet<UlazProizvod>();
            Zaposlenik = new HashSet<Zaposlenik>();
        }

        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public int OpstinaId { get; set; }
        public int UlogaId { get; set; }
        public string TwoFactorUniqueKey { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public virtual Opstina Opstina { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public virtual ICollection<Dostavljac> Dostavljac { get; set; }
        public virtual ICollection<Izlaz> Izlaz { get; set; }
        public virtual ICollection<Kupac> Kupac { get; set; }
        public virtual ICollection<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public virtual ICollection<NabavkaProizvod> NabavkaProizvod { get; set; }
        public virtual ICollection<Proizvod> Proizvod { get; set; }
        public virtual ICollection<ProizvodniNalog> ProizvodniNalog { get; set; }
        public virtual ICollection<Skladiste> Skladiste { get; set; }
        public virtual ICollection<UlazMaterijal> UlazMaterijal { get; set; }
        public virtual ICollection<UlazProizvod> UlazProizvod { get; set; }
        public virtual ICollection<Zaposlenik> Zaposlenik { get; set; }
    }
}

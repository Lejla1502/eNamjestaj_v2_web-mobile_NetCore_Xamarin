using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Skladiste
    {
        public Skladiste()
        {
            IzlaziStavka = new HashSet<IzlaziStavka>();
            MaterijalSkladiste = new HashSet<MaterijalSkladiste>();
            NabavkaMaterijal = new HashSet<NabavkaMaterijal>();
            NabavkaProizvod = new HashSet<NabavkaProizvod>();
            ProizvodSkladiste = new HashSet<ProizvodSkladiste>();
            ProizvodniNalogSkladisteMaterijala = new HashSet<ProizvodniNalog>();
            ProizvodniNalogSkladisteProizvoda = new HashSet<ProizvodniNalog>();
            UlazMaterijal = new HashSet<UlazMaterijal>();
            UlazProizvod = new HashSet<UlazProizvod>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int KorisnikId { get; set; }
        public int VrstaSkladistaId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual VrstaSkladista VrstaSkladista { get; set; }
        public virtual ICollection<IzlaziStavka> IzlaziStavka { get; set; }
        public virtual ICollection<MaterijalSkladiste> MaterijalSkladiste { get; set; }
        public virtual ICollection<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public virtual ICollection<NabavkaProizvod> NabavkaProizvod { get; set; }
        public virtual ICollection<ProizvodSkladiste> ProizvodSkladiste { get; set; }
        public virtual ICollection<ProizvodniNalog> ProizvodniNalogSkladisteMaterijala { get; set; }
        public virtual ICollection<ProizvodniNalog> ProizvodniNalogSkladisteProizvoda { get; set; }
        public virtual ICollection<UlazMaterijal> UlazMaterijal { get; set; }
        public virtual ICollection<UlazProizvod> UlazProizvod { get; set; }
    }
}

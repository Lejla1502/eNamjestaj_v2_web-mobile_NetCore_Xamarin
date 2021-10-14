using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            IzlaziStavka = new HashSet<IzlaziStavka>();
            KatalogStavka = new HashSet<KatalogStavka>();
            NabavkaProizvodStavka = new HashSet<NabavkaProizvodStavka>();
            NarudzbaStavka = new HashSet<NarudzbaStavka>();
            ProizvodBoja = new HashSet<ProizvodBoja>();
            ProizvodniNalog = new HashSet<ProizvodniNalog>();
            Recenzija = new HashSet<Recenzija>();
            UlazProizvodStavke = new HashSet<UlazProizvodStavke>();
        }

        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Slika { get; set; }
        public int KorisnikId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public int? OpisProizvodaId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual OpisProizvoda OpisProizvoda { get; set; }
        public virtual VrstaProizvoda VrstaProizvoda { get; set; }
        public virtual DobavljacProizvod DobavljacProizvod { get; set; }
        public virtual Normativ Normativ { get; set; }
        public virtual ProizvodSkladiste ProizvodSkladiste { get; set; }
        public virtual ICollection<IzlaziStavka> IzlaziStavka { get; set; }
        public virtual ICollection<KatalogStavka> KatalogStavka { get; set; }
        public virtual ICollection<NabavkaProizvodStavka> NabavkaProizvodStavka { get; set; }
        public virtual ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual ICollection<ProizvodBoja> ProizvodBoja { get; set; }
        public virtual ICollection<ProizvodniNalog> ProizvodniNalog { get; set; }
        public virtual ICollection<Recenzija> Recenzija { get; set; }
        public virtual ICollection<UlazProizvodStavke> UlazProizvodStavke { get; set; }
    }
}

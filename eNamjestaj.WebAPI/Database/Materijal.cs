using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Materijal
    {
        public Materijal()
        {
            NabavkaMaterijalStavka = new HashSet<NabavkaMaterijalStavka>();
            NormativStavka = new HashSet<NormativStavka>();
            UlazMaterijalStavke = new HashSet<UlazMaterijalStavke>();
        }

        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }

        public virtual DobavljacMaterijal DobavljacMaterijal { get; set; }
        public virtual MaterijalSkladiste MaterijalSkladiste { get; set; }
        public virtual ICollection<NabavkaMaterijalStavka> NabavkaMaterijalStavka { get; set; }
        public virtual ICollection<NormativStavka> NormativStavka { get; set; }
        public virtual ICollection<UlazMaterijalStavke> UlazMaterijalStavke { get; set; }
    }
}

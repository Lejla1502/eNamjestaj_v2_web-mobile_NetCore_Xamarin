using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Boja
    {
        public Boja()
        {
            NarudzbaStavka = new HashSet<NarudzbaStavka>();
            ProizvodBoja = new HashSet<ProizvodBoja>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual ICollection<ProizvodBoja> ProizvodBoja { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Normativ
    {
        public Normativ()
        {
            NormativStavka = new HashSet<NormativStavka>();
        }

        public int Id { get; set; }
        public string BrojNormativa { get; set; }
        public int ProizvodId { get; set; }
        public DateTime Datum { get; set; }
        public bool Zakljucen { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual ICollection<NormativStavka> NormativStavka { get; set; }
    }
}

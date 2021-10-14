using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class AkcijskiKatalog
    {
        public AkcijskiKatalog()
        {
            KatalogStavka = new HashSet<KatalogStavka>();
        }

        public int Id { get; set; }
        public string Opis { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool Aktivan { get; set; }

        public virtual ICollection<KatalogStavka> KatalogStavka { get; set; }
    }
}

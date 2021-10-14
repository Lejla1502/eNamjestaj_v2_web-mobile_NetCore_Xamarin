using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class OpisProizvoda
    {
        public OpisProizvoda()
        {
            Proizvod = new HashSet<Proizvod>();
        }

        public int Id { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Proizvod> Proizvod { get; set; }
    }
}

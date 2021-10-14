using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class VrstaProizvoda
    {
        public VrstaProizvoda()
        {
            Proizvod = new HashSet<Proizvod>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Proizvod> Proizvod { get; set; }
    }
}

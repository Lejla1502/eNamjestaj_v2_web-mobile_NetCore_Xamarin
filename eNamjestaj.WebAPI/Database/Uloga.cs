using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Uloga
    {
        public Uloga()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int Id { get; set; }
        public string TipUloge { get; set; }

        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Drzava
    {
        public Drzava()
        {
            Kanton = new HashSet<Kanton>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Kanton> Kanton { get; set; }
    }
}

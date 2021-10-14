using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Opstina
    {
        public Opstina()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }
        public int KantonId { get; set; }

        public virtual Kanton Kanton { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}

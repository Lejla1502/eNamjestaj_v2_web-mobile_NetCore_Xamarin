using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Kanton
    {
        public Kanton()
        {
            Opstina = new HashSet<Opstina>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }

        public virtual Drzava Drzava { get; set; }
        public virtual ICollection<Opstina> Opstina { get; set; }
    }
}

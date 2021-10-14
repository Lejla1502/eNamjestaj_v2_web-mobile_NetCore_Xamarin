using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Dostava
    {
        public Dostava()
        {
            Izlaz = new HashSet<Izlaz>();
        }

        public int Id { get; set; }
        public string Tip { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<Izlaz> Izlaz { get; set; }
    }
}

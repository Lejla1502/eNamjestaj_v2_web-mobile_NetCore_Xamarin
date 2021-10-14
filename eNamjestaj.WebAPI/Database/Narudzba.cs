using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            NarudzbaStavka = new HashSet<NarudzbaStavka>();
            RadniNalog = new HashSet<RadniNalog>();
        }

        public int Id { get; set; }
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool Aktivna { get; set; }
        public bool Otkazano { get; set; }
        public bool NaCekanju { get; set; }
        public int KupacId { get; set; }
        public string DostavaId { get; set; }
        public decimal Total { get; set; }
        public bool Odbijena { get; set; }

        public virtual Kupac Kupac { get; set; }
        public virtual Izlaz Izlaz { get; set; }
        public virtual ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual ICollection<RadniNalog> RadniNalog { get; set; }
    }
}

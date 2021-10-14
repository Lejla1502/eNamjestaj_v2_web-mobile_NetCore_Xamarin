using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class IzlaziStavka
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Popust { get; set; }
        public int Kolicina { get; set; }
        public decimal Konacnacijena { get; set; }
        public int ProizvodId { get; set; }
        public int IzlazId { get; set; }
        public int SkladisteId { get; set; }

        public virtual Izlaz Izlaz { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public virtual Skladiste Skladiste { get; set; }
    }
}

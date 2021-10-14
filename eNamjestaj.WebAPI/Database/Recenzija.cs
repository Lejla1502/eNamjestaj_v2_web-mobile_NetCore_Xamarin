using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Recenzija
    {
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public decimal Ocjena { get; set; }
        public DateTime Datum { get; set; }
        public int ProizvodId { get; set; }
        public int KupacId { get; set; }

        public virtual Kupac Kupac { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}

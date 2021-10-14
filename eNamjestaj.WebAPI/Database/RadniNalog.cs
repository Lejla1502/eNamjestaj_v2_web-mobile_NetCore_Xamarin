using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class RadniNalog
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int? NarudzbaId { get; set; }
        public int DostavljacId { get; set; }

        public virtual Dostavljac Dostavljac { get; set; }
        public virtual Narudzba Narudzba { get; set; }
    }
}

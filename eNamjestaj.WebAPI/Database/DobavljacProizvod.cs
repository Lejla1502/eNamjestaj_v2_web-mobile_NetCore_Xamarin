using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class DobavljacProizvod
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int ProizvodId { get; set; }
        public int DobavljacId { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}

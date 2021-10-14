using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class DobavljacProizvod
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int ProizvodId { get; set; }

        public Proizvod Proizvod { get; set; }

        public int DobavljacId { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
    }
}

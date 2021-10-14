using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class UlazProizvodStavke
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }

        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        public int UlazProizvodId { get; set; }
        public virtual UlazProizvod UlazProizvod { get; set; }
    }
}

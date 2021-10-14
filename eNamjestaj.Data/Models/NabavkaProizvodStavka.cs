using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class NabavkaProizvodStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public int NabavkaProizvodId { get; set; }
        public virtual NabavkaProizvod NabavkaProizvod { get; set; }
        public decimal Cijena { get; set; }
        public decimal TotalStavka { get; set; }
    }
}

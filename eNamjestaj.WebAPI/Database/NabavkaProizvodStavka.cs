using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class NabavkaProizvodStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public int NabavkaProizvodId { get; set; }
        public decimal Cijena { get; set; }
        public decimal TotalStavka { get; set; }

        public virtual NabavkaProizvod NabavkaProizvod { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}

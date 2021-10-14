using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class NarudzbaStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public int NarudzbaId { get; set; }
        public int BojaId { get; set; }
        public decimal CijenaProizvoda { get; set; }
        public int PopustNaCijenu { get; set; }
        public decimal TotalStavke { get; set; }

        public virtual Boja Boja { get; set; }
        public virtual Narudzba Narudzba { get; set; }
        public virtual Proizvod Proizvod { get; set; }

        
    }
}

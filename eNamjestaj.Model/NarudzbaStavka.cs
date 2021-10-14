using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model
{
    public class NarudzbaStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public int NarudzbaId { get; set; }
        public int BojaId { get; set; }
        public decimal CijenaProizvoda { get; set; }
        public int PopustNaCijenu { get; set; }
        public decimal TotalStavke { get; set; }

    }
}

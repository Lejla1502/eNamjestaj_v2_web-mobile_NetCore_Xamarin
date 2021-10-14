using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class NarudzbaProizvodDisplayRequest
    {
        public string NazivProizvoda { get; set; }
        public decimal Cijena { get; set; }
        public decimal TotalStavka { get; set; }
        public int Kolicina { get; set; }
        public string Slika { get; set; }
        public string Boja { get; set; }
        public int NarudzbaStavkaId { get; set; }
    }
}

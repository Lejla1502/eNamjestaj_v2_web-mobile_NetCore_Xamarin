using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class ProizvodKatalogDisplayRequest
    {
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Slika { get; set; }
        public int Popust { get; set; }
        public decimal Cijena { get; set; }
        public decimal CijenaSaPopustom { get; set; }
        public int ProizvodId { get; set; }
    }
}

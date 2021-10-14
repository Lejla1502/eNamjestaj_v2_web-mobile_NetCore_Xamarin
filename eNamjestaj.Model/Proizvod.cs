using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model
{
    public class Proizvod
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Slika { get; set; }
        public int KorisnikId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public int? OpisProizvodaId { get; set; }
        //public int Popust { get; set; }

    }
}

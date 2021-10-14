using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class Materijal
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public DobavljacMaterijal DobavljacMaterijal { get; set; }
        public MaterijalSkladiste MaterijalSkladiste { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model
{
    public class IzlaziStavka
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Popust { get; set; }
        public int Kolicina { get; set; }
        public decimal Konacnacijena { get; set; }
        public int ProizvodId { get; set; }
        public int IzlazId { get; set; }
        public int SkladisteId { get; set; }

    }
}

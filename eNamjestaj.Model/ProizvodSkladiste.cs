using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model
{
    public class ProizvodSkladiste
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int SkladisteId { get; set; }
        public int ProizvodId { get; set; }

    }
}

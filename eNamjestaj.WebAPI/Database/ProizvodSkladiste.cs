using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class ProizvodSkladiste
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int SkladisteId { get; set; }
        public int ProizvodId { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual Skladiste Skladiste { get; set; }
    }
}

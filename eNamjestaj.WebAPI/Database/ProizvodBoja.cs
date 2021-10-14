using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class ProizvodBoja
    {
        public int BojaId { get; set; }
        public int ProizvodId { get; set; }

        public virtual Boja Boja { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}

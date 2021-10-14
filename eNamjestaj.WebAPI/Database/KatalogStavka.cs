using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class KatalogStavka
    {
        public int Id { get; set; }
        public int PopustProcent { get; set; }
        public int ProizvodId { get; set; }
        public int AkcijskiKatalogId { get; set; }

        public virtual AkcijskiKatalog AkcijskiKatalog { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}

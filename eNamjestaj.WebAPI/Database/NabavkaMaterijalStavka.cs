using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class NabavkaMaterijalStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int MaterijalId { get; set; }
        public int NabavkaMaterijalId { get; set; }
        public decimal Cijena { get; set; }
        public decimal TotalStavka { get; set; }

        public virtual Materijal Materijal { get; set; }
        public virtual NabavkaMaterijal NabavkaMaterijal { get; set; }
    }
}

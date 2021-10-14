using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class DobavljacMaterijal
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int MaterijalId { get; set; }
        public int DobavljacId { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
        public virtual Materijal Materijal { get; set; }
    }
}

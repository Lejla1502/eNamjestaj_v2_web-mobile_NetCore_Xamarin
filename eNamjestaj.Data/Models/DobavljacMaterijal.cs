using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class DobavljacMaterijal
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int MaterijalId { get; set; }

        public Materijal Materijal { get; set; }

        public int DobavljacId { get; set; }

        public virtual Dobavljac Dobavljac { get; set; }
    }
}

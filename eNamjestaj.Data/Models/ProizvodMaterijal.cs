using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class ProizvodMaterijal
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public int MaterijalId { get; set; }
        public virtual Materijal Materijal { get; set; }
    }
}

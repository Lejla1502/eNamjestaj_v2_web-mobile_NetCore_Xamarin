using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class UlazMaterijalStavke
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }

        public int MaterijalId { get; set; }
        public virtual Materijal Materijal { get; set; }
        public int UlazMaterijalId { get; set; }
        public virtual UlazMaterijal UlazMaterijal { get; set; }
    }
}

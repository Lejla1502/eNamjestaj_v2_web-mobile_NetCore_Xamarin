using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class UlazMaterijalStavke
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
        public int MaterijalId { get; set; }
        public int UlazMaterijalId { get; set; }

        public virtual Materijal Materijal { get; set; }
        public virtual UlazMaterijal UlazMaterijal { get; set; }
    }
}

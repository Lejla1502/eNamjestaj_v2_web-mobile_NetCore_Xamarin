using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
   public  class NabavkaMaterijalStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int MaterijalId { get; set; }
        public virtual Materijal Materijal { get; set; }
        public int NabavkaMaterijalId { get; set; }
        public virtual NabavkaMaterijal NabavkaMaterijal { get; set; }
        public decimal Cijena { get; set; }
        public decimal TotalStavka { get; set; }
    }
}

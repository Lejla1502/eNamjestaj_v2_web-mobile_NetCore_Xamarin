using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class NormativStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int MaterijalId { get; set; }
        public virtual Materijal Materijal { get; set; }


        public int NormativId { get; set; }
        public virtual Normativ Normativ { get; set; }
    }
}

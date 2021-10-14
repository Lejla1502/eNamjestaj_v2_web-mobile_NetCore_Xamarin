using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class NormativStavka
    {
        public int Id { get; set; }
        public int MaterijalId { get; set; }
        public int NormativId { get; set; }
        public int Kolicina { get; set; }

        public virtual Materijal Materijal { get; set; }
        public virtual Normativ Normativ { get; set; }
    }
}

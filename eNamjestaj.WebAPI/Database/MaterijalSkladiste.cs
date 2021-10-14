using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class MaterijalSkladiste
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int SkladisteId { get; set; }
        public int MaterijalId { get; set; }

        public virtual Materijal Materijal { get; set; }
        public virtual Skladiste Skladiste { get; set; }
    }
}

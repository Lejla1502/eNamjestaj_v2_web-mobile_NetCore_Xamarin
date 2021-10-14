using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class VrstaSkladista
    {
        public VrstaSkladista()
        {
            Skladiste = new HashSet<Skladiste>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Skladiste> Skladiste { get; set; }
    }
}

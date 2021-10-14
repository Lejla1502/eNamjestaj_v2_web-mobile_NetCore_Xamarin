using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Dobavljac
    {
        public Dobavljac()
        {
            DobavljacMaterijal = new HashSet<DobavljacMaterijal>();
            DobavljacProizvod = new HashSet<DobavljacProizvod>();
            NabavkaMaterijal = new HashSet<NabavkaMaterijal>();
            NabavkaProizvod = new HashSet<NabavkaProizvod>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }

        public virtual ICollection<DobavljacMaterijal> DobavljacMaterijal { get; set; }
        public virtual ICollection<DobavljacProizvod> DobavljacProizvod { get; set; }
        public virtual ICollection<NabavkaMaterijal> NabavkaMaterijal { get; set; }
        public virtual ICollection<NabavkaProizvod> NabavkaProizvod { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Dostavljac
    {
        public Dostavljac()
        {
            RadniNalog = new HashSet<RadniNalog>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string ZiroRacun { get; set; }
        public int KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<RadniNalog> RadniNalog { get; set; }
    }
}

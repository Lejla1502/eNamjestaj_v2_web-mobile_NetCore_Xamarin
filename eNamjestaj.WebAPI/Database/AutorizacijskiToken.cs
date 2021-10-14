using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class AutorizacijskiToken
    {
        public int Id { get; set; }
        public string Vrijednost { get; set; }
        public int KorisnikId { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
        public string IpAdresa { get; set; }

        public virtual Korisnik Korisnik { get; set; }
    }
}

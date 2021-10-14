using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class KupacInsertRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }
        public int KorisnikId { get; set; }
    }
}

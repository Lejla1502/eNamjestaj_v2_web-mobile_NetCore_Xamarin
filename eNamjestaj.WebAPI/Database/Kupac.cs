using System;
using System.Collections.Generic;

namespace eNamjestaj.WebAPI.Database
{
    public partial class Kupac
    {
        public Kupac()
        {
            Narudzba = new HashSet<Narudzba>();
            Recenzija = new HashSet<Recenzija>();
        }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Adresa { get; set; }
        public string Spol { get; set; }
        public int KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<Narudzba> Narudzba { get; set; }
        public virtual ICollection<Recenzija> Recenzija { get; set; }
    }
}

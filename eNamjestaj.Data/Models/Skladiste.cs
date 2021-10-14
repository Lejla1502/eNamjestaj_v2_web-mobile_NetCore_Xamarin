﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Skladiste
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int VrstaSkladistaId { get; set; }
        public virtual VrstaSkladista VrstaSkladista { get; set; }

    }
}

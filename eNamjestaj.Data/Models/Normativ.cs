using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class Normativ
    {
        public int Id { get; set; }
        public string BrojNormativa { get; set; }
        public DateTime Datum { get; set; }

        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        public bool Zakljucen { get; set; }
    }
}

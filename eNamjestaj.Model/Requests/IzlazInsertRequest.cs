using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class IzlazInsertRequest
    {
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Zakljucena { get; set; }
        public decimal IznosBezPdv { get; set; }
        public decimal IznosSaPdv { get; set; }
        public bool PovratNovca { get; set; }
        public int? KorisnikId { get; set; }
        public int NarudzbaId { get; set; }
        public int DostavaId { get; set; }
        public string BrojFakture { get; set; }

        //public ICollection<IzlaziStavka> IzlaziStavka { get; set; }

    }
}

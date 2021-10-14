using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class NarudzbaUpsertRequest
    {
       
        public string BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool Aktivna { get; set; }
        public bool Otkazano { get; set; }
        public bool NaCekanju { get; set; }
        public int KupacId { get; set; }
        public string DostavaId { get; set; }
        public decimal Total { get; set; }
        public bool Odbijena { get; set; }
    }
}

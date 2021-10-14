using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class RecenzijaInsertRequest
    {
        public string Sadrzaj { get; set; }
        public decimal Ocjena { get; set; }
        public DateTime Datum { get; set; }
        public int ProizvodId { get; set; }
        public int KupacId { get; set; }

    }
}

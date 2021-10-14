using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class NarudzbaHistorijaDisplayRequest
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Total { get; set; }
        public DateTime Datum { get; set; }
        public int BrStavki { get; set; }
        public string Status { get; set; }
    }
}

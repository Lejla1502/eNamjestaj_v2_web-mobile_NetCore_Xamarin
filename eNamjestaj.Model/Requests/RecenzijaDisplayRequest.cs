using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class RecenzijaDisplayRequest
    {
        public int Id { get; set; }
        public string Sadrzaj { get; set; }
        public int Ocjena { get; set; }
        public DateTime Datum { get; set; }
        public string Kupac { get; set; }
    }
}

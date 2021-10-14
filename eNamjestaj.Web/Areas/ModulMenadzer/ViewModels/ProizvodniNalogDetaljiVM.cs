using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class ProizvodniNalogDetaljiVM
    {
        public List<StavkeNalogaInfo> StavkeNaloga { get; set; }
        public string Nalog { get; set; }
        public class StavkeNalogaInfo
        {
            public string NazivMat { get; set; }
            public string Sifra { get; set; }
            public int Kol { get; set; }
            public decimal Cijena { get; set; }
            public decimal Ukupno { get; set; }
        }
    }
}

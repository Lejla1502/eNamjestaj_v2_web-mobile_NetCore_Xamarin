using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NormativStavkeIndexVM
    {

        public int NormativID { get;  set; }
        public bool NormativZakljucen { get; set; }
        public int BrStavki { get; set; }
        public List<NormativStavkeInfo> StavkeNormativa { get; set; }
        public class NormativStavkeInfo
        {
            public int Id { get; set; }
            public string NazivMaterijala { get; set; }
            public string Sifra { get; set; }
            
            public int Kol { get; set; }
        }
    }
}

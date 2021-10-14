using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NabavkaMaterijalStavkeIndexVM
    {
        public int NabavkaId { get; set; }
        public bool Zakljucena { get; set; }
        public int BrStavki { get; set; }
        public List<NabavkaMaterijalStavkeInfo> MaterijalStavkeNabavke { get; set; }

        public class NabavkaMaterijalStavkeInfo
        {
            public int Id { get; set; }
            public string Materijal { get; set; }
            public int Kol { get; set; }
            public decimal Cijena { get; set; }
            public decimal Total { get; set; }
            public int KolNaSkladistu { get; set; }
        }
    }
}

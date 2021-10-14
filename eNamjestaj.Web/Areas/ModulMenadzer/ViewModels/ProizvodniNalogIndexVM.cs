using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class ProizvodniNalogIndexVM
    {
        public List<NaloziInfo> Nalozi { get; set; }
        public DateTime? DatumPretraga { get; set; }
        public int? ProizvodIdPretraga { get; set; }
        public SelectList Proizvodi { get; set; }
        public class NaloziInfo
        {
            public int Id { get; set; }
            public string BrNaloga { get; set; }
            public DateTime Datum { get; set; }
            public string Proizvod { get; set; }
            public string SkladistePr { get; set; }
            public string SkladisteMat { get; set; }
            public string Korisnik { get; set; }
            public int Kol { get; set; }
            public decimal CijenaPojedinacno { get; set; }
            public decimal CijenaTotal { get; set; }
            public bool Zakljucen { get; set; }
            public int NormativId { get; set; }
            public bool ZakljucenNormativ { get; set; }
        }
    }
}

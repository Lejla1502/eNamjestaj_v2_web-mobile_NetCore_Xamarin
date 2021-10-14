using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NormativIndexVM
    {
        public List<NormInfo> Normativi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DatumPretraga { get; set; } = null;

        public class NormInfo
        {
            public int Id { get; set; }
            public string BrojNorm { get; set; }
            public DateTime Datum { get; set; }

            public string NazivProizvoda { get; set; }
            public bool Zakljucen { get; set; }
            public int BrojStavki { get; set; }
        }
    }
}

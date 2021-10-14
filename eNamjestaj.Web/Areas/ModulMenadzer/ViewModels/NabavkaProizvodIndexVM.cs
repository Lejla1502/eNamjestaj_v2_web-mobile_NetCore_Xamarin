using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NabavkaProizvodIndexVM
    {
        public List<NabavkaProizvodInfo> Nabavke { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DatumPretraga { get; set; }


        [MaxLength(25)]
        [MinLength(10)]
        public string BrojPretraga { get; set; }
        public class NabavkaProizvodInfo
        {
            public int Id { get; set; }
            public string BrojNabavke { get; set; }
            public DateTime Datum { get; set; }
            public string Skladiste { get; set; }
            public string KorisnikEvid { get; set; }
            public string Dobavljac { get; set; }
            public bool Zakljucena { get; set; }
            public int BrojStavki { get; set; }
        }
    }
}

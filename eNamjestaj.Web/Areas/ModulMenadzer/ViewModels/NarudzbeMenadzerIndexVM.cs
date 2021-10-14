using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NarudzbeMenadzerIndexVM
    {
        public List<NarudzbeInfo> Narudzbe { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime? DatumPretraga { get; set; } = null;

        public class NarudzbeInfo
        {
            public int Id { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumNarudzbe { get; set; }
            public string BrojNarudzbe { get; set; }
            public bool Status { get; set; }
        }
    }
}

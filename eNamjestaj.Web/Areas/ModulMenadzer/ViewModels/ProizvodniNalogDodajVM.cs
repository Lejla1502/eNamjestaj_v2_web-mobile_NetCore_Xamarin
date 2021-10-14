using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class ProizvodniNalogDodajVM
    {
        [Required(ErrorMessage = "Obavezno je odabrati proizvod")]
        public int ProizvodID { get; set; }
        public SelectList Proizvodi { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati odg. skladiste")]
        public int SkladistePrID { get; set; }
        public SelectList SkladistaPr { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati odg. skladiste")]
        public int SkladisteMatID { get; set; }
        public SelectList SkladistaMat { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [Range(1, 50, ErrorMessage = "Unesite cifru između 1 i 50")]
        public int Kol { get; set; }
    }
}

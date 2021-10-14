using System;
using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NormativStavkeDodajVM
    {
        public int NormativId { get; set; }
        [Required(ErrorMessage = "Obavezno je odabrati materijal")]
        public int MaterijalID { get; set; }
        public SelectList Materijali { get; set; }
        [Range(1, 5000, ErrorMessage = "Unesite cifru između 1 i 100")]
        public int Kol { get; set; }
    }
}

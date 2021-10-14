using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NabavkaProizvodStavkeDodajVM
    {
        public int NabavkaId { get; set; }

        [Range(1, 100, ErrorMessage = "Unesite cifru između 1 i 100")]
        public int Kol { get; set; }
        public string Cijena { get; set; }
        public string TotalStavka { get; set; }

        [Required(ErrorMessage = "Obavezno je odabrati proizvod")]
        public int ProizvodId { get; set; }
        public SelectList Proizvodi { get; set; }
    }
}

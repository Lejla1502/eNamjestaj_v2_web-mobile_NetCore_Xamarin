using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NabavkaProizvodDodajVM
    {
        [Required(ErrorMessage = "Obavezno je odabrati dobavljaca")]
        public int DobavljacID { get; set; }
        public SelectList Dobavljaci { get; set; }

        public string Skladiste { get; set; }
        public int SkladisteId { get; set; }
    }
}

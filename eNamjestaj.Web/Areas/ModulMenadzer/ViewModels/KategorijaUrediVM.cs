using System;
using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class KategorijaUrediVM
    {
        public int KategorijaID { get; set; }
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Mozete unositi samo slovne karaktere")]
        [Required(ErrorMessage = "Obavezno je unijeti naziv kategorije")]
        [MinLength(3, ErrorMessage = "Naziv mora sadrzavati minimalno 3 karaktera")]
        public string Naziv { get; set; }
    }
}

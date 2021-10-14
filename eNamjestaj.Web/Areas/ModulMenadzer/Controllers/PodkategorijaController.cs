using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class PodkategorijaController : Controller
    {
        private MojContext ctx;

        public PodkategorijaController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj()
        {

            return PartialView();
        }

        public IActionResult Snimi(PodkategorijaDodajVM model)
        {
            if (ModelState.IsValid)
            {
                VrstaProizvoda vp = new VrstaProizvoda
                {
                    Naziv = model.Naziv
                };
                ctx.VrstaProizvoda.Add(vp);
                ctx.SaveChanges();
                return RedirectToAction("Dodaj", "Kategorija");

            }
            else
            {
                return BadRequest(model);
            }
        }
    }
}

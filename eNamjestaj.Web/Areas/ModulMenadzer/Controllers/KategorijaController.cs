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
    public class KategorijaController : Controller
    {
        private MojContext ctx;

        public KategorijaController(MojContext context)
        {
            ctx = context;
        }
        public IActionResult Index()
        {
            KategorijaIndexVM model = new KategorijaIndexVM
            {
                Kategorije=ctx.VrstaProizvoda.OrderBy(x=>x.Naziv).Select(y=>new KategorijaIndexVM.KategorijeInfo
                {
                    Id=y.Id,
                    NazivKategorije=y.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Dodaj()
        {
            
            return View();
        }

        public IActionResult Uredi(int id)
        {
            VrstaProizvoda vp = ctx.VrstaProizvoda.Find(id);
            KategorijaUrediVM model = new KategorijaUrediVM
            {
                KategorijaID=vp.Id,
                Naziv=vp.Naziv
            };
            return View(model);
        }
        
       public IActionResult SnimiPostojecuKat(KategorijaUrediVM model)
        {
            if (ModelState.IsValid)
            {
                VrstaProizvoda vp = ctx.VrstaProizvoda.Find(model.KategorijaID);
                vp.Naziv = model.Naziv;
                ctx.SaveChanges();

                
                return RedirectToAction("Index", "Kategorija");
            }
            else
            {

                return BadRequest(ModelState);
            }
        }

            public IActionResult SnimiNovuKategoriju(KategorijaDodajVM model)
        {
            if (ModelState.IsValid)
            {
                VrstaProizvoda vp = new VrstaProizvoda
                {
                    Naziv=model.Naziv
                };

                ctx.VrstaProizvoda.Add(vp);
                ctx.SaveChanges();

                
                return RedirectToAction("Index", "Kategorija");
            }
            else
            {

                return BadRequest(ModelState);
            }
        
        }

        public IActionResult Obrisi(int id)
        {
            ctx.VrstaProizvoda.Remove(ctx.VrstaProizvoda.Find(id));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

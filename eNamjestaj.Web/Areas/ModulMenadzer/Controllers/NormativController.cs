using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class NormativController : Controller
    {
        private MojContext ctx;

        public NormativController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index(DateTime? DatumPretraga)
        {
            
                NormativIndexVM model = new NormativIndexVM();
            if (DatumPretraga == null)
            {
                //Include(p=>p.Proizvod)
                model.Normativi = ctx.Normativ.Select(x => new NormativIndexVM.NormInfo
                {
                    Id = x.Id,
                    BrojNorm = x.BrojNormativa,
                    Datum = x.Datum.Date,
                    NazivProizvoda = x.Proizvod.Naziv,
                    Zakljucen=x.Zakljucen,
                    BrojStavki=(ctx.NormativStavka.Where(ns=>ns.NormativId==x.Id).Count()>0)?(ctx.NormativStavka.Where(ns => ns.NormativId == x.Id).Count()):0
                }).ToList();
            }
            else
            {
                model.Normativi = ctx.Normativ.Where(x => x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString()).Select(x => new NormativIndexVM.NormInfo
                {
                    Id = x.Id,
                    BrojNorm = x.BrojNormativa,
                    Datum = x.Datum.Date,
                    NazivProizvoda = x.Proizvod.Naziv,
                    Zakljucen=x.Zakljucen,
                    BrojStavki = (ctx.NormativStavka.Where(ns => ns.NormativId == x.Id).Count() > 0)?(ctx.NormativStavka.Where(ns => ns.NormativId == x.Id).Count()) : 0

                }).ToList();
            }
            return View(model);
        }

        public IActionResult Dodaj()
        {
            //var proizvodList = ctx.Proizvod.Where(p=>p.OpisProizvodaId==1).Select(r => new { r.Id, r.Naziv }).ToList();


            var proizvodList=ctx.Proizvod.GroupJoin(ctx.Normativ,
                        proizvod => proizvod.Id,
                        normativ => normativ.ProizvodId,
                        (x, y) => new { Proizvod = x, Normativ = y }).SelectMany(
          x => x.Normativ.DefaultIfEmpty(),
          (x, y) => new { proizvod = x.Proizvod, Normativ = y })
    .Where(x=>x.Normativ == null && x.proizvod.OpisProizvodaId==1);

            var proizvodSelectList=proizvodList.Select(r => new { r.proizvod.Id, r.proizvod.Naziv }).ToList();


            NormativDodajVM model = new NormativDodajVM
            {
                Proizvodi = new SelectList(proizvodSelectList, "Id", "Naziv")
            }; 

            return PartialView(model);
        }

        public IActionResult Snimi(NormativDodajVM model)
        {
            if (ModelState.IsValid)
            {
                int broj = 0;
                if (ctx.Normativ.Count() != 0)
                    broj = Convert.ToInt32(ctx.Normativ.Last().BrojNormativa.Split('-').Last()) + 1;

                Normativ n = new Normativ
                {
                    BrojNormativa = "NORM-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + "-" + broj,
                    Datum = DateTime.Now,
                    ProizvodId = model.ProizvodID
                };

                ctx.Normativ.Add(n);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id)
        {
            ctx.Normativ.Remove(ctx.Normativ.Find(id));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Zakljuci(int id)
        {
            ctx.Normativ.Find(id).Zakljucen = true;
            ctx.SaveChanges();


            return RedirectToAction("Index");
        }
        
    }
}

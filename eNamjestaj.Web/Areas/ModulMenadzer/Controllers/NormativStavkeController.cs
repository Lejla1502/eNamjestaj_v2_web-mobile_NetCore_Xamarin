using Microsoft.AspNetCore.Mvc;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using eNamjestaj.Data.Models;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class NormativStavkeController : Controller
    {
        private MojContext ctx;
        public NormativStavkeController(MojContext contexxt)
        {
            ctx = contexxt;
        }
        public IActionResult Index(int id)
        {
            NormativStavkeIndexVM model = new NormativStavkeIndexVM
            {
                NormativID = id,
                NormativZakljucen=ctx.Normativ.Find(id).Zakljucen,
                BrStavki=ctx.NormativStavka.Where(ns=>ns.NormativId==id).Count(),
                StavkeNormativa = ctx.NormativStavka.Where(s => s.NormativId == id).Select(x => new NormativStavkeIndexVM.NormativStavkeInfo
                {
                    Id = x.Id,
                    NazivMaterijala = x.Materijal.Naziv,
                    Kol=x.Kolicina,
                    Sifra = x.Materijal.Sifra
                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Dodaj(int id)
        {
            var materijalList = ctx.Materijal.GroupJoin(ctx.NormativStavka,
                       materijal => materijal.Id,
                       normativstavka => normativstavka.MaterijalId,
                       (x, y) => new { Materijal = x, NormativStavka = y }).SelectMany(
         x => x.NormativStavka.DefaultIfEmpty(),
         (x, y) => new { materijal = x.Materijal, NormativStavka = y })
   .Where(x => x.NormativStavka.NormativId!=id).GroupBy(g => new { g.materijal.Id, g.materijal.Naziv }).ToList();

           
            var idMaterijalLista = ctx.Normativ.Join(ctx.NormativStavka,
                norm => norm.Id,
                normS => normS.NormativId,
                (x, y) => new { Normativ = x, NormativStavka = y }).Where(m => m.Normativ.Id == id).Select(x=>x.NormativStavka.MaterijalId).ToList();

            var materijalSelectList = materijalList.Select(r => new { r.Key.Id, r.Key.Naziv }).Where(m=>!idMaterijalLista.Any(x=>x==m.Id)).ToList().OrderBy(o=>o.Naziv);
            
            NormativStavkeDodajVM model = new NormativStavkeDodajVM
            {
                NormativId=id,
                Materijali = new SelectList(materijalSelectList, "Id", "Naziv")
            };
            return PartialView(model);
        }

        public IActionResult Snimi(NormativStavkeDodajVM model)
        {
            if (ModelState.IsValid)
            {
                NormativStavka ns = new NormativStavka
                {
                    NormativId = model.NormativId,
                    MaterijalId = model.MaterijalID,
                    Kolicina = model.Kol
                };

                ctx.NormativStavka.Add(ns);
                ctx.SaveChanges();

                return RedirectToAction("Index", new { @id = model.NormativId });
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id,int idNormativ)
        {
            ctx.NormativStavka.Remove(ctx.NormativStavka.Find(id));
            ctx.SaveChanges();

            return RedirectToAction("Index", new { @id = idNormativ });
        }
    }
}

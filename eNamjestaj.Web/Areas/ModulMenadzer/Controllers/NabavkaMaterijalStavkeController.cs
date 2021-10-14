using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
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
    public class NabavkaMaterijalStavkeController : Controller
    {
        private MojContext ctx;
        public NabavkaMaterijalStavkeController(MojContext contexxt)
        {
            ctx = contexxt;
        }
        public IActionResult Index(int id)
        {
            NabavkaMaterijalStavkeIndexVM model = new NabavkaMaterijalStavkeIndexVM
            {
                NabavkaId = id,
                Zakljucena=ctx.NabavkaMaterijal.Find(id).Poslana,
                BrStavki = ctx.NabavkaMaterijalStavka.Where(x => x.NabavkaMaterijalId == id).Count(),
                MaterijalStavkeNabavke = ctx.NabavkaMaterijalStavka.Where(s => s.NabavkaMaterijalId == id).Select(x => new NabavkaMaterijalStavkeIndexVM.NabavkaMaterijalStavkeInfo
                {
                    Id = x.Id,
                    Materijal = x.Materijal.Naziv,
                    Cijena = x.Cijena,
                    KolNaSkladistu = ctx.MaterijalSkladiste.Where(ps => ps.MaterijalId == x.MaterijalId).First().Kolicina,
                    Kol = x.Kolicina,
                    Total = x.TotalStavka
                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Dodaj(int id)
        {
            NabavkaMaterijal n = ctx.NabavkaMaterijal.Find(id);

            var materijalList = ctx.Materijal.GroupJoin(ctx.NabavkaMaterijalStavka,
                       materijal => materijal.Id,
                       nabavkastavka => nabavkastavka.MaterijalId,
                       (x, y) => new { Materijal = x, NabavkaMaterijalStavka = y }).SelectMany(
         x => x.NabavkaMaterijalStavka.DefaultIfEmpty(),
         (x, y) => new { materijal = x.Materijal, NabavkaMaterijalStavka = y })
   .Where(x => x.NabavkaMaterijalStavka.NabavkaMaterijalId != id).GroupBy(g => new { g.materijal.Id, g.materijal.Naziv }).ToList();


            var idMaterijalLista = ctx.NabavkaMaterijal.Join(ctx.NabavkaMaterijalStavka,
                nab => nab.Id,
                nabS => nabS.NabavkaMaterijalId,
                (x, y) => new { NabavkaMaterijal = x, NabavkaMaterijalStavka = y }).Where(m => m.NabavkaMaterijal.Id == id).Select(x => x.NabavkaMaterijalStavka.MaterijalId).ToList();

            var materijalSelectList = materijalList.Select(r => new { r.Key.Id, r.Key.Naziv }).Where(m => !idMaterijalLista.Any(x => x == m.Id)).ToList().OrderBy(o=>o.Naziv);



            //var materijaliList = ctx.Materijal.Where(p => p.DobavljacMaterijal.DobavljacId == n.DobavljacId).Select(r => new { r.Id, r.Naziv }).ToList();
            //else
            //    proizvodiList=ctx.Materijal.Where(m=>m.DobavljacMaterijal.DobavljacId==n.DobavljacId).Select(r => new { r.Id, r.Naziv }).ToList();
            NabavkaMaterijalStavkeDodajVM model = new NabavkaMaterijalStavkeDodajVM
            {
                NabavkaId = id,
                Materijali = new SelectList(materijalSelectList, "Id", "Naziv")
            };
            return PartialView(model);
        }

        public IActionResult Snimi(NabavkaMaterijalStavkeDodajVM model)
        {
            if (ModelState.IsValid)
            {
                NabavkaMaterijalStavka ns = new NabavkaMaterijalStavka
                {
                    NabavkaMaterijalId = model.NabavkaId,
                    MaterijalId = model.MaterijalId,
                    Kolicina = model.Kol,
                    Cijena = ctx.DobavljacMaterijal.Where(x => x.MaterijalId == model.MaterijalId).First().Cijena,
                    TotalStavka = ctx.DobavljacMaterijal.Where(x => x.MaterijalId == model.MaterijalId).First().Cijena * model.Kol
                };

                ctx.NabavkaMaterijalStavka.Add(ns);
                ctx.SaveChanges();

                return RedirectToAction("Index", new { @id = model.NabavkaId });
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id, int idNabavka)
        {
            ctx.NabavkaMaterijalStavka.Remove(ctx.NabavkaMaterijalStavka.Find(id));
            ctx.SaveChanges();

            return RedirectToAction("Index", new { @id = idNabavka });
        }
    }
}

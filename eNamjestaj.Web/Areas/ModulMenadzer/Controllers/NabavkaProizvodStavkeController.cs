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
    public class NabavkaProizvodStavkeController : Controller
    {
        private MojContext ctx;
        public NabavkaProizvodStavkeController(MojContext contexxt)
        {
            ctx = contexxt;
        }
        public IActionResult Index(int id)
        {
           
           
                NabavkaProizvodStavkeIndexVM model = new NabavkaProizvodStavkeIndexVM
                {
                    NabavkaId = id,
                    Zakljucena = ctx.NabavkaProizvod.Find(id).Poslana,
                    BrReda = ctx.NabavkaProizvod.Find(id).BrojNabavke,
                    BrStavki = ctx.NabavkaProizvodStavka.Where(x => x.NabavkaProizvodId == id).Count(),
                    StavkeNabavke = ctx.NabavkaProizvodStavka.Where(s => s.NabavkaProizvodId == id).Select(x => new NabavkaProizvodStavkeIndexVM.NabavkaProizvodStavkeInfo
                    {
                        Id = x.Id,
                        Proizvod = x.Proizvod.Naziv,
                        Cijena = x.Cijena,
                        KolNaSkladistu = ctx.ProizvodSkladiste.Where(ps => ps.ProizvodId == x.ProizvodId).First().Kolicina,
                        Kol = x.Kolicina,
                        Total = x.TotalStavka
                    }).ToList()
                };


                return PartialView(model);
           
        }

        public IActionResult Dodaj(int id)
        {
            NabavkaProizvod n = ctx.NabavkaProizvod.Find(id);



            var proizvodList = ctx.Proizvod.GroupJoin(ctx.NabavkaProizvodStavka,
                      proizvod => proizvod.Id,
                      nabavkastavka => nabavkastavka.ProizvodId,
                      (x, y) => new { Proizvod = x, NabavkaProizvodStavka = y }).SelectMany(
        x => x.NabavkaProizvodStavka.DefaultIfEmpty(),
        (x, y) => new { proizvod = x.Proizvod, NabavkaProizvodStavka = y })
  .Where(x => x.NabavkaProizvodStavka.NabavkaProizvodId != id && x.proizvod.OpisProizvodaId==2 && x.proizvod.DobavljacProizvod.DobavljacId==n.DobavljacId).GroupBy(g => new { g.proizvod.Id, g.proizvod.Naziv }).ToList();

            // var groupP = proizvodList.GroupBy(g => new { g.proizvod.Id, g.proizvod.Naziv }).ToList();
            //         var proizvodSelectList = proizvodList.Select(r => new { r.proizvod.Id, r.proizvod.Naziv }).ToList();

            var idProizvodLista = ctx.NabavkaProizvod.Join(ctx.NabavkaProizvodStavka,
                nab => nab.Id,
                nabS => nabS.NabavkaProizvodId,
                (x, y) => new { NabavkaProizvod = x, NabavkaProizvodStavka = y }).Where(m => m.NabavkaProizvod.Id == id).Select(x => x.NabavkaProizvodStavka.ProizvodId).ToList();

            var proizvodSelectList = proizvodList.Select(r => new { r.Key.Id, r.Key.Naziv }).Where(m => !idProizvodLista.Any(x => x == m.Id)).ToList().OrderBy(o => o.Naziv);


            //var proizvodiList = ctx.Proizvod.Where(p=>p.DobavljacProizvod.DobavljacId==n.DobavljacId).Select(r => new { r.Id, r.Naziv }).ToList();
            //else
            //    proizvodiList=ctx.Materijal.Where(m=>m.DobavljacMaterijal.DobavljacId==n.DobavljacId).Select(r => new { r.Id, r.Naziv }).ToList();
            NabavkaProizvodStavkeDodajVM model = new NabavkaProizvodStavkeDodajVM
            {
                NabavkaId = id,
                Proizvodi = new SelectList(proizvodSelectList, "Id", "Naziv")
            };
            return PartialView(model);
        }

        public IActionResult Snimi(NabavkaProizvodStavkeDodajVM model)
        {
            if (ModelState.IsValid)
            {
                NabavkaProizvodStavka ns = new NabavkaProizvodStavka
                {
                    NabavkaProizvodId = model.NabavkaId,
                    ProizvodId = model.ProizvodId,
                    Kolicina = model.Kol,
                    Cijena = ctx.DobavljacProizvod.Where(x => x.ProizvodId == model.ProizvodId).First().Cijena,
                    TotalStavka = ctx.DobavljacProizvod.Where(x => x.ProizvodId == model.ProizvodId).First().Cijena * model.Kol
                };

                ctx.NabavkaProizvodStavka.Add(ns);
                ctx.SaveChanges();

                return RedirectToAction("Index", new { @id = model.NabavkaId });
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id, int idNabavka)
        {
            ctx.NabavkaProizvodStavka.Remove(ctx.NabavkaProizvodStavka.Find(id));
            ctx.SaveChanges();

            //if (ctx.NabavkaProizvodStavka.Where(ns=>ns.NabavkaProizvodId==idNabavka).Count() > 0)
                return RedirectToAction("Index", new { @id = idNabavka });
         //   else
             //   return RedirectToAction("Index", "NabavkaProizvod");
        }
    }
}

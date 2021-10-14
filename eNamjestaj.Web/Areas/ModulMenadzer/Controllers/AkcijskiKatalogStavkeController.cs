using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class AkcijskiKatalogStavkeController : Controller
    {
        private MojContext ctx;

        public AkcijskiKatalogStavkeController(MojContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index(int katalogId)
        {
            AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(katalogId);
            AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
            {
                KatalogId = katalogId,
                Aktivan = ctx.AkcijskiKatalog.Find(katalogId).Aktivan,
                KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                {
                    Id = x.Id,
                    Proizvod = x.Proizvod.Naziv,
                    Cijena = x.Proizvod.Cijena,
                    Procenat = x.PopustProcent,
                    KonacnaCijena = Convert.ToDecimal(x.Proizvod.Cijena - (x.Proizvod.Cijena * x.PopustProcent / 100))
                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Dodaj(int katalogId)
        {
            /*var listP = ctx.Proizvod.GroupJoin(ctx.KatalogStavka,
                proizvod => proizvod.Id,
                katalog => katalog.ProizvodId,
                (x, y) => new { Proizvod = x, KatalogStavka = y }).SelectMany(
                x => x.KatalogStavka.DefaultIfEmpty(),
                (x, y) => new { proizvod = x.Proizvod, KatalogStavka = y })
                .Where(x => x.KatalogStavka.AkcijskiKatalogId != katalogId).GroupBy(g => new { g.proizvod.Id, g.proizvod.Naziv }).ToList();
            */
            var idProizvodLista = ctx.AkcijskiKatalog.Join(ctx.KatalogStavka,
               ak => ak.Id,
               ks => ks.AkcijskiKatalogId,
               (x, y) => new { AkcijskiKatalog = x, KatalogStavka = y }).Where(m => m.AkcijskiKatalog.Id == katalogId).Select(x => x.KatalogStavka.ProizvodId).ToList();

            //var proizvodSelectList = listP.Select(r => new { r.Key.Id, r.Key.Naziv }).Where(m => !idProizvodLista.Any(x => x == m.Id)).ToList().OrderBy(o => o.Naziv);
            var proizvodSelectList=ctx.Proizvod.Select(s=>new { s.Id, s.Naziv}).Where(m => !idProizvodLista.Any(x => x == m.Id)).ToList().OrderBy(o => o.Naziv);

        AkcijskiKatalogStavkeDodajVM model = new AkcijskiKatalogStavkeDodajVM
            {
                
            Proizvodi = new SelectList(proizvodSelectList, "Id", "Naziv"),
                KatalogID = katalogId
            };

            return PartialView(model);
        }

        public IActionResult Obrisi(int katalogId, int stavkaId)
        {
            KatalogStavka ks = ctx.KatalogStavka.Find(stavkaId);
            ctx.KatalogStavka.Remove(ks);
            ctx.SaveChanges();

            return RedirectToAction("Index", "AkcijskiKatalogStavke", new { @katalogId = katalogId });
        }


        public IActionResult Snimi(AkcijskiKatalogStavkeDodajVM a)
        {
            if (ModelState.IsValid)
            {
                KatalogStavka ks = new KatalogStavka
                {
                    PopustProcent = a.Procenat,
                    ProizvodId = a.ProizvodID,
                    AkcijskiKatalogId = a.KatalogID
                };

                ctx.KatalogStavka.Add(ks);
                ctx.SaveChanges();

                int katalogId = a.KatalogID;
                //AkcijskiKatalog ak = ctx.AkcijskiKatalog.Find(a.KatalogID);
                //AkcijskiKatalogStavkeIndexVM model = new AkcijskiKatalogStavkeIndexVM
                //{
                //    KatalogId = katalogId,
                //    KatalogProizvodi = ctx.KatalogStavka.Where(y => y.AkcijskiKatalogId == ak.Id).Select(x => new AkcijskiKatalogStavkeIndexVM.ProizvodiInfo
                //    {
                //        Id = x.Id,
                //        Proizvod = x.Proizvod.Naziv,
                //        Cijena = x.Proizvod.Cijena,
                //        Procenat = x.PopustProcent,
                //        KonacnaCijena =x.Proizvod.Cijena-(x.Proizvod.Cijena * x.PopustProcent / 100)
                //    }).ToList()
                //};
                return RedirectToAction("Index", "AkcijskiKatalogStavke", new { @katalogId = katalogId });
            }
            else
            {
                

                return BadRequest(ModelState);
            }
        }

    }
}
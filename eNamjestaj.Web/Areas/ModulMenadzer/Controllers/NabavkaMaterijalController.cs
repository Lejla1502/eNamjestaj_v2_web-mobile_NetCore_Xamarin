using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class NabavkaMaterijalController : Controller
    {
        private MojContext ctx;
        public NabavkaMaterijalController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index(DateTime? DatumPretraga, string BrojPretraga)
        {
            if (string.IsNullOrEmpty(BrojPretraga))
                BrojPretraga = null;
            NabavkaMaterijalIndexVM model = new NabavkaMaterijalIndexVM();
            if (DatumPretraga == null && string.IsNullOrEmpty(BrojPretraga))
            {
                model.Nabavke = ctx.NabavkaMaterijal.Select(x => new NabavkaMaterijalIndexVM.NabavkaInfo
                {
                    Id = x.Id,
                    BrojNabavke = x.BrojNabavke,
                    Datum = x.Datum,
                    KorisnikEvid = ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Ime + ' ' + ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Prezime,
                    Skladiste = x.Skladiste.Naziv,
                    Dobavljac = x.Dobavljac.Naziv,
                    Zakljucena = x.Poslana,
                    BrojStavki = (ctx.NabavkaMaterijalStavka.Where(v => v.NabavkaMaterijalId == x.Id).Count() > 0) ? ctx.NabavkaMaterijalStavka.Where(v => v.NabavkaMaterijalId == x.Id).Count() : 0
                }).ToList();
            }
            else
            {
                model.Nabavke = ctx.NabavkaMaterijal.Where(x=> x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString() && BrojPretraga == null ||
                                       (( x.BrojNabavke.Equals(BrojPretraga) && DatumPretraga == null) ||
                                       (x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString() && x.BrojNabavke.Equals(BrojPretraga)))
                                    ).Select(x => new NabavkaMaterijalIndexVM.NabavkaInfo
                                    {
                                        Id = x.Id,
                                        BrojNabavke = x.BrojNabavke,
                                        Datum = x.Datum,
                                        KorisnikEvid = ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Ime + ' ' + ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Prezime,
                                        Skladiste = x.Skladiste.Naziv,
                                        Dobavljac = x.Dobavljac.Naziv,
                                        Zakljucena = x.Poslana,
                                        BrojStavki = (ctx.NabavkaMaterijalStavka.Where(v => v.NabavkaMaterijalId == x.Id).Count() > 0) ? ctx.NabavkaMaterijalStavka.Where(v => v.NabavkaMaterijalId == x.Id).Count() : 0
                                    }).ToList();
            }

            return View(model);
        }

        public IActionResult Dodaj()
        {
            var dobavljacId = ctx.DobavljacMaterijal.Select(x => new { x.DobavljacId, x.Dobavljac.Naziv }).ToList().GroupBy(g => new { g.DobavljacId, g.Naziv });


            
            var dobavljacList = dobavljacId.Select(p => new { p.Key.DobavljacId, p.Key.Naziv }).ToList();
            
            NabavkaMaterijalDodajVM model = new NabavkaMaterijalDodajVM
            {
                Dobavljaci = new SelectList(dobavljacList, "DobavljacId", "Naziv"),
                Skladiste = ctx.Skladiste.Where(s => s.Id == 2).First().Naziv,
                SkladisteId = 2 //matSkl
            };

            return View(model);
        }

        public IActionResult Snimi(NabavkaMaterijalDodajVM model)
        {
            if (ModelState.IsValid)
            {
                int broj = 0;
                if (ctx.NabavkaMaterijal.Count() != 0)
                    broj = Convert.ToInt32(ctx.NabavkaMaterijal.Last().BrojNabavke.Split('-').Last()) + 1;

                NabavkaMaterijal n = new NabavkaMaterijal
                {
                    Datum = DateTime.Now,
                    BrojNabavke = "NAB-MAT-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + broj,
                    DobavljacId = model.DobavljacID,
                    SkladisteId = model.SkladisteId,
                    KorisnikId = HttpContext.GetLogiraniKorisnik().Id
                };
                ctx.NabavkaMaterijal.Add(n);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id)
        {
            NabavkaMaterijal ns = ctx.NabavkaMaterijal.Find(id);

            List<NabavkaMaterijalStavka> stavke = ctx.NabavkaMaterijalStavka.Where(x => x.NabavkaMaterijalId == ns.Id).ToList();

            foreach (var n in stavke)
            {
                ctx.NabavkaMaterijalStavka.Remove(n);
                ctx.SaveChanges();
            }

            ctx.NabavkaMaterijal.Remove(ns);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Zakljuci(int id)
        {
            NabavkaMaterijal n = ctx.NabavkaMaterijal.Find(id);
            n.Poslana = true;
            int br = 1;
            if (ctx.UlazMaterijal.Count() > 0)
                br = Convert.ToInt32(ctx.UlazMaterijal.Last().BrojFakture.Split('-').Last()) + 1;

            UlazMaterijal u = new UlazMaterijal
            {
                BrojFakture = "ULZRCN-MAT-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-"+br,
                Datum = DateTime.Today,
                IznosRacuna = n.Total,
                PDV = Convert.ToDecimal(17),
                KorisnikId = HttpContext.GetLogiraniKorisnik().Id,
                SkladisteId = n.SkladisteId,
                NabavkaMaterijalId=n.Id
            };

            ctx.UlazMaterijal.Add(u);
            ctx.SaveChanges();

            foreach (var ns in ctx.NabavkaMaterijalStavka.Where(j => j.NabavkaMaterijalId == n.Id).Include(q => q.Materijal).ToList())
            {
                UlazMaterijalStavke us = new UlazMaterijalStavke
                {
                    UlazMaterijalId = u.Id,
                    MaterijalId = ns.MaterijalId,
                    Cijena = ns.Cijena,
                    Kolicina = ns.Kolicina
                };
                ctx.UlazMaterijalStavke.Add(us);
            }

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

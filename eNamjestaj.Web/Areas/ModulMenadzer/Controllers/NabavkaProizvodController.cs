using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using Microsoft.AspNetCore.Mvc;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using eNamjestaj.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class NabavkaProizvodController : Controller
    {
        private MojContext ctx;
        public NabavkaProizvodController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index(DateTime? DatumPretraga,string BrojPretraga)
        {
            if (string.IsNullOrEmpty(BrojPretraga))
                BrojPretraga = null;
            NabavkaProizvodIndexVM model = new NabavkaProizvodIndexVM();
            if (DatumPretraga == null && BrojPretraga==null)
            {
                model.Nabavke = ctx.NabavkaProizvod.Select(x => new NabavkaProizvodIndexVM.NabavkaProizvodInfo
                {
                    Id = x.Id,
                    BrojNabavke = x.BrojNabavke,
                    Datum = x.Datum,
                    KorisnikEvid = ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Ime + ' ' + ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Prezime,
                    Skladiste = x.Skladiste.Naziv,
                    Dobavljac = x.Dobavljac.Naziv,
                    Zakljucena = x.Poslana,
                    BrojStavki = (ctx.NabavkaProizvodStavka.Where(v => v.NabavkaProizvodId == x.Id).Count() > 0) ? ctx.NabavkaProizvodStavka.Where(v => v.NabavkaProizvodId == x.Id).Count() : 0
                }).ToList();
            }
            else
            {
                model.Nabavke = ctx.NabavkaProizvod.Where(x => x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString() && BrojPretraga == null ||
                                       ((x.BrojNabavke.Equals(BrojPretraga) && DatumPretraga == null) ||
                                       (x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString() && x.BrojNabavke.Equals(BrojPretraga)))
                                    ).Select(x => new NabavkaProizvodIndexVM.NabavkaProizvodInfo
                                    {
                                        Id = x.Id,
                                        BrojNabavke = x.BrojNabavke,
                                        Datum = x.Datum,
                                        KorisnikEvid = ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Ime + ' ' + ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Prezime,
                                        Skladiste = x.Skladiste.Naziv,
                                        Dobavljac = x.Dobavljac.Naziv,
                                        Zakljucena = x.Poslana,
                                        BrojStavki = (ctx.NabavkaProizvodStavka.Where(v => v.NabavkaProizvodId == x.Id).Count() > 0) ? ctx.NabavkaProizvodStavka.Where(v => v.NabavkaProizvodId == x.Id).Count() : 0
                                    }).ToList();
            }

            return View(model);
        }

        public IActionResult Dodaj()
        {
          
            var dobavljacId = ctx.DobavljacProizvod.Select(x => new { x.DobavljacId,x.Dobavljac.Naziv }).ToList().GroupBy(g=>new { g.DobavljacId, g.Naziv });

            var pr = dobavljacId.Select(p => new { p.Key.DobavljacId, p.Key.Naziv }).ToList();
            NabavkaProizvodDodajVM model = new NabavkaProizvodDodajVM
            {
                Dobavljaci = new SelectList(pr, "DobavljacId", "Naziv"),
                
                Skladiste=ctx.Skladiste.Where(s=>s.Id==1).First().Naziv,
                SkladisteId=1
            };

            return View(model);
        }

        public IActionResult Snimi(NabavkaProizvodDodajVM model)
        {
            if (ModelState.IsValid)
            {
                int broj = 0;
                if (ctx.NabavkaProizvod.Count() != 0)
                    broj = Convert.ToInt32(ctx.NabavkaProizvod.Last().BrojNabavke.Split('-').Last()) + 1;

                NabavkaProizvod n = new NabavkaProizvod
                {
                    Datum = DateTime.Now,
                    BrojNabavke = "NAB-PR-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + broj,
                    DobavljacId = model.DobavljacID,
                    SkladisteId = model.SkladisteId,
                    KorisnikId = HttpContext.GetLogiraniKorisnik().Id
                };
                ctx.NabavkaProizvod.Add(n);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        public IActionResult Obrisi(int id)
        {
            NabavkaProizvod ns = ctx.NabavkaProizvod.Find(id);

            List<NabavkaProizvodStavka> stavke = ctx.NabavkaProizvodStavka.Where(x => x.NabavkaProizvodId == ns.Id).ToList();

            foreach (var n in stavke)
            {
                ctx.NabavkaProizvodStavka.Remove(n);
                ctx.SaveChanges();
            }

            ctx.NabavkaProizvod.Remove(ns);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Zakljuci(int id)
        {
            NabavkaProizvod n = ctx.NabavkaProizvod.Find(id);
            n.Poslana = true;
            n.Total = ctx.NabavkaProizvodStavka.Where(ns => ns.NabavkaProizvodId == id).Sum(s=>s.TotalStavka);
            
            int br = 1;
            if(ctx.UlazProizvod.Count()>0)
                br= Convert.ToInt32(ctx.UlazProizvod.Last().BrojFakture.Split('-').Last()) + 1;

            UlazProizvod u = new UlazProizvod 
            {
                BrojFakture="ULZRCN-PRO-"+DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day+"-"+br,
                Datum=DateTime.Today,
                IznosRacuna=n.Total,
                PDV=Convert.ToDecimal(17),
                KorisnikId=HttpContext.GetLogiraniKorisnik().Id,
                SkladisteId=n.SkladisteId,
                NabavkaProizvodId=n.Id
            };

            ctx.UlazProizvod.Add(u);
            ctx.SaveChanges();

            foreach (var ns in ctx.NabavkaProizvodStavka.Where(j => j.NabavkaProizvodId == n.Id).Include(q => q.Proizvod).ToList())
            {
                //!!!!!!!!!!!!DA LI POVECATI KOLICINU NA SKLADISTU 
                // ctx.ProizvodSkladiste.Where(ps => ps.ProizvodId == ns.ProizvodId).First().Kolicina += ns.Kolicina;
                //ctx.SaveChanges();

                UlazProizvodStavke us = new UlazProizvodStavke
                {
                    UlazProizvodId=u.Id,
                    ProizvodId=ns.ProizvodId,
                    Cijena=ns.Cijena,
                    Kolicina=ns.Kolicina
                };
                ctx.UlazProizvodStavke.Add(us);
            }

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

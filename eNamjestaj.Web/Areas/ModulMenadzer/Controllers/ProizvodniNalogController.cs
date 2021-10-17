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

    public class ProizvodniNalogController : Controller
    {
        private MojContext ctx;

        public ProizvodniNalogController(MojContext context)
        {
            ctx = context;
        }

        public IActionResult Index(DateTime? DatumPretraga, int? ProizvodIdPretraga)
        {
            if (ctx.Normativ.Count() > 0)
            {
                var proizvodiList = ctx.Proizvod.Where(p => p.OpisProizvodaId == 1).Select(x => new { x.Id, x.Naziv }).ToList();

                ProizvodniNalogIndexVM model = new ProizvodniNalogIndexVM();
                model.Proizvodi = new SelectList(proizvodiList, "Id", "Naziv");
                if (ProizvodIdPretraga == 0 || ProizvodIdPretraga == -1)
                    ProizvodIdPretraga = null;
                if (DatumPretraga == null && ProizvodIdPretraga == null)
                {

                    model.Nalozi = ctx.ProizvodniNalog.Select(x => new ProizvodniNalogIndexVM.NaloziInfo
                    {
                        Id = x.Id,
                        BrNaloga = x.BrojNaloga,
                        Proizvod = x.Proizvod.Naziv,
                        Datum = x.Datum,
                        Korisnik = ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Ime + ' ' + ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Prezime,
                        SkladisteMat = ctx.Skladiste.Where(s => s.Id == x.SkladisteMaterijalaId).First().Naziv,
                        SkladistePr = ctx.Skladiste.Where(s => s.Id == x.SkladisteProizvodaId).First().Naziv,
                        Kol = x.Kolicina,
                        CijenaPojedinacno = x.TrosakPoProizvodu,
                        CijenaTotal = x.UkupnaCijena,
                        Zakljucen = x.Zakljucen,
                        NormativId = ctx.Normativ.Where(no => no.ProizvodId == x.ProizvodId).First().Id,
                        ZakljucenNormativ = ctx.Normativ.Where(no => no.ProizvodId == x.ProizvodId).First().Zakljucen
                    }).ToList();
                }
                else
                {
                    model.Nalozi = ctx.ProizvodniNalog.Where(x => x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString() && ProizvodIdPretraga == null ||
                                           ((x.ProizvodId == ProizvodIdPretraga && DatumPretraga == null) ||
                                           (x.Datum.ToShortDateString() == Convert.ToDateTime(DatumPretraga).ToShortDateString() && x.ProizvodId == ProizvodIdPretraga))
                                        ).Select(x => new ProizvodniNalogIndexVM.NaloziInfo
                                        {
                                            Id = x.Id,
                                            BrNaloga = x.BrojNaloga,
                                            Proizvod = x.Proizvod.Naziv,
                                            Datum = x.Datum,
                                            Korisnik = ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Ime + ' ' + ctx.Zaposlenik.Where(z => z.KorisnikId == x.KorisnikId).First().Prezime,
                                            SkladisteMat = ctx.Skladiste.Where(s => s.Id == x.SkladisteMaterijalaId).First().Naziv,
                                            SkladistePr = ctx.Skladiste.Where(s => s.Id == x.SkladisteProizvodaId).First().Naziv,
                                            Kol = x.Kolicina,
                                            CijenaPojedinacno = x.TrosakPoProizvodu,
                                            CijenaTotal = x.UkupnaCijena,
                                            Zakljucen = x.Zakljucen,
                                            NormativId = ctx.Normativ.Where(no => no.ProizvodId == x.ProizvodId).First().Id,
                                            ZakljucenNormativ = ctx.Normativ.Where(no => no.ProizvodId == x.ProizvodId).First().Zakljucen
                                        }).ToList();
                }

                return View(model);
            }
            else
                return View(null);
        }

        public IActionResult Dodaj()
        {

            //var proizvodList = ctx.Normativ.Select(x => new { x.Proizvod.Id, x.Proizvod.Naziv }).ToList();

            /* var proizvodList = ctx.Proizvod.GroupJoin(ctx.ProizvodniNalog,
                        proizvod => proizvod.Id,
                        pNalog => pNalog.ProizvodId,
                        (x, y) => new { Proizvod = x, ProizvodniNalog = y }).SelectMany(
          x => x.ProizvodniNalog.DefaultIfEmpty(),
          (x, y) => new { proizvod = x.Proizvod, ProizvodniNalog = y })
          .Where(x => x.ProizvodniNalog == null && x.proizvod.OpisProizvodaId == 1 && x.proizvod.Normativ.Zakljucen == true);

             */

            var proizvodList = ctx.Proizvod.Include(p => p.Normativ).Where(n => n.Normativ.Zakljucen == true).ToList();
            var proizvodSelectList = proizvodList.Select(r => new { r.Id, r.Naziv }).ToList();

            var skladisteMatList = ctx.Skladiste.Where(s => s.VrstaSkladistaId == 1).Select(x => new { x.Id, x.Naziv }).ToList();
            var skladistePrList = ctx.Skladiste.Where(s => s.VrstaSkladistaId == 2).Select(x => new { x.Id, x.Naziv }).ToList();


            ProizvodniNalogDodajVM model = new ProizvodniNalogDodajVM
            {
                Proizvodi = new SelectList(proizvodSelectList, "Id", "Naziv"),
                SkladistaMat = new SelectList(skladisteMatList, "Id", "Naziv"),
                SkladistaPr = new SelectList(skladistePrList, "Id", "Naziv")
            };



            return View(model);

        }

        public IActionResult Snimi(ProizvodniNalogDodajVM model)
        {
            if (ModelState.IsValid)
            {
                int broj = 0;

                if (ctx.ProizvodniNalog.Count() != 0)
                    broj = Convert.ToInt32(ctx.ProizvodniNalog.Last().BrojNaloga.Split('-').Last()) + 1;


                ProizvodniNalog pn = new ProizvodniNalog
                {
                    BrojNaloga = "NALOG-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + broj,
                    Datum = DateTime.Now,
                    KorisnikId = HttpContext.GetLogiraniKorisnik().Id,
                    ProizvodId = model.ProizvodID,
                    SkladisteMaterijalaId = model.SkladisteMatID,
                    SkladisteProizvodaId = model.SkladistePrID,
                    Kolicina = model.Kol,
                    TrosakPoProizvodu = ctx.Proizvod.Where(p => p.Id == model.ProizvodID).First().Cijena,
                    UkupnaCijena = model.Kol * (ctx.Proizvod.Where(p => p.Id == model.ProizvodID).First().Cijena),
                    Zakljucen = false
                };

                ctx.ProizvodniNalog.Add(pn);
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id)
        {
            ctx.ProizvodniNalog.Remove(ctx.ProizvodniNalog.Find(id));
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Zakljuci(int id)
        {
            ProizvodniNalog pn = ctx.ProizvodniNalog.Find(id);
            pn.Zakljucen = true;

            Normativ n = ctx.Normativ.Where(no => no.ProizvodId == pn.ProizvodId).First();
            foreach (var x in ctx.NormativStavka.Where(ns => ns.NormativId == n.Id).ToList())
            {
                ctx.MaterijalSkladiste.Where(ms => ms.MaterijalId == x.MaterijalId).First().Kolicina -= x.Kolicina;
            }

            ctx.ProizvodSkladiste.Where(ps => ps.ProizvodId == pn.ProizvodId).First().Kolicina += pn.Kolicina;
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Uredi(int id)
        {
            ProizvodniNalog pn = ctx.ProizvodniNalog.Find(id);


            var skladisteMatList = ctx.Skladiste.Where(s => s.VrstaSkladistaId == 1).Select(x => new { x.Id, x.Naziv }).ToList();
            var skladistePrList = ctx.Skladiste.Where(s => s.VrstaSkladistaId == 2).Select(x => new { x.Id, x.Naziv }).ToList();

            ProizvodniNalogUrediVM pnv = new ProizvodniNalogUrediVM
            {
                Id = pn.Id,
                BrNaloga = pn.BrojNaloga,
                SkladisteMatID = pn.SkladisteMaterijalaId,
                SkladistePrID = pn.SkladisteProizvodaId,
                ProizvodId = pn.ProizvodId,
                Proizvod = ctx.Proizvod.Find(pn.ProizvodId).Naziv,
                SkladistaMat = new SelectList(skladisteMatList, "Id", "Naziv"),
                SkladistaPr = new SelectList(skladistePrList, "Id", "Naziv"),
                Kol = pn.Kolicina
            };

            return View(pnv);
        }

        public IActionResult SnimiEditovaniNalog(ProizvodniNalogUrediVM model)
        {
            if (ModelState.IsValid)
            {
                ProizvodniNalog pn = ctx.ProizvodniNalog.Find(model.Id);

                pn.ProizvodId = model.ProizvodId;
                pn.SkladisteMaterijalaId = model.SkladisteMatID;
                pn.SkladisteProizvodaId = model.SkladistePrID;
                pn.Kolicina = model.Kol;
                pn.TrosakPoProizvodu = ctx.Proizvod.Where(p => p.Id == model.ProizvodId).First().Cijena;
                pn.UkupnaCijena = model.Kol * (ctx.Proizvod.Where(p => p.Id == model.ProizvodId).First().Cijena);

                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Detalji(int? id, int? nalogId)
        {
            ProizvodniNalogDetaljiVM model = new ProizvodniNalogDetaljiVM();

            if (id == null || id == 0)
                model = null;
            else
            {
                model.Nalog = ctx.ProizvodniNalog.Find(nalogId).BrojNaloga;
                model.StavkeNaloga = ctx.NormativStavka.Where(s => s.NormativId == id).Select(x => new ProizvodniNalogDetaljiVM.StavkeNalogaInfo
                {
                    NazivMat = x.Materijal.Naziv,
                    Sifra = x.Materijal.Sifra,
                    Cijena = x.Materijal.Cijena,
                    Kol = x.Kolicina,
                    Ukupno = x.Materijal.Cijena * x.Kolicina
                }).ToList();
            }


            return View(model);
        }
    }
}

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
using Microsoft.EntityFrameworkCore;

namespace eNamjestaj.Web.Areas.ModulMenadzer.Controllers
{
    [Audit]
    [Autorizacija(false, false, true, false)]
    [Area("ModulMenadzer")]
    public class NarudzbeMenadzerController : Controller
    {
        private MojContext ctx;

        public NarudzbeMenadzerController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index(DateTime? DatumPretraga)
        {
            NarudzbeMenadzerIndexVM model = new NarudzbeMenadzerIndexVM();
            if (DatumPretraga == null)
            {
                model.Narudzbe = ctx.Narudzba.Where(x => x.NaCekanju == true).Select(y => new NarudzbeMenadzerIndexVM.NarudzbeInfo
                {
                    Id = y.Id,
                    Ime = y.Kupac.Ime,
                    Prezime = y.Kupac.Prezime,
                    DatumNarudzbe = y.Datum,
                    BrojNarudzbe = y.BrojNarudzbe,
                    Status = y.Status
                }).ToList();
            }
            else 
            {
                model.Narudzbe = ctx.Narudzba.Where(x => x.NaCekanju == true &&  x.Datum.ToShortDateString()== Convert.ToDateTime(DatumPretraga).ToShortDateString()).Select(y => new NarudzbeMenadzerIndexVM.NarudzbeInfo
                {
                    Id = y.Id,
                    Ime = y.Kupac.Ime,
                    Prezime = y.Kupac.Prezime,
                    DatumNarudzbe = y.Datum,
                    BrojNarudzbe = y.BrojNarudzbe,
                    Status = y.Status
                }).ToList();
            }
            
            return View(model);
        }

        /*public IActionResult Procesiraj(int id)
        {
            Narudzba n = ctx.Narudzba.Where(x => x.Id == id).FirstOrDefault();

            //decimal totalDec = Convert.ToDecimal(total);

            Izlaz i = new Izlaz
            {
                NarudzbaId = id,
                BrojNarudzbe = n.BrojNarudzbe,
                Datum = DateTime.Now,
                Zakljucena = false,
                IznosSaPDV = n.Total,
                IznosBezPDV = n.Total - (n.Total / 17),
                DostavaId = Convert.ToInt32(n.DostavaId),
                //SkladisteId = 1
            };
            ctx.Izlaz.Add(i);
            ctx.SaveChanges();

            foreach (var x in ctx.NarudzbaStavka.Where(x => x.NarudzbaId == id).Include(q => q.Proizvod).ToList())
            {
                IzlazStavka ns = new IzlazStavka
                {
                    Cijena = x.CijenaProizvoda,
                    Popust = x.PopustNaCijenu,
                    Konacnacijena = x.TotalStavke,
                    Kolicina = x.Kolicina,
                    ProizvodId = x.ProizvodId,
                    IzlazId = i.IzlazId
                };
                ctx.IzlaziStavka.Add(ns);
            }

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }*/

        public IActionResult Detalji(int id)
        {
            decimal PDV = Convert.ToDecimal(17) /Convert.ToDecimal(100);
            NarudzbeMenadzerDetaljiVM model = ctx.Narudzba.Where(x => x.Id == id).Select(y => new NarudzbeMenadzerDetaljiVM
            {
                NarudzbaID=id,
                BrojNarudzbe = y.BrojNarudzbe,
                ImePrezime = y.Kupac.Ime+" "+y.Kupac.Prezime,
                Adresa = y.Kupac.Adresa,
                Datum = y.Datum.Date,
                Dostava = ctx.Dostava.Where(d => d.Id == Convert.ToInt32(y.DostavaId)).First().Tip,
                Status = y.Status,
                TotalBezPDVa = y.Total,
                TotalSaPDVom = Convert.ToDecimal((y.Total + (y.Total * PDV)).ToString("#.##")),
                BrojPutaOtkazao=ctx.Narudzba.Where(nr=>nr.KupacId==y.KupacId && nr.Otkazano).Count(),
                StavkeNarudzbe = ctx.NarudzbaStavka.Where(n => n.NarudzbaId == id).Select(ns => new NarudzbeMenadzerDetaljiVM.NarudzbaStavkeInfo
                {
                    NazivProizvoda=ns.Proizvod.Naziv,
                    Kolicina=ns.Kolicina,
                    Boja=ns.Boja.Naziv,
                    Cijena=ns.CijenaProizvoda,
                    Popust=ns.PopustNaCijenu,
                    KonacnaCijena = ((ns.CijenaProizvoda - (ns.CijenaProizvoda * ns.PopustNaCijenu / 100))).ToString("0.00"),
                    TotalStavka = ns.TotalStavke,
                    DostupnaKolicinaNaSkladistu=ctx.ProizvodSkladiste.Where(sk=>sk.ProizvodId==ns.ProizvodId).First().Kolicina
                    
                }).ToList()


            }).FirstOrDefault();

            model.daLiIjednaStavkaManjkaNaStanju = false;
            foreach (var x in model.StavkeNarudzbe)
            {
                if (x.DostupnaKolicinaNaSkladistu < x.Kolicina)
                    model.daLiIjednaStavkaManjkaNaStanju = true;
            }

            return PartialView(model);
        }

        public IActionResult Odbij(int id)
        {
            Narudzba n = ctx.Narudzba.Find(id);
            n.Odbijena = true;
            n.Status = false;
            n.NaCekanju = false;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Odobri(int id)
        {
            Narudzba n = ctx.Narudzba.Find(id);
            n.NaCekanju = false;

      

           int br = 1;
            if(ctx.Izlaz.Count()>0)
                br= Convert.ToInt32(ctx.Izlaz.Last().BrojNarudzbe.Split('-').Last()) + 1;

            decimal PDV = Convert.ToDecimal( 17 )/Convert.ToDecimal( 100);

            Izlaz i = new Izlaz 
            {
                NarudzbaId = n.Id,
                BrojNarudzbe = n.BrojNarudzbe,
                BrojFakture="IZLRAC-"+DateTime.Now.Year+"-"+DateTime.Now.Month+"-"+DateTime.Now.Day+br,
                Datum = DateTime.Now,
                Zakljucena = true,
                IznosSaPDV = n.Total+(n.Total*PDV),
                IznosBezPDV = n.Total ,
                DostavaId = Convert.ToInt32(n.DostavaId),
                KorisnikId=HttpContext.GetLogiraniKorisnik().Id
                //SkladisteId = n.
            };

            ctx.Izlaz.Add(i);
            ctx.SaveChanges();

            

            foreach (var x in ctx.NarudzbaStavka.Where(x => x.NarudzbaId == n.Id).Include(q => q.Proizvod).ToList())
            {
                ctx.ProizvodSkladiste.Where(ps => ps.ProizvodId == x.ProizvodId).First().Kolicina -= x.Kolicina;
                ctx.SaveChanges();

                IzlazStavka ns = new IzlazStavka
                {
                    Cijena = x.CijenaProizvoda,
                    Popust = x.PopustNaCijenu,
                    Konacnacijena = x.TotalStavke,
                    Kolicina = x.Kolicina,
                    ProizvodId = x.ProizvodId,
                    SkladisteId=ctx.ProizvodSkladiste.Where(ps=>ps.ProizvodId==x.ProizvodId).First().SkladisteId,
                    IzlazId = i.IzlazId
                };
                ctx.IzlaziStavka.Add(ns);
            }

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

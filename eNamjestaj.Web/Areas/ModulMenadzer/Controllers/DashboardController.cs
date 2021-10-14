using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
    public class DashboardController : Controller
    {
        private MojContext ctx;
        public DashboardController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            /*var izlazi = ctx.Izlaz.Join(ctx.IzlaziStavka,
                i => i.IzlazId,
                iz => iz.IzlazId,
                (x, y) => new { Izlaz = x, IzlazStavka = y }).Where(x => x.Izlaz.Zakljucena == true).GroupBy(g => g.IzlazStavka.ProizvodId);*/

            var pok = ctx.IzlaziStavka.Include(y=>y.Izlaz).GroupBy(ns => ns.Izlaz.Datum.Month).Select(s => new { Month = s.Key, Count = s.Count() }).ToList();

            //querying za prvi izvjestaj

            var mjesecCountPar = new List<Tuple<int, int>>();
            List<int> listaProdanihPoMjesecu = new List<int>();
            for (int i = 1; i < 13; i++)
            { 
                foreach (var p in pok)
                {
                    if (p.Month == i)
                    {
                        if (mjesecCountPar.Contains(new Tuple<int, int>(i, 0)))
                           mjesecCountPar.Remove(mjesecCountPar.Where(m => m.Item1 == i).First());
                        mjesecCountPar.Add(new Tuple<int, int>(i, p.Count));
                    }
                    else
                    {
                        if (!mjesecCountPar.Contains(new Tuple<int, int>(i, 0)) && mjesecCountPar.Where(x=>x.Item1==i && x.Item2>0).Count()<1) 
                            mjesecCountPar.Add(new Tuple<int, int>(i, 0));
                    }
                } 
            }
          



            var stavkePoMjesecima = ctx.IzlaziStavka.Select(s => new { s.Izlaz.Datum.Month }).GroupBy(g => g.Month).ToList();


            //querying za drugi izvjestaj

            var zakljuceniIzlazi=ctx.Izlaz.Where(i => i.Zakljucena == true);
            var pok2 = ctx.IzlaziStavka.Include(y => y.Izlaz).Where(y=>y.Izlaz.Zakljucena==true).GroupBy(izst=>izst.Proizvod.Naziv)
                .Select(s => new { Naziv = s.Key, Sum = s.Sum(kol=>kol.Kolicina) }).OrderByDescending(o=>o.Sum).Take(5).ToList();
           
            var listNazivaNajprodavanijihProizvoda = new List<string>();
            var listaSumaProizvoda = new List<int>();
            foreach (var p in pok2)
            {
                listNazivaNajprodavanijihProizvoda.Add(p.Naziv);
                listaSumaProizvoda.Add(p.Sum);
            }

            int brStavkiKataloga = 0;

            if (ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).Count() > 0)
            {
                var aktivniKatalog = ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).First();


                brStavkiKataloga= ctx.KatalogStavka.Where(ks => ks.AkcijskiKatalogId == aktivniKatalog.Id).GroupBy(g => g.ProizvodId).ToList().Count();
            }
            DateTime datumPrije24sata=DateTime.Now - TimeSpan.FromDays(1);

            decimal sum = 0;
            foreach (var s in ctx.Izlaz.Where(x => x.Zakljucena == true && x.Datum<=DateTime.Now && x.Datum>=datumPrije24sata).ToList())
                sum += s.IznosSaPDV;

            var listaIzlazaZadnja24Sata = ctx.IzlaziStavka.Include(y => y.Izlaz)
               .Where(i => i.Izlaz.Zakljucena == true && i.Izlaz.Datum <= DateTime.Now && i.Izlaz.Datum >= datumPrije24sata).Count();


            DashboardViewModel model = new DashboardViewModel
            {
                BrProdanihProizvoda = listaIzlazaZadnja24Sata,
                BrKorisnika = ctx.Korisnik.Count(),
                BrProizvoda = ctx.Proizvod.Count(),
                BrProizvodaNaSnizenju = brStavkiKataloga,
                BrProdanihProizvodaPoMjesecima = mjesecCountPar.GroupBy(g => new { g.Item1, g.Item2 }).Select(s=>s.Key.Item2).ToList(),
                KolicineNajprodavanijihProizvoda=listaSumaProizvoda,
                NaziviNajprodavanijihProizvoda=listNazivaNajprodavanijihProizvoda,
                DatumOd=ctx.AkcijskiKatalog.Where(a=>a.Aktivan==true).Count()>0?ctx.AkcijskiKatalog.Where(a=>a.Aktivan==true).First().DatumPocetka.Date:new DateTime(),
                DatumDo= ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).Count() > 0 ? ctx.AkcijskiKatalog.Where(a => a.Aktivan == true).First().DatumZavrsetka.Date:new DateTime(),
                Zarada=sum
            };

            return View(model);
        }
    }
}

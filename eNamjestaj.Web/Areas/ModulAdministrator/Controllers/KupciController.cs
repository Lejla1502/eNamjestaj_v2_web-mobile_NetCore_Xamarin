using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulAdministrator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace eNamjestaj.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true, false, false, false)]
    //[Audit]
    [Area("ModulAdministrator")]
    public class KupciController : Controller
    {
        private MojContext ctx ;

        public KupciController(MojContext _ctx)
        {
            ctx = _ctx;
        }

        public IActionResult Index(string KupciPretraga, int P=1, int S=5)
        {
            if (string.IsNullOrEmpty(KupciPretraga))
            {
                KupciIndexVM model = new KupciIndexVM
                {
                    P=P,
                    S=S,
                    TotalRecords=ctx.Kupac.Count(),
                    Kupci =ctx.Kupac.Select(x => new KupciIndexVM.KorisnikInfo
                    {
                        KupacId = x.Id,
                        KorisnickoIme = x.Korisnik.KorisnickoIme,
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        Email = x.Email,
                        Adresa = x.Adresa
                    }).OrderBy(s=>s.Ime).Skip((P - 1) * 5).Take(S).ToList()

                };
                //model.Kupci.Skip((model.P - 1) * model.S).Take(model.S).ToList();
                
                 return View(model);
            }
            else
            {
                KupciIndexVM model = new KupciIndexVM
                {
                    P=P,
                    S=S,
                    Kupci = ctx.Kupac.Where(k => string.Concat(k.Ime, k.Prezime).Contains(KupciPretraga)).Select(x => new KupciIndexVM.KorisnikInfo
                    {
                        
                        KupacId = x.Id,
                        KorisnickoIme = x.Korisnik.KorisnickoIme,
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        Email = x.Email,
                        Adresa = x.Adresa
                    }).OrderBy(s=>s.Ime).Skip((P - 1) * 5).Take(S).ToList(),
                    

                };
                model.TotalRecords = model.Kupci.Count();

                return View(model);
            }
        }
        public IActionResult Uredi(int kupacId)
        {
            Kupac kupac = ctx.Kupac.Where(x => x.Id == kupacId).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == kupac.KorisnikId).First();
            KupciUrediVM model = new KupciUrediVM
            {
                KupacId = kupacId,
                Ime = kupac.Ime,
                Prezime = kupac.Prezime,
                KorisnickoIme = k.KorisnickoIme,
               // Lozinka = k.Lozinka,
               // PotvrdaLozinke = k.Lozinka
            };

            return PartialView(model);
        }

        public IActionResult Obrisi(int id)
        {

            Kupac kupac = ctx.Kupac.Where(x => x.Id == id).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == kupac.KorisnikId).First();

            ctx.Kupac.Remove(kupac);
            ctx.SaveChanges();
            ctx.Korisnik.Remove(k);
            ctx.SaveChanges();

            List<Narudzba> n = ctx.Narudzba.Where(x => x.KupacId == id && (x.NaCekanju==true || x.Aktivna==true )).ToList();

            var idNarudzbaStavkaLista = n.Join(ctx.NarudzbaStavka,
              nar => nar.Id,
              narS => narS.NarudzbaId,
              (x, y) => new { Narudzba = x, NarudzbaStavka = y }).Select(x => x.NarudzbaStavka.Id).ToList();


            List<NarudzbaStavka> ns =ctx.NarudzbaStavka.Where(y=>idNarudzbaStavkaLista.Any(x => x == y.Id)).ToList();

            foreach (var stavka in ns)
            {
                ctx.NarudzbaStavka.Remove(stavka);
            }

            ctx.SaveChanges();

            foreach (var narudzba in n)
            {
                ctx.Narudzba.Remove(narudzba);
            }

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Snimi(KupciUrediVM model)
        {
            if (ModelState.IsValid)
            {
                Kupac kupac = ctx.Kupac.Where(x => x.Id == model.KupacId).First();
                Korisnik k = ctx.Korisnik.Where(x => x.Id == kupac.KorisnikId).First();
                k.KorisnickoIme = model.KorisnickoIme;
                //k.LozinkaHash = PasswordSettings.GetHash(model.Lozinka, Convert.FromBase64String(k.LozinkaSalt));

                k.LozinkaSalt = GenerateSalt();
                k.LozinkaHash = GenerateHash(k.LozinkaSalt, model.Lozinka);


                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return BadRequest(ModelState);
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }



        public IActionResult VerifyUsername(string KorisnickoIme, int KupacId)
        {
            Kupac kupac = ctx.Kupac.Where(x => x.Id == KupacId).First();

            Korisnik ko = ctx.Korisnik.Where(x => x.Id == kupac.KorisnikId).First();
            List<Korisnik> korisnici = ctx.Korisnik.ToList();
            foreach (Korisnik k in korisnici)
            {
                if (k.Id != ko.Id)
                {
                    if (k.KorisnickoIme == KorisnickoIme)
                        return Json($"Korisnicko ime {KorisnickoIme} već postoji");
                }

            }
            return Json(true);
        }

        public IActionResult ProvjeraPassworda(string PotvrdaLozinke, string Lozinka)
        {
            if (PotvrdaLozinke.Equals(Lozinka))
                return Json(true);
            return Json("Sifre se ne podudaraju");
        }
    }
}
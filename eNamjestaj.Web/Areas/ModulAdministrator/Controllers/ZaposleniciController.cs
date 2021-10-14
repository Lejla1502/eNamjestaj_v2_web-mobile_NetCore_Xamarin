using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Areas.ModulAdministrator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eNamjestaj.Web.Areas.ModulAdministrator.Controllers
{
    [Autorizacija(true, false, false, false)]
    //[Audit]
    [Area("ModulAdministrator")]
    public class ZaposleniciController : Controller
    {
        private MojContext ctx;

        public ZaposleniciController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index(string ZaposlenikPretraga)
        {
            if (string.IsNullOrEmpty(ZaposlenikPretraga))
            {
                ZaposleniciIndexVM model = new ZaposleniciIndexVM
                {
                    Zaposlenici = ctx.Zaposlenik.Select(x => new ZaposleniciIndexVM.KorisnikInfo
                    {
                        ZaposlenikId = x.Id,
                        KorisnickoIme = x.Korisnik.KorisnickoIme,
                        Ime = x.Ime, 
                        Prezime = x.Prezime,
                        Uloga = x.Korisnik.Uloga.TipUloge,
                        Email = x.Email,
                        Telefon = x.Telefon
                    }).ToList()
                };
                return View(model);
            }
            else
            {
                ZaposleniciIndexVM model = new ZaposleniciIndexVM
                {
                    Zaposlenici = ctx.Zaposlenik.Where(z => string.Concat(z.Ime, z.Prezime).Contains(ZaposlenikPretraga)).Select(x => new ZaposleniciIndexVM.KorisnikInfo
                    {
                        ZaposlenikId = x.Id,
                        KorisnickoIme = x.Korisnik.KorisnickoIme,
                        Ime = x.Ime,
                        Prezime = x.Prezime,
                        Uloga = x.Korisnik.Uloga.TipUloge,
                        Email = x.Email,
                        Telefon = x.Telefon
                    }).ToList()
                };
                return View(model);
            }

           
        }

        public IActionResult Uredi(int zaposlenikId)
        {
            Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == zaposlenikId).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == z.KorisnikId).First();
            ZaposleniciUrediVM model = new ZaposleniciUrediVM
            {
                ZaposlenikId = zaposlenikId,
                Ime = z.Ime,
                Prezime = z.Prezime,
                KorisnickoIme = k.KorisnickoIme,
                UlogaID = k.UlogaId,
                Uloge = ctx.Uloga.Where(u=>u.Id!=5).ToList()
            };

            return PartialView(model);
        }

        public IActionResult Snimi(ZaposleniciUrediVM model)
        {
            if (ModelState.IsValid)
            {
                Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == model.ZaposlenikId).First();
                Korisnik k = ctx.Korisnik.Where(x => x.Id == z.KorisnikId).First();
                k.KorisnickoIme = model.KorisnickoIme;

                k.UlogaId = model.UlogaID;
                ctx.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Obrisi(int id)
        {

            Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == id).First();
            Korisnik k = ctx.Korisnik.Where(y => y.Id == z.KorisnikId).First();

            ctx.Zaposlenik.Remove(z);
            ctx.SaveChanges();
            ctx.Korisnik.Remove(k);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Dodaj()
        {
            ZaposleniciDodajVM model = new ZaposleniciDodajVM
            {
                Opstine = ctx.Opstina.ToList(),
                Uloge = ctx.Uloga.Where(u=>u.Id!=5).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SpremiNovogZaposlenika(ZaposleniciDodajVM model)
        {
            if (ModelState.IsValid)
            {

                byte[] lozinkaSalt = PasswordSettings.GetSalt();
                string lozinkaHash = PasswordSettings.GetHash(model.Lozinka, lozinkaSalt);

                Korisnik k = new Korisnik
                {
                    KorisnickoIme = model.KorisnickoIme,
                    LozinkaHash = lozinkaHash,
                    LozinkaSalt = Convert.ToBase64String(lozinkaSalt),
                    OpstinaId = model.OpstinaId,
                    UlogaId = model.UlogaId
                };
                ctx.Korisnik.Add(k);
                ctx.SaveChanges();

                Zaposlenik z = new Zaposlenik
                {
                    Ime = model.Ime,
                    Prezime = model.Prezime,
                    Email = model.Email,
                    Adresa = model.Adresa,
                    Telefon = model.Telefon,
                    KorisnikId = k.Id
                };
                ctx.Zaposlenik.Add(z);
                ctx.SaveChanges();

                return RedirectToAction("Dodaj");
            }
            else
                return BadRequest(ModelState);
        }



        public IActionResult VerifyEmail(string Email)
        {
            List<Zaposlenik> zaposlenici = ctx.Zaposlenik.ToList();
            foreach (Zaposlenik z in zaposlenici)
            {
                if (z.Email == Email)
                    return Json($"Korisnicko ime {Email} već postoji");
            }
            return Json(true);
        }



        public IActionResult PostojiLiUsername(string KorisnickoIme)
        {
            List<Korisnik> korisnici = ctx.Korisnik.ToList();
            foreach (Korisnik k in korisnici)
            {

                if (k.KorisnickoIme == KorisnickoIme)
                    return Json($"Korisnicko ime {KorisnickoIme} već postoji");


            }
            return Json(true);
        }


        public IActionResult VerifyUsername(string KorisnickoIme, int ZaposlenikId)
        {
            Zaposlenik z = ctx.Zaposlenik.Where(x => x.Id == ZaposlenikId).First();

            Korisnik ko = ctx.Korisnik.Where(x => x.Id == z.KorisnikId).First();
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
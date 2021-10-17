﻿using eNamjestaj.Data;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data.Models;
using eNamjestaj.Web.Controllers;
using eNamjestaj.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
//using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Primitives;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.DataProtection;
using System.Text;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using eNamjestaj.Web.Areas;
using eNamjestaj.Web.Areas.ModulMenadzer.ViewModels;
using eNamjestaj.Web.Areas.ModulMenadzer.Controllers;
using eNamjestaj.Web.Areas.ModulAdministrator.Controllers;
using eNamjestaj.Web.Areas.ModulAdministrator.ViewModels;
using GoogleAuthenticatorService.Core;
using Microsoft.AspNetCore.Routing;
//using Xunit;

namespace eNamjestaj.UnitTest
{

    [TestClass]
    public class IB120060_UnitTests
    {
        //    [TestClass]
        //    public class AutentifikacijaControllerTest
        //    {
        //        AutentifikacijaController ac = new AutentifikacijaController(_context);

        //        [TestMethod]
        //        public void IndexView_NotNull()
        //        {
        //            Assert.IsNotNull(ac.Index());
        //        }


        //        [TestMethod]
        //        public void LoginView_NotNull()
        //        {
        //            LoginVM obj = new LoginVM();
        //            // ViewResult vr = ac.Login(obj) as ViewResult;
        //            Assert.IsNotNull(ac.Login(obj));
        //        }
        //    }


        public MojContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<MojContext>().
                UseInMemoryDatabase(databaseName: "Test_Database").Options;
            //var option = new DbContextOptionsBuilder<MojContext>().
            //    UseSqlServer("Server=localhost,1433;Database=TestExample;User=sa;Password=password");//UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new MojContext(option);//option.Options);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }


        private MojContext _context;


        public IB120060_UnitTests()
        {
            _context = CreateContextForInMemory();

            var drzava = new Drzava { Naziv = "..." };
            var kanton = new Kanton { Naziv = "...", Drzava = drzava };
            var opstina = new Opstina { Naziv = "...", Kanton = kanton, PostanskiBroj = "..." };
            var uloga = new Uloga { TipUloge = "admin" };
            _context.AddRange(drzava, kanton, opstina, uloga);
            _context.SaveChanges();

            _context.Uloga.Add(new Uloga { TipUloge = "menadzer" });
            _context.Uloga.Add(new Uloga { TipUloge = "skladistar" });
            _context.Uloga.Add(new Uloga { TipUloge = "dostavljac" });
            _context.Uloga.Add(new Uloga { TipUloge = "kupac" });
            _context.SaveChanges();


            var korisnik = new Korisnik
            {
                KorisnickoIme = "johndoe",
                //Lozinka = "johndoe",
                LozinkaHash = "i8sswmRAmnZbpGPl4HAPa+2WVcgJIJZ5tsmb0oMDYIw=",
                LozinkaSalt = "pRKjLYUp97f9lVEt+hsrDg==",
                Opstina = opstina,
                UlogaId = 5,
                TwoFactorUniqueKey = null
            };

            var kupac = new Kupac
            {
                Ime = "kupac",
                Prezime = "...",
                Email = "...",
                Adresa = "...",
                Spol = "..",
                Korisnik = korisnik

            };
            _context.AddRange(korisnik,
                kupac
              );

            _context.SaveChanges();

            _context.Korisnik.Add(new Korisnik
            {
                KorisnickoIme = "zaposlenik",
                LozinkaHash = "BTdXljtPJDmsye5zy6BUw8+wrT01+F44X34mkJ2plUs=",
                LozinkaSalt = "yT/VqmV2Fr1QeKHV2mjJug==",
                Opstina = opstina,
                UlogaId = 2,
                TwoFactorUniqueKey = null
            });

            var zaposlenik = new Zaposlenik
            {
                Ime = "menadzer",
                Prezime = "menadzer",
                Email = "menadzerMail",
                Adresa = "...",
                Telefon = "-...",
                KorisnikId = 2
            };

            var dobavljac = new Dobavljac
            {
                Adresa = "...",
                BrojTelefona = "...",
                Email = "...",
                Naziv = "..."
            };

            var vrstaProizvoda = new VrstaProizvoda { Naziv = "Ormar" };

            var opisProizvoda = new OpisProizvoda
            {
                Opis = "neki"
            };

            var proizvod = new Proizvod
            {
                Cijena = 100,
                Naziv = "NazivPr",
                Sifra = "...",
                Slika = "...",
                Korisnik = korisnik,
                VrstaProizvoda = vrstaProizvoda,
                OpisProizvoda = opisProizvoda
            };

            var vrstaSkladista = new VrstaSkladista
            {
                Naziv="sklPr"
            };

            var skladiste = new Skladiste
            {
                Naziv = "SkladistePr",
                Adresa = "Adresa",
                Korisnik = korisnik,
                VrstaSkladista=vrstaSkladista

            };

            var proizvodSkladiste = new ProizvodSkladiste
            {
                Proizvod = proizvod,
                Skladiste = skladiste,
                Kolicina = 100
            };

            var boja = new Boja
            {
                Naziv = ".."
            };

            var proizvodBoja = new ProizvodBoja
            {
                Proizvod = proizvod,
                Boja = boja
            };

            var dostava = new Dostava
            {
                Tip = "...",
                Cijena = 10,
                Opis = "..."
            };

            var narudzba = new Narudzba
            {
                BrojNarudzbe = "1",
                Datum = DateTime.Now,
                Status = false,
                Aktivna = false,
                Otkazano = false,
                NaCekanju = false,
                DostavaId = "1",
                Kupac = kupac
            };

            var narudzbaStavka = new NarudzbaStavka
            {
                Kolicina = 3,
                ProizvodId = 1,
                Narudzba = narudzba,
                BojaId = 1,
                CijenaProizvoda = 1230,
                PopustNaCijenu = 10,
                TotalStavke = 1000
            };

            var izlaz = new Izlaz
            {
                BrojNarudzbe = "212121",
                Datum = DateTime.Now,
                Zakljucena = false,
                IznosBezPDV = 1000,
                IznosSaPDV = 1170,
                PovratNovca = false,
                //Skladiste = skladiste,
                Korisnik = korisnik,
                Narudzba = narudzba,
                Dostava = dostava
            };

            var izlazStavka = new IzlazStavka
            {
                Cijena = 1230,
                Popust = 10,
                Kolicina = 3,
                Konacnacijena = 1000,
                Proizvod = proizvod,
                Izlaz = izlaz,
                Skladiste = skladiste
            };

            var strJsonSer = JsonConvert.DeserializeObject("\"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\"");


            var autorizacijskiToken = new AutorizacijskiToken
            {
                Vrijednost = strJsonSer.ToString(),
                KorisnikId = 1,
                VrijemeEvidentiranja = DateTime.Now
            };

            var recenzija = new Recenzija
            {
                Proizvod = proizvod,
                Kupac = kupac,
                Ocjena = 3,
                Sadrzaj = "..",
                Datum = DateTime.Today
            };

            var akcijskiKatalog = new AkcijskiKatalog
            {
                Opis = "junski k.",
                DatumPocetka = Convert.ToDateTime("01/06/2020"),
                DatumZavrsetka = Convert.ToDateTime("01/07/2020"),
                Aktivan = false
            };

            var katalogStavka = new KatalogStavka
            {
                PopustProcent = 10,
                Proizvod = proizvod,
                AkcijskiKatalog = akcijskiKatalog
            };

            var log = new Log
            {
                Username = "korisnik",
                IPAddress = "ip adresa",
                AreaAccessed = "area",
                Timestamp = DateTime.Now
            };

            var normativ = new Normativ
            {
                BrojNormativa = "1",
                Datum = DateTime.Now,
                Proizvod = proizvod,
                Zakljucen=false 
            };

            var materijal = new Materijal
            {
                Naziv = "neki",
                Opis = "neki",
                Sifra = "sifra"
            };

            var normativStavka = new NormativStavka
            {
                Kolicina = 10,
                Normativ = normativ,
                Materijal = materijal
            };

            var nabavkaProizvod = new NabavkaProizvod
            {
                BrojNabavke = "NAB-PR-2021-29-06-1",
                KorisnikId = 2,
                Poslana = false,
                Datum = DateTime.Now.Date,
                Skladiste = skladiste,
                Total = 0,
                Dobavljac = dobavljac
            };

            var nabavkaProizvodStavka = new NabavkaProizvodStavka
            {
                Cijena = 100,
                Kolicina = 5,
                NabavkaProizvod = nabavkaProizvod,
                Proizvod = proizvod,
                TotalStavka = 500
            };

            var dobavljacProizvod = new DobavljacProizvod
            {
                Cijena=100,
                Dobavljac=dobavljac,
                Proizvod=proizvod
            };


            
            _context.AddRange(vrstaProizvoda, opisProizvoda, proizvod,vrstaSkladista, skladiste,
                proizvodSkladiste, boja, proizvodBoja, dostava, narudzba,
                narudzbaStavka, izlaz, izlazStavka, zaposlenik, dobavljac,
                autorizacijskiToken, recenzija, akcijskiKatalog, katalogStavka, log,
                normativ, materijal, normativStavka, nabavkaProizvod,
                nabavkaProizvodStavka, dobavljacProizvod);
            _context.SaveChanges();

            _context.Dobavljac.Add(new Dobavljac
            {
                Adresa = "...",
                BrojTelefona = "...",
                Email = "...",
                Naziv="..."
            });
            _context.SaveChanges();

            _context.VrstaSkladista.Add(new VrstaSkladista
            {
                Naziv="sklMat"
            });
            _context.SaveChanges();

            _context.Skladiste.Add(new Skladiste
            {
                Naziv = "skladisteMat",
                KorisnikId = 2,
                Adresa = "...",
                VrstaSkladistaId=2
            });
            _context.SaveChanges();

            var proizvodniNalog = new ProizvodniNalog
            {
                KorisnikId = 2,
                Proizvod = proizvod,
                BrojNaloga = "NALOG-2020-8-7-1",
                Datum = DateTime.Now,
                SkladisteMaterijalaId =2,
                SkladisteProizvodaId=1,
                Kolicina=5,
                TrosakPoProizvodu=10,
                UkupnaCijena=50,
                Zakljucen=false
            };


            var materijalSkladiste = new MaterijalSkladiste
            {
                Materijal=materijal,
                Kolicina=100,
                SkladisteId=2
            };

            var nabavkaMaterijal = new NabavkaMaterijal
            {
                BrojNabavke = "NAB-MAT-2021-29-06-1",
                KorisnikId = 2,
                Poslana = false,
                Datum = DateTime.Now.Date,
                SkladisteId = 2,
                Total = 0,
                DobavljacId = 2
            };

            var nabavkaMaterijalStavka = new NabavkaMaterijalStavka
            {
                Cijena=10,
                Kolicina=10,
                NabavkaMaterijal=nabavkaMaterijal,
                TotalStavka=100,
                Materijal=materijal
            };

            var dobavljacMaterijal = new DobavljacMaterijal
            {
                Materijal=materijal,
                DobavljacId=2,
                Cijena=10
            };
            
            _context.AddRange(materijalSkladiste, nabavkaMaterijal, 
                nabavkaMaterijalStavka, dobavljacMaterijal, proizvodniNalog);
            _context.SaveChanges();

           
            _context.AkcijskiKatalog.Add(new AkcijskiKatalog
            {
                Opis = "august k.",
                DatumPocetka = Convert.ToDateTime("01/08/2020"),
                DatumZavrsetka = Convert.ToDateTime("01/09/2020"),
                Aktivan = true
            });

            _context.KatalogStavka.Add(new KatalogStavka
            {
                AkcijskiKatalogId = 2,
                ProizvodId = 1,
                PopustProcent = 10
            });

            //_context.Uloga.Add(new Uloga { TipUloge="admin" });
            //_context.Uloga.Add(new Uloga { TipUloge="menadzer"});
            //_context.SaveChanges();
            _context.Korisnik.Add(new Korisnik
            {
                KorisnickoIme = "admin",
                LozinkaHash = "0Eh8tKfwu7cE3HjVAGRF3Ae6QEh8W0Br8Q2Tg5V3yzI=",
                LozinkaSalt = "2LG4pfrmPPzNLeRYiUu/mw==",
                Opstina = opstina,
                UlogaId = 1,
                TwoFactorUniqueKey = null
            });

            _context.SaveChanges();

            _context.Zaposlenik.Add(new Zaposlenik
            {
                Ime = "admin",
                Prezime = "admin",
                Email = "...",
                Adresa = "...",
                Telefon = "-...",
                KorisnikId = 3
            });
            _context.SaveChanges();

            _context.VrstaProizvoda.Add(
                new VrstaProizvoda
                {
                    Naziv = "Komoda"
                }
                );
            _context.SaveChanges();

            _context.Proizvod.Add(
                new Proizvod
                {
                    Cijena = 300,
                    Naziv = "Pr2",
                    KorisnikId = 2,
                    Sifra = "456888",
                    Slika = "...",
                    VrstaProizvodaId = 2
                }
                );

            _context.ProizvodBoja.Add(
               new ProizvodBoja
               {
                   ProizvodId = 2,
                   BojaId = 1
               });
            _context.SaveChanges();
        }

        [TestMethod]
        public void TestiranjeDbContexta_ProvjeraBrojauloga()
        {
            List<Uloga> ocekivana = _context.Uloga.ToList();
            List<Korisnik> ocekivaniK = _context.Korisnik.ToList();
            // Assert.AreEqual("kupac", ocekivana[0].TipUloge);
            //Assert.AreEqual("menadzer", ocekivana[1].TipUloge);
            //Assert.AreEqual("admin", ocekivana[2].TipUloge);
            Assert.AreEqual(2, ocekivaniK[1].Id);
            //Assert.AreEqual(1,_context.Zaposlenik.ToList().Count);
            //Assert.AreEqual("menadzer", _context.Zaposlenik.First().Ime);
            //Assert.AreEqual(3, ocekivaniK.Count);

        }

        //        ProizvodiController pc = new ProizvodiController();
        // NarudzbaStavkeController nsc = new NarudzbaStavkeController();

        //[TestMethod]
        //public void Test_ListaSvihProizvoda_SlanjeNullVrijednostiUIndexView()
        //{
        //    List<Proizvod> ocekivani = _context.Proizvod.ToList();
        //    var mockUserSession = new Mock<IUserSession>();
        //    mockUserSession.Setup(x => x.User).Returns(_user);

        //    ProizvodiController kontroler = new ProizvodiController(mockUserSession.Object);
        //    var vr = kontroler.Index(null,null) as ViewResult;
        //    ProizvodiIndexVM rezultat = vr.Model as ProizvodiIndexVM;

        //    Assert.AreEqual(ocekivani.Count, rezultat.Proizvodi.Count);
        //}



        //[DataRow(null,null)]
        //[DataRow(1,null)]
        //[DataRow(2,null)]
        //[DataRow(5,null)]
        //[DataRow(null,2)]

        const string expectedTestString = "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";


        public static Dictionary<string, StringValues> cookieResponseHeaders
        {
            get
            {
                var respHeaders = new Dictionary<string, StringValues>();
                var cookieValue = JsonConvert.SerializeObject("logirani_korisnik = 6K68sp5NupOcKWTwyaXvkqJ7s5JHZQiWfOI8mzehtq3eXQd3hv8mVjln51tak1iqBCHKQCo8IzQCilvjcfLXInzq7gpoYQ9mN6KffSgVd6IIqDVFaoL1Asl6n0MeCWXxapdLHDDapVzcA6LQ9LwA3L59vHj0vyJB1FEIpkenUtMPCQYXXw2TYq2VpZAGltHuOHz990aNPOEX3Hvr7Xk9onVAb1qgSdUsTvFe5UxCxe7RkrsskM5nx451glen3NPUM2M445pMLi3kA5rfDhk6brkDnoSdsjbyuJalxPMnfluVKFnoO36DwbwKPSGnDgxK3qk6spifXbkbXhkQzZQGpKTIcW1cRNLUs0QWuRPliNLAJiqYoPbQQOOYqgthhAnW8HxTf850iLtxpEtGtNy9t3SkHzmZsGVQdw4kv5HYXaf9svNnhM3COFiPNL3WvbVPuf3qrkQ2pgEqNd4DF11QcHpcbKUMJjM8VE82O3313joAQvrVWZ0JZfO7SKck10bj77sILYkjhoF00l5W4soRmxwVQ3yMtZ1PbzJrOOT3u7rXGkKO6YAn4dZ2u54mw4lftiB47GKi6nfelilXCpeH6AlIOYWHndaeE1medyfARIRWSF0bbwBgz5Yai7DbGHGwY0NeDMUyOHTKd8GDQbRTOgzRVKe3q6pDJ3YRNys8hSL6LXD7FfvEDidk9uJNUhthuCOaCCiQSjTjxlV3G59WKye9lTWAnX1iWM8fVLdH86m4DUhri3PZH1wsp8hBtP1rLD0pqQddpnUQ4XCnzyCzKOdCXATettbbTEWDg7yd3LrVWLokr40cwgoTOGzir5lt1OJbrFBosk5h4fZP55Bllgcc6RKc1NTn6Hx7fXwN0OkMU0l4EWa95ZAOlujzCQ86q0sklIJy5J145pJxb5e3CJWiikhDADYHwaCPTwmIVF4AVZEv0B2y7TyeLHL8aS8Pbqp7NUg7y2TC1oWutlGF0L9ShuMWeZ8TTlU4sCA56CcyG5ZVpXYC8XmlkWPPI2fPUDJfFEK5HM4czc4TCyW0Paqq3QuhA6LdWC1ydiY1MfgcG16khBmcZE5f7KyaEOpuaHtjk8KzRatlX3nAvKHoZyBYZGBMZyoQ4eYoLydPIf8gxKuNJt30w0UeBxv095vybPqMHSmtmkh15xm1k6NWiYRnNmfCoOwdP9kE98GYzJBhiYkKN9sm38VRXekIzAM3ZusNqqGrSLlthKO3a5IG9pC99NuPvj685eCIKOTIQNWoKCjF8wfG3vpQL4MwZwMl0eshi4plgCDZW4UEzAH32yp5g6oku9L3aV9077oqKFzL4NlnlPnhrfcFb8PmosFdiOOOTKDM2ytlKgqRqnu0s5HiWT4mEhjcxHVd1Ir5VbBDTLzrb8b3G6cbH1aE0zRRFKRZge6Llur5d6RE3htQpwBjhCEpGXkRA9unaPpqLBsPeTD9i7PoBfZJAVPVQYn4HWkAiCQJPF46cNwePxTqZp0eQDE0BxGXo86AFWsNCJvFoe26W72x25jHY7J2JP7mt6VrQBMVVW0EeUmKj7pvamB8OMtf2PKgvuty9t3MJPz3EkiYP7QzMBqsBA71qKHfRjCExjkSLvxQ07pebzwzb09cDEQUzHcMOygp0bQaiu4RjdhsdD2KmgbIDwubL1lj4qtPylki9XifPoziJflN3OTH4k5l85RsxxcBMsLOUFeZ5BFOhcYWiGQkzeeXh6hEfR7M1nbIQn0JN9dH7ETJb38Xs27DlDmxZPAWh4dyC29xKCOofrhz6Jy3bXHQmOPRlfUgZEQSVwKi8ZKjenrx0AeQqyAuwwRlUv0Yc3T6NBTWOI1epP71JKCsvbQytFFtOmqNCMjDqMVxQj7Pof47RY7oQvDKQQGHsx6kID8f038NgXnHuCUgRmnG0IOrHy8AY753INv1T65D0bB0nqtISvum0HMgwyhlamInZt9iEsyob20FmWhQIJZWaKVk5ebD9rek1toCJvLQX2v3mV3NSXtL1q07mgWAg8bQFEkit8JWRax1ncVjM1u6nZM7cmqh8ZFkTAdlvrHf4QCvcKrVAPNAKW6QIKvvu22K9LhdMET4d56wI1AISivAEpP9Ye71TK92IQ7zKOLsEl4hp6SHLMWwmfgB3a9riri5gTsJT3ttOhhSIL2REORGQa3Ux4PqxJyf6QjdRlqiGfgU6YJf7M2i1C0RKyEFGGWSXg5byFAzzqAoCMEtdYBt04SmEs6Yd4TToJ0mN1FCelDTeJ5Lssm7gpTBjTPKAhqueB4pHFIkeSXA77yVhlAMFT6t9OZ3aham0GJDnL4Jjz5MLZHiVwPcbbrEXv27Ce8a05rGstKPkZ73xiCQBUr2dsfJySYrIhgYNqIeGL8tfzFa8Uzo1NMj0uBAkitMPwzgY32VFXqR2SOzPtISuTNyxDiCqVgNL6TvrwUCCscUzsp6bF1qEyKw4tgyDwSeJtZofDRr3GhQGhM5JYxbngM8OmOJp6QXcBo7drl6D4TYlBfFwD2YR4QOUFY8qkaJZ28uw2uvZnoACPI0ZVqK8nGVkqySuhaF0pUakfWuLa0vbEqBVn27x0W8Zyx25fptF3jeZJCgA6hTrVatkTkc4XHEV8yP6yLWLIjV2rsjJ7fYlTjPhC3GUVQ3gGnDGkRWtjIzmGMEHIdKTMWk0kREzmTbij6CX83O1HELX8Ypec358MHx7JX6jL0RkFRdYNnxDuRhCgwVN7dMMWnUFQjU87lTSlCAn8IfPWu6eULUp6HtGTyYwDxP6ZaGKiYBH5YIu2bdpA1N04cPBelhKG7eT2KgORnNyYxlqVjYVCQx7ykSKWTUE8ybwZsDVKk4ECEPfDd6hefChnptj4IHjFxCLgSTF7xqOUi6TRbcemUgs01EWuJgqhmeaZLHmDCL0dPcU0eumEKEyo16GTZOkgznEoIgts6nK7Fp8uAxbtG3SFA6MmBB2PoyMqUs77IAZlCnZehdktX2Lqrp8VYZOSOwvOd8Nfb0deOkFVjVUzLw97GKx8hZdEhsNUfEkEEcL3UyPYD8yQXKdKjCs4ndDNtskKRMduDKMn3aNDorRyvNpZUtQOfpt0ROkdYfcRFCtBgejh8jgJei2bumjimtmTfydnlGzlxWkZguvfmBr4mgCzK6YuqUgsWVgWJ8W30TmiRV7CTpIPjEQpD7M7KmNKtwkwDPAPLzXILQC8AWa5Ct596RXlt12hLGL88FppFbl1E1E0BJ4N0CqJ8L1mwzFb8zreJd7YfMO3L9mC7uoGB9uXAlO1m2UYfxcyJf9zTymAKRf3mXivdu2jj9na0tL3VMD03rvjDmDDjgxUpCrCvmbC1R38vsLWbrGzoh6oAt1mUhP02d3EcGF24kKJef4w6Yo2oYOoiu7yP1J6H4Qw8BCpueHbIp2gHbDurnO6xhT3wbG2rZO5igdYjrBgEZwEkK2JsHFh3AN39ZQu647VklalZ142G3HGpfVwpafAfnebWgjesbhwT7n2jGYdCcvkaeKbhOLhpAAvVYcTgx3ZEKgAkHEgj4ZQTAOBp5sD8rmsBevCL7CoiEA565jcILYbjcB69VvdGxTCGAvfoUtqZJFopvnWwdlS42h5XF9nYvHvffrnFhYvJQLs130Z7U84JrwSKxsmBsLuIMT9soJeMHpMNcczlORSYiYtRkmu8ntgP5PAwUDQqmdBwZKIssAgjKPgmBQVyTPqU962cyduvwehnoXhuEhKZrSpI36cJWvh3wkWthK8h7YsvoZjiQNP6nxhZ5Wse8xQ5nzJekQF8lz3qNdYkgd5ZuIviqDQeCz7WOsb0wRoiX4Ta0ePB3XC6atxs9dTW2TYJYDL4T7kMb3JvxpzxlCdE8ihN0S7ybgw1ZsVhpyDKqKFZeytMIIBHIllKsIxotRmNiccjGcnCFL4jcwQoxeTg5ha9wtb1iZe8R9WKZDa7nzqRfkR5uFQrNocym2DtXbiyeafs6NfM1M56EUgGDB5dKD4yVbwQbhYWs1yT36FaS3xVD16egInievyM2kWXjsgQRC3aWUvq3cq6wnI8hffXSGrRAGJ46JPUm0gBlWgXGoQWvQiKkz75CU5lvY643qVP68KQetff8E683geD523g6i3Qxa3V9dJRRP0uuCcC57W2AN7oWHf4OdDuNHNXQEd81n5QsRolGfjFP2GqJnprfHm9eX4pETsM0Rmdlwf0SFFThzgNn74WsJBB6HpNXlkfwJGM2sJM1xpzFJxHMLn0iQyDlXngRad3ttjqxkgwHHHArTRT0SCzdHYEcauiVuIZJVAHmOgy3WGilzRhLBQUdBYAPO3eO07whkuQhuN0rKQIsAgKAuBLwrMzYz38nejxJdA5mBnAqf0eoxBOVFnyGcCtQXzgM1GJT5hrx0yPzaq4ES1I3T0jTj5xtF2PJiZ2ZMO4iHhvvDQyIwy2ilLJdVKv02Nnr1H4IDB0xSLCvfDLVztw43C1SteP9KPiGSJiPjBkjsggTyBa44jARVZOMISZdda0he2TYFPYZkEuHxwjWpzfXLFil0pCnp8T6DgkEkPtgNeWRWFqhN3Y8f5gkomifSOtgeLOcKVaaPrD4e4pw1CvHRbxMrN0KneBpzzznkrAfyTXyuDAqAelfAm1qtmAihWk3EaqeGlgfj9ZfhI9IKr6V6IBUn1qt3OhX837Ta9mLrMtYfgmAw93UJv9hsyRRO50LD2VlwEMwgesv9uAjQUMI4KD008MKEqSbDrPh0iVf4bkaZwrSOZaFQBkTBazgHhd5RqG2l63dk9dMk8CWj7ipd3Z42UQd1dv5kv7HF44d4T326UX7MwXBIoUeIUwA76cAKsELdjkNBAy0NPoy0iym1bo4lWjzb3URTHA3MLkbOiAFi68Q4Tv124dl7LeRC4e6WsvOy89bL3txsrQ7Y4JAZ6xsRJdCSxAwakvF7xWAjGnKBrx2aZAmEgeyvyAEECzdITLArm3OvU9WKKlMd74244iOZaAQcSLh7ct1vd27XNms; expires = Sat, 02 Sep 2020 23:19:18 GMT; path =/ ");
                byte[] dummy = System.Text.Encoding.UTF8.GetBytes(cookieValue);
                string jsonString = Encoding.UTF32.GetString(dummy);


                //var strJsonDer =JsonConvert.DeserializeObject("logirani_korisnik = 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; expires = Sat, 02 Sep 2020 23:19:18 GMT; path =/ ");
                respHeaders.Add("logirani_korisnik", jsonString);
                return respHeaders;
            }
        }

        public static Dictionary<string, string> cookieRequestHeaderList
        {
            get
            {
                var cookieHeaders = new Dictionary<string, string>();
                var strJsonSer = JsonConvert.SerializeObject("6K68sp5NupOcKWTwyaXvkqJ7s5JHZQiWfOI8mzehtq3eXQd3hv8mVjln51tak1iqBCHKQCo8IzQCilvjcfLXInzq7gpoYQ9mN6KffSgVd6IIqDVFaoL1Asl6n0MeCWXxapdLHDDapVzcA6LQ9LwA3L59vHj0vyJB1FEIpkenUtMPCQYXXw2TYq2VpZAGltHuOHz990aNPOEX3Hvr7Xk9onVAb1qgSdUsTvFe5UxCxe7RkrsskM5nx451glen3NPUM2M445pMLi3kA5rfDhk6brkDnoSdsjbyuJalxPMnfluVKFnoO36DwbwKPSGnDgxK3qk6spifXbkbXhkQzZQGpKTIcW1cRNLUs0QWuRPliNLAJiqYoPbQQOOYqgthhAnW8HxTf850iLtxpEtGtNy9t3SkHzmZsGVQdw4kv5HYXaf9svNnhM3COFiPNL3WvbVPuf3qrkQ2pgEqNd4DF11QcHpcbKUMJjM8VE82O3313joAQvrVWZ0JZfO7SKck10bj77sILYkjhoF00l5W4soRmxwVQ3yMtZ1PbzJrOOT3u7rXGkKO6YAn4dZ2u54mw4lftiB47GKi6nfelilXCpeH6AlIOYWHndaeE1medyfARIRWSF0bbwBgz5Yai7DbGHGwY0NeDMUyOHTKd8GDQbRTOgzRVKe3q6pDJ3YRNys8hSL6LXD7FfvEDidk9uJNUhthuCOaCCiQSjTjxlV3G59WKye9lTWAnX1iWM8fVLdH86m4DUhri3PZH1wsp8hBtP1rLD0pqQddpnUQ4XCnzyCzKOdCXATettbbTEWDg7yd3LrVWLokr40cwgoTOGzir5lt1OJbrFBosk5h4fZP55Bllgcc6RKc1NTn6Hx7fXwN0OkMU0l4EWa95ZAOlujzCQ86q0sklIJy5J145pJxb5e3CJWiikhDADYHwaCPTwmIVF4AVZEv0B2y7TyeLHL8aS8Pbqp7NUg7y2TC1oWutlGF0L9ShuMWeZ8TTlU4sCA56CcyG5ZVpXYC8XmlkWPPI2fPUDJfFEK5HM4czc4TCyW0Paqq3QuhA6LdWC1ydiY1MfgcG16khBmcZE5f7KyaEOpuaHtjk8KzRatlX3nAvKHoZyBYZGBMZyoQ4eYoLydPIf8gxKuNJt30w0UeBxv095vybPqMHSmtmkh15xm1k6NWiYRnNmfCoOwdP9kE98GYzJBhiYkKN9sm38VRXekIzAM3ZusNqqGrSLlthKO3a5IG9pC99NuPvj685eCIKOTIQNWoKCjF8wfG3vpQL4MwZwMl0eshi4plgCDZW4UEzAH32yp5g6oku9L3aV9077oqKFzL4NlnlPnhrfcFb8PmosFdiOOOTKDM2ytlKgqRqnu0s5HiWT4mEhjcxHVd1Ir5VbBDTLzrb8b3G6cbH1aE0zRRFKRZge6Llur5d6RE3htQpwBjhCEpGXkRA9unaPpqLBsPeTD9i7PoBfZJAVPVQYn4HWkAiCQJPF46cNwePxTqZp0eQDE0BxGXo86AFWsNCJvFoe26W72x25jHY7J2JP7mt6VrQBMVVW0EeUmKj7pvamB8OMtf2PKgvuty9t3MJPz3EkiYP7QzMBqsBA71qKHfRjCExjkSLvxQ07pebzwzb09cDEQUzHcMOygp0bQaiu4RjdhsdD2KmgbIDwubL1lj4qtPylki9XifPoziJflN3OTH4k5l85RsxxcBMsLOUFeZ5BFOhcYWiGQkzeeXh6hEfR7M1nbIQn0JN9dH7ETJb38Xs27DlDmxZPAWh4dyC29xKCOofrhz6Jy3bXHQmOPRlfUgZEQSVwKi8ZKjenrx0AeQqyAuwwRlUv0Yc3T6NBTWOI1epP71JKCsvbQytFFtOmqNCMjDqMVxQj7Pof47RY7oQvDKQQGHsx6kID8f038NgXnHuCUgRmnG0IOrHy8AY753INv1T65D0bB0nqtISvum0HMgwyhlamInZt9iEsyob20FmWhQIJZWaKVk5ebD9rek1toCJvLQX2v3mV3NSXtL1q07mgWAg8bQFEkit8JWRax1ncVjM1u6nZM7cmqh8ZFkTAdlvrHf4QCvcKrVAPNAKW6QIKvvu22K9LhdMET4d56wI1AISivAEpP9Ye71TK92IQ7zKOLsEl4hp6SHLMWwmfgB3a9riri5gTsJT3ttOhhSIL2REORGQa3Ux4PqxJyf6QjdRlqiGfgU6YJf7M2i1C0RKyEFGGWSXg5byFAzzqAoCMEtdYBt04SmEs6Yd4TToJ0mN1FCelDTeJ5Lssm7gpTBjTPKAhqueB4pHFIkeSXA77yVhlAMFT6t9OZ3aham0GJDnL4Jjz5MLZHiVwPcbbrEXv27Ce8a05rGstKPkZ73xiCQBUr2dsfJySYrIhgYNqIeGL8tfzFa8Uzo1NMj0uBAkitMPwzgY32VFXqR2SOzPtISuTNyxDiCqVgNL6TvrwUCCscUzsp6bF1qEyKw4tgyDwSeJtZofDRr3GhQGhM5JYxbngM8OmOJp6QXcBo7drl6D4TYlBfFwD2YR4QOUFY8qkaJZ28uw2uvZnoACPI0ZVqK8nGVkqySuhaF0pUakfWuLa0vbEqBVn27x0W8Zyx25fptF3jeZJCgA6hTrVatkTkc4XHEV8yP6yLWLIjV2rsjJ7fYlTjPhC3GUVQ3gGnDGkRWtjIzmGMEHIdKTMWk0kREzmTbij6CX83O1HELX8Ypec358MHx7JX6jL0RkFRdYNnxDuRhCgwVN7dMMWnUFQjU87lTSlCAn8IfPWu6eULUp6HtGTyYwDxP6ZaGKiYBH5YIu2bdpA1N04cPBelhKG7eT2KgORnNyYxlqVjYVCQx7ykSKWTUE8ybwZsDVKk4ECEPfDd6hefChnptj4IHjFxCLgSTF7xqOUi6TRbcemUgs01EWuJgqhmeaZLHmDCL0dPcU0eumEKEyo16GTZOkgznEoIgts6nK7Fp8uAxbtG3SFA6MmBB2PoyMqUs77IAZlCnZehdktX2Lqrp8VYZOSOwvOd8Nfb0deOkFVjVUzLw97GKx8hZdEhsNUfEkEEcL3UyPYD8yQXKdKjCs4ndDNtskKRMduDKMn3aNDorRyvNpZUtQOfpt0ROkdYfcRFCtBgejh8jgJei2bumjimtmTfydnlGzlxWkZguvfmBr4mgCzK6YuqUgsWVgWJ8W30TmiRV7CTpIPjEQpD7M7KmNKtwkwDPAPLzXILQC8AWa5Ct596RXlt12hLGL88FppFbl1E1E0BJ4N0CqJ8L1mwzFb8zreJd7YfMO3L9mC7uoGB9uXAlO1m2UYfxcyJf9zTymAKRf3mXivdu2jj9na0tL3VMD03rvjDmDDjgxUpCrCvmbC1R38vsLWbrGzoh6oAt1mUhP02d3EcGF24kKJef4w6Yo2oYOoiu7yP1J6H4Qw8BCpueHbIp2gHbDurnO6xhT3wbG2rZO5igdYjrBgEZwEkK2JsHFh3AN39ZQu647VklalZ142G3HGpfVwpafAfnebWgjesbhwT7n2jGYdCcvkaeKbhOLhpAAvVYcTgx3ZEKgAkHEgj4ZQTAOBp5sD8rmsBevCL7CoiEA565jcILYbjcB69VvdGxTCGAvfoUtqZJFopvnWwdlS42h5XF9nYvHvffrnFhYvJQLs130Z7U84JrwSKxsmBsLuIMT9soJeMHpMNcczlORSYiYtRkmu8ntgP5PAwUDQqmdBwZKIssAgjKPgmBQVyTPqU962cyduvwehnoXhuEhKZrSpI36cJWvh3wkWthK8h7YsvoZjiQNP6nxhZ5Wse8xQ5nzJekQF8lz3qNdYkgd5ZuIviqDQeCz7WOsb0wRoiX4Ta0ePB3XC6atxs9dTW2TYJYDL4T7kMb3JvxpzxlCdE8ihN0S7ybgw1ZsVhpyDKqKFZeytMIIBHIllKsIxotRmNiccjGcnCFL4jcwQoxeTg5ha9wtb1iZe8R9WKZDa7nzqRfkR5uFQrNocym2DtXbiyeafs6NfM1M56EUgGDB5dKD4yVbwQbhYWs1yT36FaS3xVD16egInievyM2kWXjsgQRC3aWUvq3cq6wnI8hffXSGrRAGJ46JPUm0gBlWgXGoQWvQiKkz75CU5lvY643qVP68KQetff8E683geD523g6i3Qxa3V9dJRRP0uuCcC57W2AN7oWHf4OdDuNHNXQEd81n5QsRolGfjFP2GqJnprfHm9eX4pETsM0Rmdlwf0SFFThzgNn74WsJBB6HpNXlkfwJGM2sJM1xpzFJxHMLn0iQyDlXngRad3ttjqxkgwHHHArTRT0SCzdHYEcauiVuIZJVAHmOgy3WGilzRhLBQUdBYAPO3eO07whkuQhuN0rKQIsAgKAuBLwrMzYz38nejxJdA5mBnAqf0eoxBOVFnyGcCtQXzgM1GJT5hrx0yPzaq4ES1I3T0jTj5xtF2PJiZ2ZMO4iHhvvDQyIwy2ilLJdVKv02Nnr1H4IDB0xSLCvfDLVztw43C1SteP9KPiGSJiPjBkjsggTyBa44jARVZOMISZdda0he2TYFPYZkEuHxwjWpzfXLFil0pCnp8T6DgkEkPtgNeWRWFqhN3Y8f5gkomifSOtgeLOcKVaaPrD4e4pw1CvHRbxMrN0KneBpzzznkrAfyTXyuDAqAelfAm1qtmAihWk3EaqeGlgfj9ZfhI9IKr6V6IBUn1qt3OhX837Ta9mLrMtYfgmAw93UJv9hsyRRO50LD2VlwEMwgesv9uAjQUMI4KD008MKEqSbDrPh0iVf4bkaZwrSOZaFQBkTBazgHhd5RqG2l63dk9dMk8CWj7ipd3Z42UQd1dv5kv7HF44d4T326UX7MwXBIoUeIUwA76cAKsELdjkNBAy0NPoy0iym1bo4lWjzb3URTHA3MLkbOiAFi68Q4Tv124dl7LeRC4e6WsvOy89bL3txsrQ7Y4JAZ6xsRJdCSxAwakvF7xWAjGnKBrx2aZAmEgeyvyAEECzdITLArm3OvU9WKKlMd74244iOZaAQcSLh7ct1vd27XNms");
                cookieHeaders.Add("logirani_korisnik", strJsonSer.ToString());
                return cookieHeaders;
            }
        }
        Random random = new Random();
        private IHostingEnvironment hostingEnvironment;
        private Dictionary<object, object> httpContextItems = new Dictionary<object, object>();

        public IUrlHelper GetUrlHelper()
        {
            var urlHelperMock = new Mock<IUrlHelper>();
            urlHelperMock.Setup(m => m.Action(It.IsAny<UrlActionContext>()))
                .Returns<UrlActionContext>(u => u.Controller + "/" + u.Action);

            return urlHelperMock.Object;

        }

        public ITempDataDictionary GetTempDataForRedirect()
        {
            var tempData = new Mock<ITempDataDictionary>(MockBehavior.Strict);
            tempData
                .Setup(m => m.Keep())
                .Verifiable();

            var tempDataFactory = new Mock<ITempDataDictionaryFactory>(MockBehavior.Strict);
            tempDataFactory
                .Setup(f => f.GetTempData(It.IsAny<HttpContext>()))
                .Returns(tempData.Object);

            return tempData.Object;
        }


        // ProizvodiController pc = new ProizvodiController(_context);
        private HttpContext GetMockedHttpContext(Korisnik kor = null)
        {

            IConfiguration configuration = new ConfigurationBuilder()
      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
      .AddEnvironmentVariables()
      .Build();

            //services
            var services = new ServiceCollection();
            //services.AddLogging();

            services.AddMvc().AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.ContractResolver =
                        new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
            services.AddOptions();
            //services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSession();
            services.AddDbContext<MojContext>(options =>
              options.UseInMemoryDatabase(databaseName: "Test_Database"));


            var serviceProvider = services.BuildServiceProvider();

            var serviceProviderGetContext = new Mock<IServiceProvider>();
            serviceProviderGetContext.Setup(s => s.GetService(typeof(MojContext)))
            .Returns(_context);


            //httpContext i session
            var mockContext = new Mock<HttpContext>();
            var mockSession = new Mock<ISession>();
            Korisnik sessionUser = kor;//_context.Korisnik.First();// new Korisnik() { KorisnickoIme = "MyValue" };
            var sessionValue = JsonConvert.SerializeObject(sessionUser);
            byte[] dummy = System.Text.Encoding.UTF8.GetBytes(sessionValue);

            if (kor != null)
            {
                _context.AutorizacijskiToken.First().KorisnikId = kor.Id;
                _context.SaveChanges();
            }
            // mockContext.Setup(s => s.Session).Returns(mockSession.Object);
            mockContext.SetupGet(ctx => ctx.RequestServices).Returns(serviceProviderGetContext.Object);
            mockContext.SetupGet(c => c.Items).Returns(httpContextItems);

            var collection = Mock.Of<IFormCollection>();
            var mockDataProtector = new Mock<IDataProtector>();
            Mock<IDataProtectionProvider> mockDataProtectionProvider = new Mock<IDataProtectionProvider>();



            var request = new Mock<HttpRequest>();
            //           request.Setup(f => f.ReadFormAsync(CancellationToken.None)).Returns
            // ---->                            (Task.FromResult(collection));
            request.SetupGet(r => r.Cookies).Returns(new RequestCookieCollection(cookieRequestHeaderList));

            mockContext.SetupGet(c => c.Request).Returns(request.Object);

            var response = new Mock<HttpResponse>();
            response.SetupProperty(it => it.StatusCode);

            response.SetupGet(resp => resp.Cookies).Returns(new ResponseCookies(new HeaderDictionary(cookieResponseHeaders), null));
            response.SetupGet(resp => resp.Headers).Returns(new HeaderDictionary(cookieResponseHeaders));


            mockContext.Setup(c => c.Response).Returns(response.Object);

            mockDataProtector.Setup(sut => sut.Protect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes("CfDJ8GnPj9ak8t1HphXa8mMbIoKnqw4YPtXOXoKasvmnPEhKDWkKreGRYzObYb6nsYj6zcIIiyuqWMic_lfwLkYv-Y-II7heGvYx0ffMSSIVD7JKrsX9ML74Ju2vmFPnhTtifbnFQBrUbluhJ2Pn34v3anAXHdYRTh2YlyJhJ3oJDUru_6xO_7EM9UJdwxU9VJOf0NpChZypR9Aa64JQX4CLx8i4Sy04gzxsKKvSq0TACNlY1RuW8fodu23osFIsIdQ96G2vIYwOyueFUXA2tcLCurbtm2kQGgqviZZoBQNdfiwTjxw6dvW5f9MmJHz_XpbQCYiEU8kG15DkyWglvq006C6A9xcCGvi6Fi0_Ow1gVhwSdvHun7M9vpNF9BWojdpdOwTD2y9nSjg3adU1IRml-zZxPJ0LVICVQ0yZ1ZnbqWfMxSVueoeEGVYoIu4h_EqT-Y6YqmSx0-Z5yOjK5AJauARFoU-5ho6yCSUIg_sdbhkRecFM0oChqfCFvjPl_T2irTUk2EO94FrC7TGZ-vM7VPs2F4_J7Td2IyaZBvwyGFL6A_Xp8MGoOoAgWUgBL4t-o8JscOLgVrGyBffQtM92sg6bsqEnrxerO4sE1QTxDF_TpCD5sLKMtaF3NItukOfVt9DPaTV9THgue6LVJFasotqv6b9UOd_o2Tpa_ZB0LHxhdZNRHYRqF0HcyCohphsRIJ5hCP5Os7DIT8isyYks_ZXKEmFd7TKTREVouO3T1EPx0bDV_qFGBZrQu6V_uybf7gNk9Crnge2Ekj6ElXgPIviauc7edKVnPsTRzwDsOYN1NWgk-UGkKFjISCrE_UkaMn8F6-y2umgVJTebmap-MczZq6eilD9r_7aDSJyZBIZPY0QdGSJlLx3CYySTJ0fsoz3t5sUlt1cuAeWng6oiE_ij0wbUfriP8YE1mF8RB8hSQtVXC3KH8_ukP2ofEuehzvm_NTRx5yKls4nkfnzaUpfU3VYvVUIuLWnQY5xeCnN2xn1Qgklbfv_Xx32ZEKAGmm6HxKkqlrz8y-WFUdrYcI4ng2EJvvt0B2IUopCL_DPEAh4sXmEy0pM_YOtOV_mCH4eMupKAD0tqBuTFrYeb85vsNqe4SOKkYTID83KtVxZ0fCo6Z4Gd6kLHQ4TQRokVnkHa1c9VHrzZKI6oy23uGwAyVGlFxTK4lM6Xg2HBjo_AYrxg5H6Yb3Kb1M188hImXvW8q6H-C7LMwM966FGTv1kOYYCPFxL-4876UziUcAw7hQGAoxCRZQVOmd7-K8DtQSeI4ctRzaghduMlYAbqG5s5ZerhUF-1Jbo3d4RTOxXdeH9l8D7St2WfHn1aObitZ8tPxY90V4y5YmOQbC267W9QaQUT0pcw7es6SZDbrNmxp6ktzxn34qcAkINmBnMTJKohl7tXCs3mJsXc7mpEeeFjy4NXa8f3pKKQ_hv4Qkfl-gOgfnFTQe6tD9VAQMdUQbjh_R4NoKaRGnRQTHSWBn4dHFQSWwSyshHbvyq8rXB4eRbB1yb5WD4BdpWVNa2d2k2NU1jZy_FI4SZoKsO-H5gPl3j6xnvyk20swbBE2RdLG_SGEWUNMYUdJEOxgH7FC3amwh3-MGhxwJ6m0maGukIL_uAjbH7N_Yt7pf1c5WNWbfQEGkhw3KBIf_vrbr4USZt_0zGWvFM64IXvJl8D5JNvsuVlOrrihfv0TMjhcmFinYM40FSVg3R9qkGHK-kftfYCxK_hoOrxkETEcNZfcE9sgr5F2abXqDM_nhExF35brEt3jrNRJb5DTFV9DV7VidQfec8qjF-c6UTosoa6hgkK2LCeriZ7x3olFjkeUSW501bYDDEJjcphMA5nr1HKsuPt1C9OR3O5UhPwR_quYKQRnbqvPbfljKlBIy0rzVUVVEoZz58vpoDC96di-L-TRLUVPFlukY5k43P5mFLRkWiMZ3GFz88qdOKM_AtPdc-Vi4r77h-fdzvtW5sBiBQ54ViAqHW592XRVjQZHx6_UFyT9rqVgVgjSn_PAJ9Nqv-1S4V30DT4QmgYhLb_UW8oyB7q4dAXPiQWz26LRkPRR-93fl-XiIYTm0TMTv3yT8p51Sl4LaPmJwlPSszPgziEnZET1ypX3xMaJ8oIBEakk5uAnvdToHintIN6a3z6L7Aon0DlEvfrUOvf7cTXtDrfrJx-6NX7Bkj5W2R24_QFTR-rst6gXNQJzBCU9H5ml9m8WVapWX25g4oADScfg72FiTAHBLn2T1lC16YncicOLsyK2jxvXtJ716ECq6b3Lv6lvuHkB_vWQYSpRCsnJnmDjWebUao11WhpwaqgDiDyGAgQpsSWKdMch8hpSK9911LWIc29lXozwb73igIvekGKIZRER9ZdxFiEnF5SggQyChvWsLW-SSSyaKd5nvcLO4PCJTjDAlkym7FIZWpHtqGvr_wGLPq_oFQ6nsy1AWn8gg6fVd6Zn4hqvan8_FEwJz44UTXJoG6s_IJns4SbivRyNnyByfGPr8ytzDUQ0fcCmtEJABu9SNr575q9-YuZr-6qa5bzDMtt7PAqSvrcI7z2IWW8quKmf5wD_u74rCuVfQk8aLxqxBb-yoJx-OGhWMAHO1Sxl5wW_MKkYeJvwJjC9vOang1aq_Rcpb0xnPEz5uhjJIUiugFdpL34-mjNyA4dXRHsHiUuOOHTg2tYnyaLZ5Lm1wjmjxv1PT3ks2_d17QHjbBiquE1Bz3k2k0KMvrl9PFqrvrVxBdUq8AFYI-43XpAuJGu2QpxmFcTTz1d5MKgCdfX2hqX3wbg0ehUcEEGHkZE0kjOcnOr2MGb_U9rutEYy4nmUWSIEubrBVFSIJ1vXUua0j7-q9_Zc7per08akEGqCMxxzTXsWxgAAetFb-X-PKNC03SC3KhrFvZu7VlRJUetOb75Vfjhtpv9iSKRhvnlOSDmki5iAlP7jViQdZCeQGI3jSS4734dnRbB44J3WustkK5sj33o0U7gOWTuXtm2KqTDhjMPU5-FdxKKVVd9u4SF71PP2aNfiYv4V14kAB4IVV3qjINz3XUdPRsJK3C8XoNdwJeZTJvQGCIkw7wXNfTC5i634c7c98CT6X2I4d-q2s8HvjLRD9gvTEUE-E0A4GEMWhFwCqfhR0MfRmYKo-OJq6JGz6Z6QqolN4toTGjBJVUhVRMKTyg7g5fJcjYQPLp3gOLpsLd2z0silP1jH9NMI85eGf5_Pp7DSA_aGiwR6nfzgSerJWyCLHlUHK0_vLz0s0rB2u4xtsdttZ1JeIUqlHHcSokzxTLn3cAZ4QfjufMOiWNxcSUKRdt9fMCW4A7ncVEJpraLkJcfEYiE5XVPM_cYL0O6cZQdkJLo8PssIiVz7VWHM6nfnqVb2ILQf0ccuS4_O-HrPo4yMM_Tx5eYbVVXesYUEdQ8fRo34SqFT7i1p5h8kRJGU2xBSUzyKTQxZyzuXqoW5nSj9FMyrHp3hbawKVYbAcX7__GdZ7LjVWiMvRDjhLUpvzGUSBNLQ7OeAM1-ElGwXxyD_T_HWxykpl7q0m1F6hnU-j1Kg4zMFoPSSEYqlQxx_odRrvzhfq2EpiyUeT82V_PjkIVj42s3SEYOqTvLWwGZvTIvLsEzUX4vMoSjpWH3ZBNT-mVw7EY_QRxTe-rughjccvUtS3XBquMfNt7UGW7hWWYUeFmpbbdwy4gWaOH3NCuom-zoHE3XcNrTvamdNDnko-gxMDtd7b90Rbzd-MCXukS6qFqa4sePFY3drMmgD1uz-Rhti3MrtSjC9jiCu98vQKJulf06079XeJffMCcGIyk7GUD_jfFLVeJ4yK3chTz90o5PoS7lpxqbzTTWBoWZA9TcWspXmOTm2p5g49YOHHfDfYRyjXCDDJPnaxRBHYroZrwZP7NjsOQTU8XZCTmmZiRe9EMnGJJBo7B4vKKbM5zmj3czp9ydwOfQamSvM1_YdfVybsa1mpfzIXY_xMenGBvTxCQsZEshhAcoWzC1X1ZoMzilLGxgEct70uXzsuK90HZwbIyynme03hTK4l4vTH1qMjBNti-VnhxiHWKf1zAjRj7g-islGDRgf9mos5wzJ0_FRobCEISuhhKSk3KqNCd4rCAyoJOz_yw8aISP_DzHmCzESdV7ykuOtqjAfkODDL29RyMEpR81Q_ihoD-kIor8xi4pNevAmqpr6EMYN4sweiH6SsZSeh5fCDU5MMRIxipw5w-_9bU6A9XBwYTe5AbCBfcauiCnGzS7ZP0Uxyg7euT2652U6QvcTn2lhHlovL7FCMs19nIXsTBkgNVdHlH7rm_Mi1VAW_lqBBI7rVV0juKITvZIeUrkjfVOhh0ZdeX0dVjp_WPU2BimWiZk_rWG98JSI3zrJFAyJBTj2jIefzueE6kSkQuc3O9uUZWfptLkmmRcKTwQ8piTdQagWxIZ_pNOJo5cLkeLncbA2nbQfuwdNFhprNs65MYa3Q8tZby9sAvbqeY3o3t1Q9ZOF0TNE509kpceZyaWU35eulK8mA3VcGyTGBcNxtCih8T0d1RNzUzlaqpgrsPZEeLJuS6XBr1TPeLMOKGI4a2gdsLKAU7Ce1rAQ-BBcYv_RS_YsFL_FyHSr0QTzE301-TPaowcJQQb7bTDaFgFc9bttDVpOUgm6Zh20-91af2HIw2H-BVjn0Y7uBwFEADo9nIU2cCtWelvvMzGqReBWXRsr2pftwJtbrZozMf2eSniyUzXXd7zYQaSc-WkiejeIA9quvKvaybK2RVldCqP_TF8SaBpDrmboaxFGaSwdsc6L5_apwLkv3MxTx113J1NqqCinYKxjWsNV6wJ2NLiJdEzBkblwNSwSwf2JVfzGvcSEEfHxdNhXvPs7u3iqe1U2hDCyD82GismNhWsdd8k5WtvJ45rlrq7F2ERCe33lqjIp7PwXjhWpfA6WI9OM5Yhnak5Kv-lWQMVnwnrQnOn7vfnw5DwItGgAKFtdHyYSzl0bRB_t4Rb4K8TdVI3vfaT6aPemrHb7IHGQhFlRBceFDQ06nJU9lvmz0lKhXs-oi7EsWSe2KGFHIU76FEiTQEfQmDIaj1tdXqrDlBBVLpi9W9PWtQfQjkGQEmLriln5MRrmwD7BAqw__oiCpkebgONRp1pNvS-TebsmzXgrlrVXHCiKJuLuD_dN5Lkr8m5XSRomqj-yBzVlCHtZTEkDhRiZ7hzcHTE58eJrForozyMMzkgo4ri9M4gWOx8EzE54XmhtRvQu1IzL_O3yBDQyArjqS6xUcv_TVlc9gWsCr3I2S0A7C7EGe2J8195Y363AT-g7tix4CxKGseEHY8SMrtSgngE00wiqsru7R2XMW4QjAZ13ZBOTlqf_qb2DADXKNVl7hFlc27GyQCSihriKJY5P-xizFuq-OStOrKT7VqypP5_hE8uOU0v22k6tzanU7xdeDF8s8S9rw6tKdea038jbr72J94V9KRXwHwoP8zsfw3mbSPMxrkEC0D-7UmkjQMcOYHaWn40cwtUX7B6gRU93AQy7sa8rOdoNHbrNbuuSUmwIMwQn0TEBG6ZDGesIn7yKeBopUip-MAzh3PrHQ8hYZ32hQGI3W76pJf5t42PmMKbtz858MNY3TsNJUNwX8YOb5CAsreUjIw4dRqgp1uhmjbE-VyXrIuI9qu8pju2e_BpwobJBQYXZvnbus3H7Bj2VPlsWNdTPQqk7HEl3qtvhacGo78ofgWjJswW4JOboLJQFbNxomn3rYH3oVbZRg1XJMcFBYzbXjRV89GV9IDNEOHtzx28nK4_gC_KzJCKi1URk6MTrwFl6NLCk64x1j_ZnBOwvne1yN-zjkcAoxBywSTbuheHQ_Mp79kxg9p5_GJMmexv_1FhNauTNdEbaKDuKq2CdNTPt5Z43J37hpzpKv-KftrlhHGj-dS4uZu7phTPKKhkCR_dUvWWy2RC6PVTj1hV8BA8K0y1q2VWWK2xf_XmbzG-VrSRb0wym28NadhCYTcB9uysnH3BhTirtR8Pqqy_kDaw6cURMVVedlEeWgdt-Hs2YhYEXy_q3FdM7LWPgl6HbDigIf2_Xw6JWjqeNTVCMaHrVOoEJax0rbXrqOm8LIB-UBshSrp6ximv0ARLED5jXHDGJgjhojYvWgvPGnUz-Ch8vhwYlwHO4j4kUJBcQqeQXztbqiXJc2KB9ftXDteLmd04tV7w-x_h21glp51p1rfasvarmurE8DNVJ4LlR4JFognzv7tunVwmMg0y8utKGukD9aa7NfZ-3W6srBbnfUcrFWH8Gn76WDq03EXwuRMJngcAh-ivLvjB-0_66O-lVJKLS1A-6yLj3XQc_0zNlZW4jcn_7KLePoZH3Yax6Kli5_BaJBtURK9F-Ot5jHibQub4-xnigiBMjyrLp8vG73bJ5RosfaCZ5qoCkN-PDg9bhSEwTjhPCVqNOC4Bt5OoymN6qzsvHwmI1Fj2h3HsuYxEEnbdQHcIsHGz5NBFHqNehh6pW2jhMm7gIJ2sBLWUxZzzWkO88uC3DqRUDTX8pmH0-bF1MrBYl8V382ADaPiG9Tox-elSPwe1HLDsPNAJzvQXlDHHLf9_MP8F_6AsOENr9wA4xtuHF4WcBMNAZzpHVZUomc1yk5wHiEIotBOQxcTYOEh9vigLXdrMeLRC3nJwTfjj9XG855HTgcAtUJv9A9CKCHu2lkKoCRefyrCixa36Ch9YJ113Fwjmtz9p1sQseflENtYOhj1_FPZVUl7U-yNWAI30fazh40TDGj9qca3KlLiPfAosGTuouzU0h-PmihTfJImDlCbC6BobgA"));
            mockDataProtector.Setup(sut => sut.Unprotect(It.IsAny<byte[]>())).Returns(Encoding.UTF8.GetBytes(expectedTestString));

            mockDataProtectionProvider.Setup(s => s.CreateProtector(It.IsAny<string>())).Returns(mockDataProtector.Object);

            return mockContext.Object;



        }

        public void GetServicesTest()
        {
            var services = new ServiceCollection();

        }

        [TestMethod]
        public void Test_HomeController_Index_SendingNullUser_RedirectsAuthenticationIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };
            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/Autentifikacija/Index", redirectResult.Url);
        }

        [TestMethod]
        public void Test_HomeController_SendingUserKupac_RedirectsToAuthenticationIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            Korisnik kor = _context.Korisnik.Where(k => k.Id == 1).First();

            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(kor)
            };
            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/Autentifikacija/Index", redirectResult.Url);

        }

        [TestMethod]
        public void Test_HomeController_SendingUserMenadzer_RedirectsToAModulMenadzerProizvodiMenadzerIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            Korisnik kor = _context.Korisnik.Where(k => k.Id == 2).First();

            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(kor)
            };

            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/ModulMenadzer/ProizvodiMenadzer/Index", redirectResult.Url);

        }

        [TestMethod]
        public void Test_HomeController_SendingUserAdmin_RedirectsToAModulAdmiKorisniciIndexIndex()
        {
            HomeController hc = new HomeController(_context);
            hc.Url = GetUrlHelper();
            Korisnik kor = _context.Korisnik.Where(k => k.Id == 3).First();

            hc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(kor)
            };

            var redirectResult = hc.Index() as RedirectResult;
            Assert.AreEqual("/ModulAdministrator/Korisnici/Index", redirectResult.Url);

        }






        [TestMethod]
        public void Test_Autentifikacija_Index_REturnsView()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            ViewResult result = ac.Index() as ViewResult;
            LoginVM model = result.Model as LoginVM;

            Assert.AreEqual(true, model.ZapamtiPassword);

        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateNotValid_returnsViewDataMessage()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);

            ac.ModelState.AddModelError("username", "Required");
            ac.ModelState.AddModelError("password", "Required");
            var result = ac.Login(new LoginVM()) as ViewResult;
            LoginVM model = result.Model as LoginVM;

            Assert.AreEqual("Niste unijeli ispravne podatke", result.ViewData["poruka"]);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNull(model.username);
            Assert.IsNull(model.password);
        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateValid_UserNull_returnsViewDataMessage()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            LoginVM novi = new LoginVM
            {
                username = "mmm",
                password = "mmm"
            };
            var result = ac.Login(novi) as ViewResult;
            LoginVM model = result.Model as LoginVM;

            Assert.AreEqual("Pogrešan username ili password", result.ViewData["poruka"]);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(novi, model);
        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateValid_UsernotNull_AuthKeyNotNull_ReturnView_LoginTwoFactor()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);

            ac.TempData = GetTempDataForRedirect();
            ac.ControllerContext = new ControllerContext
            {

                HttpContext = GetMockedHttpContext(_context.Korisnik.First())
            };

            _context.Korisnik.First().TwoFactorUniqueKey = "neki_key";

            LoginVM novi = new LoginVM
            {
                username = "johndoe",
                password = "johndoe"
            };
            var result = (ViewResult)ac.Login(novi);
            Assert.AreEqual("LoginTwoFactor", result.ViewName);
        }

        [TestMethod]
        public void Test_Autentifikacija_Login_ModelStateValid_UserIspravan_AuthKeyNull_redirectsToIndexHome()
        {

            AutentifikacijaController ac = new AutentifikacijaController(_context);

            ac.Url = GetUrlHelper();
            ac.ControllerContext = new ControllerContext
            {

                HttpContext = GetMockedHttpContext()
            };
            LoginVM novi = new LoginVM
            {
                username = "johndoe",
                password = "johndoe"
            };
            var result = (RedirectToActionResult)ac.Login(novi);

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);
        }

        [TestMethod]
        public void Test_Autentifikacija_LoginTwoFactor_ModelstateNotValid_RedirectTologin()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);

            ac.Url = GetUrlHelper();
            ac.ModelState.AddModelError("password", "Required");
            ac.ModelState.AddModelError("username", "Required");

            RedirectToActionResult result = ac.LoginTwoFactor(new LoginTwoFactorVM()) as RedirectToActionResult;

            Assert.AreEqual("Login", result.ActionName);
        }

        [TestMethod]
        public void Test_Autentifikacija_LoginTwoFactor_ModelstateValid_UserNull_ReturnsMessageAndViewLogin()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            LoginTwoFactorVM novi = new LoginTwoFactorVM
            {
                username = "mmm",
                password = "mmm"
            };
            var result = ac.LoginTwoFactor(novi) as ViewResult;
            LoginTwoFactorVM model = result.Model as LoginTwoFactorVM;

            Assert.AreEqual("Pogrešan username ili password", result.ViewData["poruka"]);
            Assert.AreEqual("Login", result.ViewName);

        }

        [TestMethod]
        public void Test_Autentifikacija_LoginTwoFactor_ModelstateValid_UserFirst_WRongCode_ReturnsMessageAndViewLoginTwoFactor()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            LoginTwoFactorVM novi = new LoginTwoFactorVM
            {
                username = "johndoe",
                password = "johndoe",
                TwoFactorPin = "neki"
            };
            _context.Korisnik.First().TwoFactorUniqueKey = "neki_key";
            _context.SaveChanges();

            var result = ac.LoginTwoFactor(novi) as ViewResult;
            LoginTwoFactorVM model = result.Model as LoginTwoFactorVM;

            Assert.AreEqual("Pogrešan kod", result.ViewData["poruka"]);
            Assert.AreEqual("LoginTwoFactor", result.ViewName);

        }

        [TestMethod]
        [DataRow("24e07affc6434408abd3a1f269122ed3")]
        public void Test_Autentifikacija_LoginTwoFactor_ModelstateValid_UserFirst_CorrectCode_RedirectToIndexHome(string key)
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);
            LoginTwoFactorVM novi = new LoginTwoFactorVM
            {
                username = "johndoe",
                password = "johndoe",

            };
            ac.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };

            ac.Url = GetUrlHelper();

            _context.Korisnik.First().TwoFactorUniqueKey = key;
            _context.SaveChanges();

            TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();
            novi.TwoFactorPin = TwoFacAuth.GetCurrentPIN(key);


            RedirectToActionResult result = ac.LoginTwoFactor(novi) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Home", result.ControllerName);

        }

        [TestMethod]
        public void Test_Autentifikacija_Logout__redirectsToIndex()
        {
            AutentifikacijaController ac = new AutentifikacijaController(_context);

            ac.Url = GetUrlHelper();
            ac.ControllerContext = new ControllerContext
            { HttpContext = GetMockedHttpContext() };


            var result = (RedirectToActionResult)ac.Logout();

            // var kor = ac.ControllerContext.HttpContext.GetLogiraniKorisnik();
            // Assert.IsNull(ac.ControllerContext.HttpContext.GetLogiraniKorisnik());
            Assert.AreEqual("Index", result.ActionName);
        }

        //[TestMethod]
        //[DataRow(null, null)]
        //[DataRow(1, 1)]
        //public void Test_Proizvod_Index_ListaProizvoda(int? vrstaID, int? bojaID)
        //{
        //    List<Proizvod> ocekivani = new List<Proizvod>();

        //    if (vrstaID == null && bojaID == null)
        //        ocekivani = _context.Proizvod.ToList();
        //    else
        //        ocekivani = _context.Proizvod.Where(x => x.VrstaProizvodaId == vrstaID && bojaID == null ||
        //                               ((x.ProizvodBojas.Any(pb => pb.BojaId == bojaID) && vrstaID == null) ||
        //                               (x.VrstaProizvodaId == vrstaID && x.ProizvodBojas.Any(pb => pb.BojaId == bojaID)))
        //                             ).ToList();


        //    ProizvodiController pc = new ProizvodiController(_context);


        //    pc.TempData = GetTempDataForRedirect();
        //    ViewResult vr = pc.Index(vrstaID, bojaID) as ViewResult;
        //    ProizvodiIndexVM aktuelni = vr.Model as ProizvodiIndexVM;

        //    Assert.AreEqual(ocekivani.Count, aktuelni.Proizvodi.Count);
        //    Assert.AreEqual(1, aktuelni.Boje.Count);
        //    Assert.AreEqual(2, aktuelni.Vrste.Count);
        //}

        //[TestMethod]
        //[DataRow(1, 1, null)]

        //public void Test_Proizvodi_Detalji_SlanjeNullPopusta_VracaDetaljeProizvodaNaspramIDargumenta(int id, int brojac, int? popust)
        //{

        //    ProizvodiController pc = new ProizvodiController(_context);

        //    pc.TempData = GetTempDataForRedirect();
        //    ViewResult vr = pc.Detalji(id, brojac, popust) as ViewResult;

        //    ProizvodiDetaljiVM aktuelniP = vr.Model as ProizvodiDetaljiVM;

        //    Assert.AreEqual("NazivPr", aktuelniP.Naziv);


        //}

        //[TestMethod]
        //[DataRow(1, 1, 10)]

        //public void Test_Proizvodi_Detalji_SlanjePopustaOd10Posto_VracaDetaljeProizvodaNaspramIDargumenta(int id, int brojac, int? popust)
        //{

        //    ProizvodiController pc = new ProizvodiController(_context);

        //    pc.TempData = GetTempDataForRedirect();
        //    ViewResult vr = pc.Detalji(id, brojac, popust) as ViewResult;

        //    ProizvodiDetaljiVM aktuelniP = vr.Model as ProizvodiDetaljiVM;

        //    Assert.AreEqual("NazivPr", aktuelniP.Naziv);


        //}

        //[TestMethod]
        //public void Test_ProizvodiController_ProvjeraKolicine_ModelStateNotValid_CheckIfItRedirectsToActionDetalji()
        //{
        //    int proizvodId = _context.Proizvod.Select(p => p.Id).First(); //listaProizvodIDs[random.Next(listaProizvodIDs.Count-1)];
        //    int brojac = _context.ProizvodBoja.Where(p => p.ProizvodId == proizvodId).Count();
        //    int bojaID = _context.Boja.Select(b => b.Id).First();

        //    ProizvodiController pc = new ProizvodiController(_context);
        //    pc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    pc.Url = GetUrlHelper();
        //    pc.ModelState.AddModelError("kol", "Required");

        //    var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 110, bojaID, brojac, null);

        //    Assert.AreEqual("Detalji", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
        //}



        ////private const string LogiraniKorisnik = "logirani_korisnik";


        //[TestMethod]
        //[DataRow(1, 1, 1)]
        //public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValid_NemaNaStanju_CheckIfItRedirectsToActionDetalji(int proizvodId, int bojaID, int brojac)
        //{

        //    ProizvodiController pc = new ProizvodiController(_context);
        //    pc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    pc.Url = GetUrlHelper();
        //    var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 110, bojaID, brojac, null);
        //    Assert.AreEqual("Detalji", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        //}

        //[TestMethod]
        //[DataRow(1, 1, 1)]
        //public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValidKolicinaOdgovarajuca_RedirectsToNarudzbaStavke_IndexAction(int proizvodId, int bojaID, int brojac)
        //{

        //    ProizvodiController pc = new ProizvodiController(_context);
        //    pc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    pc.Url = GetUrlHelper();

        //    var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 2, bojaID, brojac, null);


        //    Assert.AreEqual("NarudzbaStavke", result.ControllerName);
        //    Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        //}

        //[TestMethod]
        //[DataRow(1, 1, 1)]
        //public void Test_ProizvodiController_ProvjeraKolicine_ModelStateValid_UserNull_RedirectsToLogin(int proizvodId, int bojaID, int brojac)
        //{
        //    ProizvodiController pc = new ProizvodiController(_context);
        //    pc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext()
        //    };
        //    pc.ControllerContext.HttpContext.SetLogiraniKorisnik(null);
        //    pc.Url = GetUrlHelper();

        //    var result = (RedirectToActionResult)pc.ProvjeraKolicine(proizvodId, 2, bojaID, brojac, null);
        //    Assert.AreEqual("Index", result.ActionName);
        //    Assert.AreEqual("Autentifikacija", result.ControllerName);
        //}

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaDodaj_ViewNotNull_VracaIspravanModel()
        {
            GetMockedHttpContext();
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext(_context.Korisnik.First())
            };

            pmc.TempData = GetTempDataForRedirect();
            ViewResult result = pmc.Dodaj() as ViewResult;
            ProizvodiDodajVM aktualni = result.Model as ProizvodiDodajVM;

            Assert.IsNotNull(pmc.Dodaj());
            Assert.AreEqual(_context.VrstaProizvoda.ToList().Count, aktualni.Vrste.ToList().Count);
            Assert.AreEqual(_context.Boja.ToList().Count, aktualni.Boje.ToList().Count);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaDodaj_UserNull_RedirectToLogin()
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };

            pmc.ControllerContext.HttpContext.SetLogiraniKorisnik(null);
            pmc.Url = GetUrlHelper();
            RedirectToActionResult result = pmc.Dodaj() as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Autentifikacija", result.ControllerName);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateNotValid()
        {
            // GetMockedHttpContext();
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext()
            };
            pmc.ModelState.AddModelError("Naziv", "Required");
            pmc.ModelState.AddModelError("Sifra", "Required");
            pmc.ModelState.AddModelError("Cijena", "Required");
            pmc.ModelState.AddModelError("VrstaID", "Required");
            pmc.ModelState.AddModelError("BojaID", "Required");
            pmc.ModelState.AddModelError("UploadPic", "Required");


            var result = pmc.UploadProduct(new ProizvodiDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateValid_IFormFileNull_RedirectsToDodaj()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(mockEnvironment.Object, _context);
            pmc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            pmc.Url = GetUrlHelper();

            ProizvodiDodajVM newPr = new ProizvodiDodajVM
            {
                Naziv = "...",
                Sifra = "...",
                Cijena = "...",
                VrstaID = 1,
                BojeID = { },
                Slika = "",
                UploadPic = null
            };

            var result = (RedirectToActionResult)pmc.UploadProduct(newPr);

            Assert.AreEqual("Dodaj", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_AkcijaUploadProduct_ModelStateValid_AfterAddedProductRedirectsToIndexProizvodiMenadzer()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(mockEnvironment.Object, _context);
            pmc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            pmc.Url = GetUrlHelper();

            using (var stream = File.OpenRead(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg"))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/jpeg"
                };


                //    var fileMock = new Mock<IFormFile>();
                // //Setup mock file using a memory stream
                // var physicalFile = new FileInfo(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg");
                // var fileName = physicalFile.Name;
                // var ms = new MemoryStream();
                // var writer = new StreamWriter(ms);

                // var image = new Mock<Image>();

                // writer.Write(physicalFile.OpenRead());
                // writer.Flush();
                // ms.Position = 0;
                //fileMock.Setup(_ => _.CopyToAsync(It.IsAny<Stream>(), CancellationToken.None)).
                //    Callback<Stream, CancellationToken>((stream, token) =>
                //    {
                //        //memory stream in this scope is the one that was populated
                //        //when you called **fileStream.CopyTo(memoryStream);** in the test
                //        ms.CopyTo(stream);
                //    }).Returns(Task.CompletedTask);
                //fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
                //fileMock.Setup(_ => _.FileName).Returns(fileName);
                // fileMock.Setup(_ => _.Length).Returns(ms.Length);
                //fileMock.Setup(_ => _.ContentType).Returns("image/jpeg");
                //fileMock.Setup(_ => _.Headers).Returns(new HeaderDictionary());



                //fileMock.Verify();

                // var file = fileMock.Object;

                //fileMock.Object.OpenReadStream().CopyTo(ms);
                // image = Image.FromStream(ms) ;
                //Mock<IFormFile> formFile = new Mock<IFormFile>();
                //formFile.Setup(ff => ff.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                //  .Returns<Stream, CancellationToken>((s, ct) =>
                //  {
                //      byte[] buffer = Encoding.Default.GetBytes(expectedFileContents);
                //      s.Write(buffer, 0, buffer.Length);
                //      return Task.CompletedTask;
                //  });

                //// Set up the form collection with the mocked form
                //Mock<IFormCollection> forms = new Mock<IFormCollection>();
                //forms.Setup(f => f.Files[It.IsAny<int>()]).Returns(formFile.Object);


                int[] temp = { 1, 2 };
                ProizvodiDodajVM newPr = new ProizvodiDodajVM
                {
                    Naziv = "Proizvod123",
                    Sifra = "11111",
                    Cijena = "111.11",
                    VrstaID = 1,
                    BojeID = temp,
                    Slika = "defaultString",
                    UploadPic = file
                };

                var result = (RedirectToActionResult)pmc.UploadProduct(newPr);


                Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
                Assert.AreEqual("ProizvodiMenadzer", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
            }
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_ProizvodiMenadzer_EditAction_CheckIfItReturnsCorrectView(int id)
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.TempData = GetTempDataForRedirect();

            ViewResult vr = pmc.Uredi(id) as ViewResult;

            ProizvodiUrediVM aktuelniP = vr.Model as ProizvodiUrediVM;

            Assert.AreEqual("NazivPr", aktuelniP.Naziv);


        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_EditProductSave_ModelStateValid_RedirectsToActionIdex_ControllerProizvodiMenadzer()
        {
            var mockEnvironment = new Mock<IHostingEnvironment>();
            //...Setup the mock as needed
            mockEnvironment
                .Setup(m => m.EnvironmentName)
                .Returns("Hosting:UnitTestEnvironment");

            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(mockEnvironment.Object, _context);
            pmc.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            pmc.Url = GetUrlHelper();

            using (var stream = File.OpenRead(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg"))
            {
                var file = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg"))
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "image/jpeg"
                };

                /*
                var fileMock = new Mock<IFormFile>();
                //Setup mock file using a memory stream
                var physicalFile = new FileInfo(@"C:\Users\User\Desktop\Namjestaj\garderoba-ph120-313799.jpg");
                var fileName = physicalFile.Name;
                var ms = new MemoryStream();
                var writer = new StreamWriter(ms);


                writer.Write(physicalFile.OpenRead());
                writer.Flush();
                ms.Position = 0;
                fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
                fileMock.Setup(_ => _.FileName).Returns(fileName);
                fileMock.Setup(_ => _.Length).Returns(ms.Length);

                fileMock.Verify();

                var file = fileMock.Object;*/

                int[] temp = { 1, 2 };
                ProizvodiUrediVM newPr = new ProizvodiUrediVM
                {
                    ProizvodId = 1,
                    Naziv = "Proizvod123",
                    Sifra = "11111",
                    Cijena = "111.11",
                    VrstaID = 1,
                    BojeID = temp,
                    Slika = "defaultString",
                    UploadPic = file
                };

                var result = (RedirectToActionResult)pmc.EditProductSave(newPr);

                Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
                Assert.AreEqual("ProizvodiMenadzer", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
                                                                            // Assert.AreEqual(3, _context.Proizvod.Count); 
            }
        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_Index_VrstaNull_VracaSveProizvode()
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);

            pmc.TempData = GetTempDataForRedirect();

            var result = pmc.Index(null) as ViewResult;
            ProizvodiIndexMenadzerVM model = result.Model as ProizvodiIndexMenadzerVM;


            Assert.AreEqual(2, model.Proizvodi.Count);

        }

        [TestMethod]
        [DataRow(2)]
        public void Test_ProizvodiMenadzer_Index_Vrsta2_VracaProizvodteVrste(int id)
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);

            pmc.TempData = GetTempDataForRedirect();


            var result = pmc.Index(id) as ViewResult;
            ProizvodiIndexMenadzerVM model = result.Model as ProizvodiIndexMenadzerVM;


            Assert.AreEqual(1, model.Proizvodi.Count);
            Assert.AreEqual("456888", model.Proizvodi[0].Sifra);
            Assert.AreEqual(2, model.Proizvodi[0].Id);

        }

        [TestMethod]
        public void Test_ProizvodiMenadzer_EditProductSave_ModelStateNotValid_ReturnsBadRequest()
        {

            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);

            pmc.ModelState.AddModelError("Naziv", "Required");
            pmc.ModelState.AddModelError("Sifra", "Required");
            pmc.ModelState.AddModelError("Cijena", "Required");
            pmc.ModelState.AddModelError("VrstaID", "Required");
            pmc.ModelState.AddModelError("BojaID", "Required");


            var result = pmc.EditProductSave(new ProizvodiUrediVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        [DataRow(2)]
        public void Test_ProizvodiMenadzer_Obrisi(int id)
        {
            ProizvodiMenadzerController pmc = new ProizvodiMenadzerController(hostingEnvironment, _context);
            pmc.Url = GetUrlHelper();

            var result = pmc.Obrisi(id) as RedirectToActionResult;

            Assert.AreEqual(1, _context.Proizvod.ToList().Count);
            Assert.AreEqual("Index", result.ActionName);

        }


        //[TestMethod]
        //public void Test_NarudzbaStavke_IndexAkcijaNotNull_CheckIfITreturnsCorrectModel()
        //{
        //    GetMockedHttpContext();
        //    NarudzbaStavkeController ns = new NarudzbaStavkeController(_context);
        //    ns.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };
        //    ns.TempData = GetTempDataForRedirect();

        //    _context.Narudzba.First().Aktivna = true;
        //    _context.SaveChanges();


        //    ViewResult result = ns.Index() as ViewResult;
        //    NarudzbaStavkeIndexVM model = result.Model as NarudzbaStavkeIndexVM;
        //    Assert.AreEqual(1, model.proizvodiNarudzbe.Count);

        //}

        //[TestMethod]
        //public void Test_NarudzbaStavke_IndexAkcija_ReturnsNullInView()
        //{

        //    NarudzbaStavkeController ns = new NarudzbaStavkeController(_context);
        //    ns.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };
        //    ns.TempData = GetTempDataForRedirect();

        //    ViewResult result = ns.Index() as ViewResult;
        //    Assert.IsNull(result.Model);

        //}

        //[TestMethod]
        //[DataRow(1, 1)]
        //public void Test_NarudzbaStavke_ObrisiAkcija_RedirectsToIndex(int id, int narudzbaId)
        //{
        //    NarudzbaStavkeController ns = new NarudzbaStavkeController(_context);
        //    ns.Url = GetUrlHelper();
        //    var result = (RedirectToActionResult)ns.Obrisi(id, narudzbaId);

        //    Assert.AreEqual("Index", result.ActionName);
        //    Assert.AreEqual("NarudzbaStavke", result.ControllerName);
        //    Assert.AreEqual(0, _context.Narudzba.ToList().Count);
        //}



        //[TestMethod]
        //[DataRow(1, "100")]
        //public void Test_Dostava_IndexAkcija_ProvjeraDaLiProsljedjujeIspravanModelNaView(int narudzbaId, string total)
        //{
        //    DostavaController dc = new DostavaController(_context);
        //    ViewResult result = dc.Index(narudzbaId, total) as ViewResult;
        //    DostavaIndexVM model = result.Model as DostavaIndexVM;

        //    Assert.AreEqual(1, model.Dostave.Count);
        //}



        //[TestMethod]
        //[DataRow(1, 0, "100")]
        //public void Test_Narudzbe_ZakljuciAkcija_ModelStateNotValid(int narudzbaId, int dostava, string total)
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.ModelState.AddModelError("dostava", "Required");


        //    var result = (RedirectToActionResult)nc.Zakljuci(narudzbaId, dostava, total);
        //    Assert.AreEqual("Index", result.ActionName);
        //    Assert.AreEqual("NarudzbaStavke", result.ControllerName);
        //}

        //[TestMethod]
        //[DataRow(1, 0, "100")]
        //public void Test_Narudzbe_ZakljuciAkcija_ModelStateValid_ReturnsPartialView(int narudzbaId, int dostava, string total)
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.TempData = GetTempDataForRedirect();

        //    PartialViewResult result = nc.Zakljuci(narudzbaId, dostava, total) as PartialViewResult;
        //    Assert.AreEqual("Zakljuci", result.ViewName);
        //}

        //[TestMethod]
        //public void Test_Narudzbe_IndexAkcija_CheckIfItReturnsValidModel()
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    nc.TempData = GetTempDataForRedirect();

        //    ViewResult result = nc.Index() as ViewResult;
        //    NarudzbeIndexVM model = result.Model as NarudzbeIndexVM;

        //    Assert.AreEqual(1, model.Narudzbe.Count);

        //}

        //[TestMethod]
        //public void Test_Narudzbe_IndexAkcija_CheckIfItReturnsNull()
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    nc.TempData = GetTempDataForRedirect();

        //    _context.Narudzba.First().Aktivna = true;
        //    _context.SaveChanges();

        //    ViewResult result = nc.Index() as ViewResult;

        //    Assert.IsNull(result.Model);

        //}

        //[TestMethod]
        //[DataRow(1)]
        //public void Test_Narudzbe_DetaljiAkcija_VracaListuStavkiNarudzbeSaProslijedjenimID(int id)
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);


        //    PartialViewResult result = nc.Detalji(id) as PartialViewResult;
        //    NarudzbeDetaljiVM model = result.Model as NarudzbeDetaljiVM;

        //    Assert.AreEqual(1, model.DetaljiNarudzbe.Count);
        //}



        [TestMethod]
        public void Test_Sesija_Index_VracaKorektanModel()
        {
            List<AutorizacijskiToken> sesijeOcekivane = _context.AutorizacijskiToken.ToList();
            SesijaController sc = new SesijaController(_context);
            sc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };

            sc.TempData = GetTempDataForRedirect();

            var result = sc.Index() as ViewResult;


            SesijaIndexVM vraceneSesije = result.Model as SesijaIndexVM;

            Assert.AreEqual(sesijeOcekivane[0].Vrijednost, vraceneSesije.Rows[0].token);

        }

        [TestMethod]
        public void Test_Sesija_Obrisi_redirectsToIndex()
        {
            SesijaController sc = new SesijaController(_context);
            sc.ControllerContext = new ControllerContext
            {
                HttpContext = GetMockedHttpContext()
            };
            sc.Url = GetUrlHelper();

            sc.Obrisi(expectedTestString);

            Assert.AreEqual(0, _context.AutorizacijskiToken.ToList().Count);
        }

        //[TestMethod]
        //[DataRow(1)]
        //public void Test_Recenzije_Index_VracaListuRecenzija(int id)
        //{
        //    RecenzijeController rc = new RecenzijeController(_context);

        //    rc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };
        //    rc.TempData = GetTempDataForRedirect();

        //    PartialViewResult result = rc.Index(id) as PartialViewResult;
        //    RecenzijeIndexVM model = result.Model as RecenzijeIndexVM;

        //    Assert.AreEqual(1, model.Recenzijes.Count);
        //    Assert.AreEqual(3, model.Recenzijes[0].Ocjena);
        //    Assert.AreEqual("..", model.Recenzijes[0].Sadrzaj);


        //}

        //[TestMethod]
        //[DataRow(1)]
        //public void Test_Recenzije_Dodaj_VracaViewDodaj(int id)
        //{
        //    RecenzijeController rc = new RecenzijeController(_context);

        //    rc.TempData = GetTempDataForRedirect();

        //    PartialViewResult result = rc.Dodaj(id) as PartialViewResult;
        //    RecenzijeDodajVM model = result.Model as RecenzijeDodajVM;

        //    Assert.AreEqual(1, model.ProizvodId);


        //}



        //[TestMethod]
        //[DataRow(1)]
        //public void Test_Recenzije_Snimi_RedirectsToIndexrecenzije(int id)
        //{
        //    RecenzijeController rc = new RecenzijeController(_context);

        //    rc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };
        //    rc.Url = GetUrlHelper();
        //    RecenzijeDodajVM model = new RecenzijeDodajVM
        //    {
        //        ProizvodId = id,
        //        Sadrzaj = "..",
        //        Ocjena = 3
        //    };
        //    RedirectToActionResult result = rc.Snimi(model) as RedirectToActionResult;

        //    Assert.AreEqual("Index", result.ActionName);
        //    Assert.AreEqual("Recenzije", result.ControllerName);


        //}

        //[TestMethod]
        //[DataRow(1)]
        //public void Test_Recenzije_Snimi_ReturnsBadRequest(int id)
        //{
        //    RecenzijeController rc = new RecenzijeController(_context);

        //    rc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };
        //    rc.Url = GetUrlHelper();

        //    rc.ModelState.AddModelError("Sadrzaj", "Required");


        //    var result = rc.Snimi(new RecenzijeDodajVM());

        //    Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));



        //}

        //[TestMethod]
        //public void Test_Naruudzbe_NaCekanju_VracaNullModel()
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.TempData = GetTempDataForRedirect();
        //    nc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };

        //    ViewResult result = nc.NaCekanjuIndex() as ViewResult;
        //    NaCekanjuIndexVM model = result.Model as NaCekanjuIndexVM;

        //    Assert.AreEqual(null, model);
        //}

        //[TestMethod]
        //public void Test_Naruudzbe_NaCekanju_VracaIspravanModel()
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.TempData = GetTempDataForRedirect();
        //    nc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };
        //    _context.Narudzba.First().NaCekanju = true;
        //    _context.SaveChanges();

        //    ViewResult result = nc.NaCekanjuIndex() as ViewResult;
        //    NaCekanjuIndexVM model = result.Model as NaCekanjuIndexVM;

        //    Assert.AreEqual(1, model.Narudzbe.Count);
        //    Assert.AreEqual(1, model.Narudzbe[0].NarudzbaId);
        //}

        //[TestMethod]
        //[DataRow(1)]
        //public void Test_Nardzbe_Nacekanjuu_Otkazi(int id)
        //{
        //    NarudzbeController nc = new NarudzbeController(_context);
        //    nc.Url = GetUrlHelper();
        //    nc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.Find(1))
        //    };

        //    var result = nc.OtkaziNarudzbu(id) as RedirectToActionResult;

        //    Assert.AreEqual(true, _context.Narudzba.First().Otkazano);
        //    Assert.AreEqual(false, _context.Narudzba.First().NaCekanju);
        //    Assert.AreEqual("NaCekanjuIndex", result.ActionName);
        //    Assert.AreEqual("Narudzbe", result.ControllerName);
        //}

        [TestMethod]
        public void Test_AkcijskiKatalogMenadzer_Index_VracaListuKataloga()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.TempData = GetTempDataForRedirect();

            ViewResult result = ac.Index() as ViewResult;
            AkcijskiKatalogIndexVM model = result.Model as AkcijskiKatalogIndexVM;

            Assert.AreEqual(2, model.Katalozi.Count);

        }

        [TestMethod]
        public void Test_AkcijskiKatalog_Dodaj_ReturnsPartialView()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.TempData = GetTempDataForRedirect();

            PartialViewResult result = ac.Dodaj() as PartialViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_AkcijskiKatalog_Obriši_RedirectToIndex(int id)
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();

            RedirectToActionResult result = ac.Obrisi(id) as RedirectToActionResult;
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        [DataRow(2)]
        public void Test_AkcijskiKatalog_Deaktiviraj_PrimaID_DeaktiviraKatalogSaID_VracaNaIndex(int id)
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();

            RedirectToActionResult result = ac.Deaktiviraj(id) as RedirectToActionResult;
            Assert.AreEqual(false, _context.AkcijskiKatalog.Last().Aktivan);
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void Test_AkcijskiKatalog_SnimiModelStateNotValid_ReturnsBadreq()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();
            ac.ModelState.AddModelError("Opis", "Required");
            ac.ModelState.AddModelError("DatumPocetka", "Required");
            ac.ModelState.AddModelError("DatumZavrsetka", "Required");

            var result = ac.Snimi(new AkcijskiKatalogDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_AkcijskiKatalog_SnimiModelStateValid_RedirectTOIndex()
        {
            AkcijskiKatalogController ac = new AkcijskiKatalogController(_context);
            ac.Url = GetUrlHelper();

            AkcijskiKatalogDodajVM model = new AkcijskiKatalogDodajVM
            {
                Opis = "...",
                DatumPocetka = Convert.ToDateTime("01/01/2020"),
                DatumZavrsetka = Convert.ToDateTime("01/02/2020")
            };

            var result = ac.Snimi(model) as RedirectToActionResult;
            Assert.AreEqual(model.Opis, _context.AkcijskiKatalog.Last().Opis);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("AkcijskiKatalog", result.ControllerName);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_AkcijskikatalogStavke_Index(int id)
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();

            PartialViewResult result = asc.Index(id) as PartialViewResult;
            AkcijskiKatalogStavkeIndexVM model = result.Model as AkcijskiKatalogStavkeIndexVM;

            Assert.AreEqual(1, model.KatalogId);
            Assert.AreEqual(1, model.KatalogProizvodi.Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_AkcijskiKatalogStavke_Dodaj_VracaPartialview(int id)
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();

            PartialViewResult result = asc.Dodaj(id) as PartialViewResult;
            AkcijskiKatalogStavkeDodajVM model = result.Model as AkcijskiKatalogStavkeDodajVM;

            Assert.AreEqual(1, model.Proizvodi.ToList().Count);
            Assert.AreEqual(id, model.KatalogID);
        }

        [TestMethod]
        public void Test_AkcijskiKatalogStavke_SnimiSlanjeNullVracaPartialviewIndex()
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();
            asc.ModelState.AddModelError("ProizvodID", "Required");
            asc.ModelState.AddModelError("Procenat", "Required");

            AkcijskiKatalogStavkeDodajVM par = new AkcijskiKatalogStavkeDodajVM
            {
                KatalogID = 1
            };

            PartialViewResult result = asc.Snimi(par) as PartialViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        public void Test_AkcijskiKatalogStavke_SnimiSlanjeIspravnogModelaVracaPartialviewIndex()
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.TempData = GetTempDataForRedirect();
            AkcijskiKatalogStavkeDodajVM ocekivani = new AkcijskiKatalogStavkeDodajVM
            {
                KatalogID = 1,
                Procenat = 10,
                ProizvodID = 1
            };

            PartialViewResult result = asc.Snimi(ocekivani) as PartialViewResult;
            Assert.AreEqual("Index", result.ViewName);

        }

        [TestMethod]
        [DataRow(1, 1)]
        public void Test_AkcijskiKatalogStavke_Obrisi_SlanjeStavkaIKatalogID_RedirectToIndex(int katalogID, int stavkaID)
        {
            AkcijskiKatalogStavkeController asc = new AkcijskiKatalogStavkeController(_context);
            asc.Url = GetUrlHelper();

            var result = asc.Obrisi(katalogID, stavkaID) as RedirectToActionResult;
            Assert.AreEqual(0, _context.KatalogStavka.ToList().Count);
            Assert.AreEqual("Index", result.ActionName);

        }

        //[TestMethod]
        //public void Test_AkcijskiKatalogKupacIndex_returnsNullInView()
        //{
        //    AkcijskiKatalogKupacController akkc = new AkcijskiKatalogKupacController(_context);
        //    akkc.TempData = GetTempDataForRedirect();

        //    _context.AkcijskiKatalog.Find(2).Aktivan = false;
        //    _context.SaveChanges();
        //    ViewResult result = akkc.Index() as ViewResult;

        //    Assert.AreEqual(null, result.Model);
        //}

        //[TestMethod]
        //public void Test_AkcijskiKatalogKupacIndex_returnsStavkeAktivnogAkcijskogKatalogaInView()
        //{
        //    AkcijskiKatalogKupacController akkc = new AkcijskiKatalogKupacController(_context);
        //    akkc.TempData = GetTempDataForRedirect();

        //    ViewResult result = akkc.Index() as ViewResult;
        //    AkcijskiKatalogKupacIndexVM ocekivani = result.Model as AkcijskiKatalogKupacIndexVM;

        //    Assert.AreEqual("august k.", ocekivani.NazivKataloga);
        //    Assert.AreEqual(1, ocekivani.Proizvodi.Count);
        //}

        //[TestMethod]
        //public void Test_Profil_Index_VracaPodatkeOKupcu()
        //{
        //    ProfilController pc = new ProfilController(_context);
        //    pc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    pc.TempData = GetTempDataForRedirect();

        //    ViewResult result = pc.Index() as ViewResult;
        //    ProfilIndexVM model = result.Model as ProfilIndexVM;

        //    Assert.AreEqual("kupac", model.Ime);
        //    Assert.AreEqual("johndoe", model.KorisnickoIme);
        //}

        //[TestMethod]
        //public void Test_Profil_Uredi_VracaIspravanModel()
        //{
        //    ProfilController pc = new ProfilController(_context);
        //    pc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    pc.TempData = GetTempDataForRedirect();

        //    ViewResult result = pc.Uredi() as ViewResult;
        //    ProfilUrediVM model = result.Model as ProfilUrediVM;

        //    Assert.AreEqual("kupac", model.Ime);
        //    Assert.AreEqual("johndoe", model.KorisnickoIme);
        //}

        //[TestMethod]
        //public void Test_Profil_Snimi_SlanjeNullModela_VracaBadReq()
        //{
        //    ProfilController pc = new ProfilController(_context);
        //    pc.ModelState.AddModelError("KorisnickoIme", "Required");
        //    pc.ModelState.AddModelError("Lozinka", "Required");
        //    pc.ModelState.AddModelError("PotvrdaLozinke", "Required");
        //    pc.ModelState.AddModelError("Ime", "Required");
        //    pc.ModelState.AddModelError("Prezime", "Required");
        //    pc.ModelState.AddModelError("Email", "Required");
        //    pc.ModelState.AddModelError("Adresa", "Required");
        //    pc.ModelState.AddModelError("OpstinaID", "Required");



        //    var result = pc.Snimi(new ProfilUrediVM());

        //    Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        //}

        //[TestMethod]
        //public void Test_Profil_Snimi_SlanjeIspravnogModela_RedirectsTOIndex()
        //{
        //    ProfilController pc = new ProfilController(_context);
        //    pc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    pc.Url = GetUrlHelper();

        //    ProfilUrediVM model = new ProfilUrediVM
        //    {
        //        KorisnickoIme = "user",
        //        Lozinka = "user",
        //        OpstinaID = 1,
        //        Email = "user_mail",
        //        Adresa = "user_Adr",
        //    };

        //    var result = pc.Snimi(model) as RedirectToActionResult;

        //    Assert.AreEqual("Index", result.ActionName);
        //    Assert.AreEqual("user", _context.Korisnik.First().KorisnickoIme);
        //    Assert.AreEqual("user_mail", _context.Kupac.First().Email);

        //}

        //[TestMethod]
        //public void Test_Registracija_Index_VracaListuOpstina()
        //{
        //    RegistracijaController rc = new RegistracijaController(_context);
        //    rc.TempData = GetTempDataForRedirect();

        //    ViewResult result = rc.Index() as ViewResult;
        //    RegistracijaIndexVM model = result.Model as RegistracijaIndexVM;

        //    Assert.AreEqual(1, model.Opstine.Count);
        //}

        //[TestMethod]
        //public void Test_Registracija_Snimi_SlanjeNullVrijednosti_VracaBadReq()
        //{
        //    RegistracijaController rc = new RegistracijaController(_context);
        //    rc.ModelState.AddModelError("KorisnickoIme", "Required");
        //    rc.ModelState.AddModelError("Lozinka", "Required");
        //    rc.ModelState.AddModelError("PotvrdaLozinke", "Required");
        //    rc.ModelState.AddModelError("Ime", "Required");
        //    rc.ModelState.AddModelError("Prezime", "Required");
        //    rc.ModelState.AddModelError("Email", "Required");
        //    rc.ModelState.AddModelError("Adresa", "Required");
        //    rc.ModelState.AddModelError("Spol", "Required");
        //    rc.ModelState.AddModelError("OpstinaID", "Required");

        //    var result = rc.Snimi(new RegistracijaIndexVM());

        //    Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        //}

        //[TestMethod]
        //public void Test_Registracija_Snimi_SlanjeIspravneVrijednosti_RedirectToPrikazPoruke()
        //{
        //    RegistracijaController rc = new RegistracijaController(_context);
        //    rc.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = GetMockedHttpContext()
        //    };
        //    rc.Url = GetUrlHelper();

        //    RegistracijaIndexVM model = new RegistracijaIndexVM
        //    {
        //        KorisnickoIme = "neki",
        //        Lozinka = "neki",
        //        PotvrdaLozinke = "neki",
        //        Ime = "neki",
        //        Prezime = "neki",
        //        Email = "neki",
        //        Adresa = "neki",
        //        Spol = "M",
        //        OpstinaID = 1
        //    };

        //    RedirectToActionResult result = rc.Snimi(model) as RedirectToActionResult;

        //    Assert.AreEqual("PrikazPoruke", result.ActionName);
        //    Assert.AreEqual("neki", _context.Korisnik.Last().KorisnickoIme);
        //    Assert.AreEqual("neki", _context.Kupac.Last().Email);

        //}

        //[TestMethod]
        //public void Test_Registracija_PrikazPoruke_NotNull()
        //{
        //    RegistracijaController rc = new RegistracijaController(_context);
        //    Assert.IsNotNull(rc.PrikazPoruke());
        //}

        
        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Zaposlenici_Obrisi_RedirectTOIndex(int id)
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.Url = GetUrlHelper();

            var result = zc.Obrisi(id) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.Zaposlenik.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Zaposlenici_Uredi_SaljeSeIDZaposlenika_VracaDatogZaposlenika(int id)
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.TempData = GetTempDataForRedirect();

            PartialViewResult result = zc.Uredi(id) as PartialViewResult;
            ZaposleniciUrediVM aktualni = result.Model as ZaposleniciUrediVM;

            Assert.AreEqual("menadzer", aktualni.Ime);
            Assert.AreEqual(2, aktualni.UlogaID);
            Assert.AreEqual("zaposlenik", aktualni.KorisnickoIme);

        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_Snimi_ModelStateNotValidReturnsBadReq()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.ModelState.AddModelError("KorisnickoIme", "Required");
            zc.ModelState.AddModelError("UlogaID", "Required");

            var result = zc.Snimi(new ZaposleniciUrediVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_Snimi_ModelStateValidRedirectTOIndex()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.Url = GetUrlHelper();

            ZaposleniciUrediVM model = new ZaposleniciUrediVM
            {
                ZaposlenikId = 1,
                Ime = "Zapo",
                Prezime = "zapo",
                KorisnickoIme = "zapo",
                UlogaID = 1
            };

            var result = zc.Snimi(model) as RedirectToActionResult;
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_Index_PrimaNULL_VracaListuZaposlenika()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.TempData = GetTempDataForRedirect();

            var result = zc.Index(null) as ViewResult;
            ZaposleniciIndexVM model = result.Model as ZaposleniciIndexVM;

            Assert.AreEqual(2, model.Zaposlenici.Count);
        }

        [TestMethod]
        [DataRow("menadzer")]
        public void Test_Admin_Zaposlenici_Index_PrimaNazivZaposleinka_VracaZaposlenikaSaDatimImenom(string s)
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.TempData = GetTempDataForRedirect();

            var result = zc.Index(s) as ViewResult;
            ZaposleniciIndexVM model = result.Model as ZaposleniciIndexVM;

            Assert.AreEqual(1, model.Zaposlenici.Count);
        }


        [TestMethod]
        public void Test_Admin_Zaposlenici_Dodaj_VracaListuOpstinaIUloga()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.TempData = GetTempDataForRedirect();

            PartialViewResult result = zc.Dodaj() as PartialViewResult;
            ZaposleniciDodajVM model = result.Model as ZaposleniciDodajVM;

            Assert.AreEqual(1, model.Opstine.ToList().Count);
            Assert.AreEqual(4, model.Uloge.ToList().Count);
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_SpremiNovogZaposlenika_ModelStateNotValid_REturnBadReq()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.ModelState.AddModelError("KorisnickoIme", "Required");
            zc.ModelState.AddModelError("Lozinka", "Required");
            zc.ModelState.AddModelError("PotvrdaLozinke", "Required");
            zc.ModelState.AddModelError("Ime", "Required");
            zc.ModelState.AddModelError("Prezime", "Required");
            zc.ModelState.AddModelError("Email", "Required");
            zc.ModelState.AddModelError("Adresa", "Required");
            zc.ModelState.AddModelError("UlogaId", "Required");
            zc.ModelState.AddModelError("OpstinaId", "Required");

            var result = zc.SpremiNovogZaposlenika(new ZaposleniciDodajVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Admin_Zaposlenici_SpremiNovog_ModelStateValid_REdirectToIndex()
        {
            ZaposleniciController zc = new ZaposleniciController(_context);
            zc.Url = GetUrlHelper();

            ZaposleniciDodajVM model = new ZaposleniciDodajVM
            {
                KorisnickoIme = "neki",
                Lozinka = "neki",
                PotvrdaLozinke = "neki",
                Ime = "neki",
                Prezime = "neki",
                Email = "neki",
                Adresa = "neki",
                UlogaId = 1,
                OpstinaId = 1,
                Telefon = "..."
            };

            var result = zc.SpremiNovogZaposlenika(model) as RedirectToActionResult;

            Assert.AreEqual("neki", _context.Zaposlenik.Last().Email);
            Assert.AreEqual("neki", _context.Korisnik.Last().KorisnickoIme);
            Assert.AreEqual("Dodaj", result.ActionName);

        }

        [TestMethod]
        public void Test_Admin_Kupci_Index_PrimaNULL_VracaListuSvihKupaca()
        {
            KupciController kc = new KupciController(_context);
            kc.TempData = GetTempDataForRedirect();

            var result = kc.Index(null) as ViewResult;
            KupciIndexVM model = result.Model as KupciIndexVM;

            Assert.AreEqual(1, model.Kupci.Count);
        }

        [TestMethod]
        [DataRow("kupac")]
        public void Test_Admin_Kupci_Index_PrimaNazivKupca_VracaOdredjenogKupca(string s)
        {
            KupciController kc = new KupciController(_context);
            kc.TempData = GetTempDataForRedirect();

            var result = kc.Index(s) as ViewResult;
            KupciIndexVM model = result.Model as KupciIndexVM;

            Assert.AreEqual(s, model.Kupci.First().Ime);
        }


        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Kupci_Uredi(int id)
        {
            KupciController kc = new KupciController(_context);
            kc.TempData = GetTempDataForRedirect();

            PartialViewResult result = kc.Uredi(id) as PartialViewResult;
            KupciUrediVM model = result.Model as KupciUrediVM;

            Assert.AreEqual("johndoe", model.KorisnickoIme);
            Assert.AreEqual("kupac", model.Ime);
            Assert.AreEqual(id, model.KupacId);
        }

        [TestMethod]
        public void Test_Admin_Kupci_Snimi_ModelStateNotValid_ReturnsBadReq()
        {
            KupciController kc = new KupciController(_context);
            kc.ModelState.AddModelError("KorisnickoIme", "Required");
            kc.ModelState.AddModelError("Lozinka", "Required");
            kc.ModelState.AddModelError("PotvrdaLozinke", "Required");

            var result = kc.Snimi(new KupciUrediVM());

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void Test_Admin_Kupci_Snimi_ModelStateValid_RedirectsToIndex()
        {
            KupciController kc = new KupciController(_context);
            kc.Url = GetUrlHelper();

            KupciUrediVM model = new KupciUrediVM
            {
                KupacId = 1,
                KorisnickoIme = "novi",
                Ime = "novi",
                Prezime = "novi",
                Lozinka = "novi",
                PotvrdaLozinke = "novi"
            };

            RedirectToActionResult result = kc.Snimi(model) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
        }



        [TestMethod]
        [DataRow(1)]
        public void Test_Admin_Kupci_Obrisi_RedirectToIndex(int id)
        {
            KupciController kc = new KupciController(_context);
            kc.Url = GetUrlHelper();

            RedirectToActionResult result = kc.Obrisi(id) as RedirectToActionResult;

            Assert.AreEqual("Index", result.ActionName);
        }

        

        //[TestMethod]
        //public void Test_TwoFactorAuthentication_Index_KorisnikNull_redirectToAutentifikacijaIndex()
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext()
        //    };
        //    tc.ControllerContext.HttpContext.SetLogiraniKorisnik(null);
        //    tc.Url = GetUrlHelper();

        //    RedirectResult result = tc.Index() as RedirectResult;
        //    Assert.AreEqual("/Autentifikacija/Index", result.Url);

        //}

        //[TestMethod]
        //public void Test_TwoFactorAuthentication_Index_KorisnikNotNull_ReturnsMessageAndview()
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext()
        //    };
        //    tc.TempData = GetTempDataForRedirect();

        //    ViewResult result = tc.Index() as ViewResult;
        //    Assert.AreEqual(false, result.ViewData["HasAuthenticator"]);

        //}

        //[TestMethod]
        //public void Test_TwoFactorAuthentication_DozvoliAutentifikator_UserNull_RedirectToLogin()
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext()
        //    };
        //    tc.ControllerContext.HttpContext.SetLogiraniKorisnik(null);
        //    tc.Url = GetUrlHelper();

        //    RedirectResult result = tc.DozvoliAutentifikator() as RedirectResult;
        //    Assert.AreEqual("/Autentifikacija/Index", result.Url);
        //}

        //[TestMethod]
        //public void Test_TwoFactorAuthentication_DozvoliAutentifikator_IspravanKorisnik_ReturnsView_ModelNotNull()
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };

        //    tc.TempData = GetTempDataForRedirect();

        //    ViewResult result = tc.DozvoliAutentifikator() as ViewResult;

        //    Assert.IsNotNull(result.Model);
        //}

        //[TestMethod]
        //public void Test_TwoFactorAuthentication_SnimiAutentifikator_UserNull_RedirectToLogin()
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext()
        //    };
        //    tc.ControllerContext.HttpContext.SetLogiraniKorisnik(null);
        //    tc.Url = GetUrlHelper();

        //    RedirectResult result = tc.SnimiAutentifikator(new KupacAutentifikatorVM()) as RedirectResult;
        //    Assert.AreEqual("/Autentifikacija/Index", result.Url);
        //}

        //[TestMethod]
        //[DataRow("24e07affc6434408abd3a1f269122ed3")]
        //public void Test_TwoFactorAuthentication_SnimiAutentifikator_UserIspravan_RedirectTOIndex(string key)
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    tc.Url = GetUrlHelper();

        //    TwoFactorAuthenticator TwoFacAuth = new TwoFactorAuthenticator();


        //    KupacAutentifikatorVM model = new KupacAutentifikatorVM
        //    {
        //        TwoFactorUserUniqueKey = key,
        //        TwoFactorBarcodeImage = "",
        //        TwoFactorCode = "",
        //        TwoFactorPin = TwoFacAuth.GetCurrentPIN(key)
        //    };

        //    RedirectToActionResult result = tc.SnimiAutentifikator(model) as RedirectToActionResult;

        //    Assert.AreEqual(key, _context.Korisnik.First().TwoFactorUniqueKey);
        //    Assert.AreEqual("Index", result.ActionName);

        //}

        //[TestMethod]
        //public void Test_TwoFactorAuthentication_BrisiAutentifikator_KorisnikNull_RedirectToLogin()
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext()
        //    };
        //    tc.ControllerContext.HttpContext.SetLogiraniKorisnik(null);

        //    tc.Url = GetUrlHelper();

        //    RedirectResult result = tc.BrisiAutentifikator() as RedirectResult;

        //    Assert.AreEqual("/Autentifikacija/Index", result.Url);
        //}

        //[TestMethod]
        //[DataRow("24e07affc6434408abd3a1f269122ed3")]
        //public void Test_TwoFactorAuthentication_BrisiAutentifikator_KorisnikIspravan_RedirectTOIndex(string key)
        //{
        //    TwoFactorAuthenticationController tc = new TwoFactorAuthenticationController(_context);
        //    tc.ControllerContext = new ControllerContext()
        //    {

        //        HttpContext = GetMockedHttpContext(_context.Korisnik.First())
        //    };
        //    _context.Korisnik.First().TwoFactorUniqueKey = key;
        //    tc.Url = GetUrlHelper();

        //    RedirectToActionResult result = tc.BrisiAutentifikator() as RedirectToActionResult;

        //    Assert.IsNull(_context.Korisnik.First().TwoFactorUniqueKey);
        //    Assert.AreEqual("Index", result.ActionName);

        //}

        [TestMethod]
        public void Test_Kategorija_Index_VracaSveKategorijePodkategorije()
        {
            KategorijaController kc = new KategorijaController(_context);

            kc.TempData = GetTempDataForRedirect();

            ViewResult result = kc.Index() as ViewResult;
            KategorijaIndexVM model = result.Model as KategorijaIndexVM;

            Assert.AreEqual(1, model.Kategorije.Count);


            Assert.AreEqual("Ormar", model.Kategorije[0].NazivKategorije);

        }

        [TestMethod]
        public void Test_Kategorija_DodajAkcija_ReturnsPartialView()
        {


            KategorijaController kc = new KategorijaController(_context);

            kc.TempData = GetTempDataForRedirect();


            ViewResult result = kc.Dodaj() as ViewResult;
            KategorijaDodajVM aktualni = result.Model as KategorijaDodajVM;

            Assert.IsNotNull(result);


        }

        [TestMethod]
        public void Test_Kategorija_SnimiNovuKatModelStateNotValid_ReturnsBadreq()
        {
            KategorijaController kc = new KategorijaController(_context);
            kc.Url = GetUrlHelper();
            kc.ModelState.AddModelError("Naziv", "Required");

            var result = kc.SnimiNovuKategoriju(new KategorijaDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Kategorija_SnimiNovuKatModelStateValid_RedirectstoIndex()
        {
            KategorijaController kc = new KategorijaController(_context);
            kc.Url = GetUrlHelper();


            int[] temp = { 1 };
            KategorijaDodajVM model = new KategorijaDodajVM
            {
                Naziv = "Naziv"
            };
            var result = (RedirectToActionResult)kc.SnimiNovuKategoriju(model);


            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
            Assert.AreEqual("Kategorija", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Kategorija_EditAction_CheckIfItReturnsCorrectView(int id)
        {
            KategorijaController kc = new KategorijaController(_context);
            kc.TempData = GetTempDataForRedirect();

            ViewResult vr = kc.Uredi(id) as ViewResult;

            KategorijaUrediVM aktuelniP = vr.Model as KategorijaUrediVM;

            Assert.AreEqual("Ormar", aktuelniP.Naziv);


        }

        [TestMethod]
        public void Test_Kategorija_SnimiPostojecuKatModelStateNotValid_ReturnsBadreq()
        {
            KategorijaController kc = new KategorijaController(_context);
            kc.Url = GetUrlHelper();
            kc.ModelState.AddModelError("Naziv", "Required");

            var result = kc.SnimiPostojecuKat(new KategorijaUrediVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_Kategorija_SnimiPostojecuKatModelStateValid_RedirectstoIndex()
        {
            KategorijaController kc = new KategorijaController(_context);
            kc.Url = GetUrlHelper();


            KategorijaUrediVM model = new KategorijaUrediVM
            {
                KategorijaID = 1,
                Naziv = "Naziv"
            };
            var result = (RedirectToActionResult)kc.SnimiPostojecuKat(model);


            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
            Assert.AreEqual("Kategorija", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
            Assert.AreEqual("Naziv", _context.VrstaProizvoda.First().Naziv);
        }

        //[TestMethod]
        //public void Test_PodKategorija_DodajAkcija_ReturnsPartialView()
        //{


        //    PodkategorijaController pkc = new PodkategorijaController(_context);

        //    pkc.TempData = GetTempDataForRedirect();


        //    PartialViewResult result = pkc.Dodaj() as PartialViewResult;

        //    Assert.IsNotNull(result);

        //}

        //[TestMethod]
        //public void Test_Podkategorija_SnimiModelStateNotValid_ReturnsBadreq()
        //{
        //    PodkategorijaController pkc = new PodkategorijaController(_context);
        //    pkc.Url = GetUrlHelper();
        //    pkc.ModelState.AddModelError("Naziv", "Required");

        //    var result = pkc.Snimi(new PodkategorijaDodajVM());
        //    Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        //}

        //[TestMethod]
        //public void Test_Podkategorija_SnimiModelStateValid_RedirectstoDodajKategorija()
        //{
        //    PodkategorijaController pkc = new PodkategorijaController(_context);
        //    pkc.Url = GetUrlHelper();



        //    PodkategorijaDodajVM model = new PodkategorijaDodajVM
        //    {
        //        Naziv = "Naziv"
        //    };
        //    var result = (RedirectToActionResult)pkc.Snimi(model);


        //    Assert.AreEqual("Dodaj", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);
        //    Assert.AreEqual("Kategorija", result.ControllerName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        //}
        [TestMethod]
        public void Test_NarudzbeMenadzer_Index_DatumNull_VracaSveNarudzbeNaCekanju()
        {
            NarudzbeMenadzerController nmc = new NarudzbeMenadzerController(_context);

            nmc.TempData = GetTempDataForRedirect();

            _context.Narudzba.First().NaCekanju = true;
            _context.SaveChanges();
            var result = nmc.Index(null) as ViewResult;
            NarudzbeMenadzerIndexVM model = result.Model as NarudzbeMenadzerIndexVM;


            Assert.AreEqual(1, model.Narudzbe.Count);

        }

        [TestMethod]
        public void Test_NarudzbeMenadzer_Index_VracaNarudzbeNADatiDatum()
        {
            NarudzbeMenadzerController nmc = new NarudzbeMenadzerController(_context);

            nmc.TempData = GetTempDataForRedirect();
            DateTime dat = Convert.ToDateTime("14-Jun-2021");
            _context.Narudzba.First().NaCekanju = true;
            _context.SaveChanges();
            var result = nmc.Index(dat) as ViewResult;
            NarudzbeMenadzerIndexVM model = result.Model as NarudzbeMenadzerIndexVM;


            Assert.AreEqual(1, model.Narudzbe.Count);
            Assert.AreEqual("1", model.Narudzbe[0].BrojNarudzbe);
            //Assert.AreEqual(2, model.Proizvodi[0].Id);

        }

        [TestMethod]
        [DataRow(1)]

        public void Test_NarudzbeMenadzer_Detalji_VracaDetaljeProizvodaNaspramIDargumenta(int id)
        {

            NarudzbeMenadzerController nmc = new NarudzbeMenadzerController(_context);

            nmc.TempData = GetTempDataForRedirect();
            ViewResult vr = nmc.Detalji(id) as ViewResult;

            NarudzbeMenadzerDetaljiVM aktuelniP = vr.Model as NarudzbeMenadzerDetaljiVM;

            Assert.AreEqual("1", aktuelniP.BrojNarudzbe);
            Assert.AreEqual(1, aktuelniP.StavkeNarudzbe.Count);
            Assert.AreEqual("kupac ...", aktuelniP.ImePrezime);
            Assert.AreEqual("NazivPr", aktuelniP.StavkeNarudzbe[0].NazivProizvoda);


        }

        [TestMethod]
        [DataRow(1)]

        public void Test_NarudzbeMenadzer_Odbij_RedirectsToIndex(int id)
        {
            NarudzbeMenadzerController nmc = new NarudzbeMenadzerController(_context);
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Odbij(id);

            Assert.AreEqual(true, _context.Narudzba.First().Odbijena);
            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]

        public void Test_NarudzbeMenadzer_Odobri_RedirectsToIndex()
        {
            NarudzbeMenadzerController nmc = new NarudzbeMenadzerController(_context);
            nmc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Odobri(1);

            Assert.AreEqual(false, _context.Narudzba.First().NaCekanju);
            Assert.AreEqual(true, _context.Izlaz.Last().Zakljucena);

            Assert.AreEqual("Index", result.ActionName);//(result as RedirectToActionResult).RouteValues["Detalji"]);//result.ActionName);

        }

        [TestMethod]
        public void Test_Normativ_Index_DatumNull_VracaSveNormative()
        {
            NormativController nmc = new NormativController(_context);

            nmc.TempData = GetTempDataForRedirect();

            var result = nmc.Index(null) as ViewResult;
            NormativIndexVM model = result.Model as NormativIndexVM;


            Assert.AreEqual(1, model.Normativi.Count);

        }

        [TestMethod]
        public void Test_Normativ_Index_VracaNormativNADatiDatum()
        {
            NormativController nmc = new NormativController(_context);

            nmc.TempData = GetTempDataForRedirect();
            DateTime dat = Convert.ToDateTime("24-Jun-2021");

            var result = nmc.Index(dat) as ViewResult;
            NormativIndexVM model = result.Model as NormativIndexVM;


            Assert.AreEqual(1, model.Normativi.Count);
            Assert.AreEqual("1", model.Normativi[0].BrojNorm);
            //Assert.AreEqual(2, model.Proizvodi[0].Id);

        }

        [TestMethod]
        public void Test_Normativ_AkcijaDodaj_ViewNotNull_VracaIspravanModel()
        {
            NormativController nmc = new NormativController(_context);

            nmc.TempData = GetTempDataForRedirect();
            PartialViewResult result = nmc.Dodaj() as PartialViewResult;
            NormativDodajVM aktualni = result.Model as NormativDodajVM;

            Assert.IsNotNull(nmc.Dodaj());
            Assert.AreEqual(1, aktualni.Proizvodi.ToList().Count);

        }

        [TestMethod]
        public void Test_Normativ_AkcijaSnimi_ModelStateNotValid_ReturnsBadRequest()
        {
            NormativController nmc = new NormativController(_context);

            nmc.ModelState.AddModelError("BrojNormativa", "Required");
            nmc.ModelState.AddModelError("KolProizvodivo", "Required");
            nmc.ModelState.AddModelError("ProizvodID", "Required");

            var result = nmc.Snimi(new NormativDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void Test_Normativ_AkcijaSnimi_ModelStateValid_RedirectsToIndex()
        {
            NormativController nmc = new NormativController(_context);
            nmc.Url = GetUrlHelper();

            NormativDodajVM nm = new NormativDodajVM
            {
                BrojNormativa = "2",
                ProizvodID = 1
            };

            var result = (RedirectToActionResult)nmc.Snimi(nm);
            Assert.AreEqual("Index", result.ActionName);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Normativ_AkcijaObrisi(int id)
        {
            NormativController nmc = new NormativController(_context);
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Obrisi(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.Normativ.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_Normativ_AkcijaZakljuci_redirectToindex(int id)
        {
            NormativController nmc = new NormativController(_context);
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Zakljuci(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(true, _context.Normativ.First().Zakljucen);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_NormativStavke_Index_VracaSveStavkeOdNormativaSaProslijedjenimIDPar(int id)
        {
            NormativStavkeController nsc = new NormativStavkeController(_context);

            nsc.TempData = GetTempDataForRedirect();

            var result = nsc.Index(id) as PartialViewResult;
            NormativStavkeIndexVM model = result.Model as NormativStavkeIndexVM;


            Assert.AreEqual(1, model.StavkeNormativa.Count);

        }



        [TestMethod]
        [DataRow(1)]
        public void Test_NormativStavke_AkcijaDodaj_ProsljedjujeIDNormativa_ViewNotNull_VracaIspravanModel(int id)
        {
            NormativStavkeController nsc = new NormativStavkeController(_context);

            nsc.TempData = GetTempDataForRedirect();
            PartialViewResult result = nsc.Dodaj(id) as PartialViewResult;
            NormativStavkeDodajVM aktualni = result.Model as NormativStavkeDodajVM;

            Assert.IsNotNull(nsc.Dodaj(id));
            Assert.AreEqual(0, aktualni.Materijali.ToList().Count);

        }

        [TestMethod]
        public void Test_NormativStavke_AkcijaSnimi_ModelStateNotValid_ReturnsBadRequest()
        {
            NormativStavkeController nsc = new NormativStavkeController(_context);

            nsc.ModelState.AddModelError("Naziv", "Required");
            nsc.ModelState.AddModelError("MaterijalId", "Required");

            var result = nsc.Snimi(new NormativStavkeDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void Test_NormativStavke_AkcijaSnimi_ModelStateValid_RedirectsToIndex()
        {
            NormativStavkeController nsc = new NormativStavkeController(_context);
            nsc.Url = GetUrlHelper();

            NormativStavkeDodajVM nm = new NormativStavkeDodajVM
            {
                MaterijalID = 1,
                NormativId = 1,
                Kol = 10
            };

            var result = (RedirectToActionResult)nsc.Snimi(nm);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);

        }

        [TestMethod]
        [DataRow(1, 1)]
        public void Test_NormativStavke_AkcijaObrisi(int id, int idNormativ)
        {
            NormativStavkeController nsc = new NormativStavkeController(_context);
            nsc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nsc.Obrisi(id, idNormativ);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);
            Assert.AreEqual(0, _context.NormativStavka.ToList().Count);
        }

        [TestMethod]
        public void Test_NabavkaProizvod_Index_DatumIBrojNULL_VracaSveNabavkeProizvoda()
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);

            npc.TempData = GetTempDataForRedirect();

            var result = npc.Index(null, null) as ViewResult;
            NabavkaProizvodIndexVM model = result.Model as NabavkaProizvodIndexVM;


            Assert.AreEqual(1, model.Nabavke.Count);
        }

        [TestMethod]
        [DataRow("NAB-PR-2021-29-06-1")]
        public void Test_NabavkaProizvod_Index_DatumNULL_BrojPretragePostojeci_VracaNabavkuSaDatimBrojem(string br)
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);

            npc.TempData = GetTempDataForRedirect();

            var result = npc.Index(null, br) as ViewResult;
            NabavkaProizvodIndexVM model = result.Model as NabavkaProizvodIndexVM;

            Assert.AreEqual(1, model.Nabavke.Count);
            Assert.AreEqual("NAB-PR-2021-29-06-1", model.Nabavke[0].BrojNabavke);

        }

        [TestMethod]
        public void Test_NabavkaProizvod_Index_BrojPretrageNULL_VracaNabavkeNaPostojeciDatum()
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);

            npc.TempData = GetTempDataForRedirect();

            var result = npc.Index(DateTime.Now, null) as ViewResult;
            NabavkaProizvodIndexVM model = result.Model as NabavkaProizvodIndexVM;

            Assert.AreEqual(1, model.Nabavke.Count);
            Assert.AreEqual("NAB-PR-2021-29-06-1", model.Nabavke[0].BrojNabavke);
            Assert.AreEqual(DateTime.Now.Date, model.Nabavke[0].Datum);
        }

        [TestMethod]
        public void Test_NabavkaProizvod_AkcijaDodaj_ViewNotNull_VracaIspravanModel()
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);

            npc.TempData = GetTempDataForRedirect();

            ViewResult result = npc.Dodaj() as ViewResult;
            NabavkaProizvodDodajVM model = result.Model as NabavkaProizvodDodajVM;

            Assert.IsNotNull(npc.Dodaj());
            Assert.AreEqual(1, model.Dobavljaci.ToList().Count);
            Assert.AreEqual(1, model.SkladisteId);

        }

        [TestMethod]
        public void Test_NabavkaProizvod_AkcijaSnimi_ModelStateNotValid_ReturnsBadRequest()
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);

            npc.ModelState.AddModelError("Datum", "Required");
            npc.ModelState.AddModelError("BrojNabavke", "Required");
            npc.ModelState.AddModelError("DobavljacId", "Required");
            npc.ModelState.AddModelError("SkladisteId", "Required");
            npc.ModelState.AddModelError("KorisnikId", "Required");


            var result = npc.Snimi(new NabavkaProizvodDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void Test_NabavkaProizvod_AkcijaSnimi_ModelStateValid_RedirectsToIndex()
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);
            npc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            npc.Url = GetUrlHelper();

            NabavkaProizvodDodajVM np = new NabavkaProizvodDodajVM
            {
                DobavljacID = 1,
                SkladisteId = 1
            };

            var result = (RedirectToActionResult)npc.Snimi(np);
            Assert.AreEqual("Index", result.ActionName);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaProizvod_Obrisi_PrimaId_VracaNaIndexView(int id)
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);
            npc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)npc.Obrisi(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.NabavkaProizvod.ToList().Count);
            Assert.AreEqual(0, _context.NabavkaProizvodStavka.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaProizvod_Zakljuci_PrimaId_VracaNaIndex(int id)
        {
            NabavkaProizvodController npc = new NabavkaProizvodController(_context);
            npc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            npc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)npc.Zakljuci(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.UlazProizvod.ToList().Count);
            Assert.AreEqual(1, _context.UlazProizvodStavke.ToList().Count);
        }


        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaProizvodStavke_Index_VracaSveStavkeNabavkeProizvodaSaDatimID(int id)
        {
            NabavkaProizvodStavkeController npc = new NabavkaProizvodStavkeController(_context);

            npc.TempData = GetTempDataForRedirect();

            var result = npc.Index(id) as PartialViewResult;
            NabavkaProizvodStavkeIndexVM model = result.Model as NabavkaProizvodStavkeIndexVM;


            Assert.AreEqual(1, model.StavkeNabavke.Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaProizvodStavke_Dodaj_VracaIspravanViewIModel(int id)
        {
            NabavkaProizvodStavkeController npc = new NabavkaProizvodStavkeController(_context);

            npc.TempData = GetTempDataForRedirect();

            var result = npc.Dodaj(id) as PartialViewResult;
            NabavkaProizvodStavkeDodajVM model = result.Model as NabavkaProizvodStavkeDodajVM;

            Assert.IsNotNull(npc.Dodaj(id));
            Assert.AreEqual(0, model.Proizvodi.ToList().Count);
            Assert.AreEqual(1, model.NabavkaId);

        }

        [TestMethod]
        public void Test_NabavkaProizvodStavke_Snimi_ModelStateNotValid_ReturnsBadRequest()
        {
            NabavkaProizvodStavkeController nsc = new NabavkaProizvodStavkeController(_context);

            nsc.ModelState.AddModelError("NabavkaId", "Required");
            nsc.ModelState.AddModelError("ProizvodId", "Required");
            nsc.ModelState.AddModelError("Kol", "Required");


            var result = nsc.Snimi(new NabavkaProizvodStavkeDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        [TestMethod]
        public void Test_NabavkaProizvodStavke_AkcijaSnimi_ModelStateValid_RedirectsToIndex()
        {
            NabavkaProizvodStavkeController npc = new NabavkaProizvodStavkeController(_context);
            npc.Url = GetUrlHelper();

            NabavkaProizvodStavkeDodajVM nm = new NabavkaProizvodStavkeDodajVM
            {
                NabavkaId = 1,
                ProizvodId = 1,
                Kol = 10
            };

            var result = (RedirectToActionResult)npc.Snimi(nm);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        [DataRow(1, 1)]
        public void Test_NabavkaProizvodStavke_Obrisi_VracaNAIndex(int id, int idNabavka)
        {
            NabavkaProizvodStavkeController npc = new NabavkaProizvodStavkeController(_context);
            npc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)npc.Obrisi(id, idNabavka);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);
            Assert.AreEqual(0, _context.NabavkaProizvodStavka.ToList().Count);
        }

        
         [TestMethod]
        public void Test_NabavkaMaterijal_Index_DatumIBrojNULL_VracaSveNabavkeMaterijala()
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);

            nmc.TempData = GetTempDataForRedirect();

            var result = nmc.Index(null, null) as ViewResult;
            NabavkaMaterijalIndexVM model = result.Model as NabavkaMaterijalIndexVM;


            Assert.AreEqual(1, model.Nabavke.Count);
        }
        
        [TestMethod]
        [DataRow("NAB-MAT-2021-29-06-1")]
        public void Test_NabavkaMaterijal_Index_DatumNULL_BrojPretragePostojeci_VracaNabavkuSaDatimBrojem(string br)
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);

            nmc.TempData = GetTempDataForRedirect();

            var result = nmc.Index(null, br) as ViewResult;
            NabavkaMaterijalIndexVM model = result.Model as NabavkaMaterijalIndexVM;

            Assert.AreEqual(1, model.Nabavke.Count);
            Assert.AreEqual("NAB-MAT-2021-29-06-1", model.Nabavke[0].BrojNabavke);

        }
        
        [TestMethod]
        public void Test_NabavkaMaterijal_Index_BrojPretrageNULL_VracaNabavkeNaPostojeciDatum()
        {
            NabavkaMaterijalController npc = new NabavkaMaterijalController(_context);

            npc.TempData = GetTempDataForRedirect();

            var result = npc.Index(DateTime.Now, null) as ViewResult;
            NabavkaMaterijalIndexVM model = result.Model as NabavkaMaterijalIndexVM;

            Assert.AreEqual(1, model.Nabavke.Count);
            Assert.AreEqual("NAB-MAT-2021-29-06-1", model.Nabavke[0].BrojNabavke);
            Assert.AreEqual(DateTime.Now.Date, model.Nabavke[0].Datum);
        }
        
        [TestMethod]
        public void Test_NabavkaMaterijal_AkcijaDodaj_ViewNotNull_VracaIspravanModel()
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);

            nmc.TempData = GetTempDataForRedirect();

            ViewResult result = nmc.Dodaj() as ViewResult;
            NabavkaMaterijalDodajVM model = result.Model as NabavkaMaterijalDodajVM;

            Assert.IsNotNull(nmc.Dodaj());
            Assert.AreEqual(1, model.Dobavljaci.ToList().Count);
            Assert.AreEqual(2, model.SkladisteId);

        }
        
        [TestMethod]
        public void Test_NabavkačMaterijal_AkcijaSnimi_ModelStateNotValid_ReturnsBadRequest()
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);

            nmc.ModelState.AddModelError("Datum", "Required");
            nmc.ModelState.AddModelError("BrojNabavke", "Required");
            nmc.ModelState.AddModelError("DobavljacId", "Required");
            nmc.ModelState.AddModelError("SkladisteId", "Required");
            nmc.ModelState.AddModelError("KorisnikId", "Required");


            var result = nmc.Snimi(new NabavkaMaterijalDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }
        
        [TestMethod]
        public void Test_NabavkaMaterijal_AkcijaSnimi_ModelStateValid_RedirectsToIndex()
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);
            nmc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            nmc.Url = GetUrlHelper();

            NabavkaMaterijalDodajVM nm = new NabavkaMaterijalDodajVM
            {
                DobavljacID = 1,
                SkladisteId = 2
            };

            var result = (RedirectToActionResult)nmc.Snimi(nm);
            Assert.AreEqual("Index", result.ActionName);

        }
        
        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaMaterijal_Obrisi_PrimaId_VracaNaIndexView(int id)
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Obrisi(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.NabavkaMaterijal.ToList().Count);
            Assert.AreEqual(0, _context.NabavkaMaterijalStavka.ToList().Count);
        }
        
        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaMaterijal_Zakljuci_PrimaId_VracaNaIndex(int id)
        {
            NabavkaMaterijalController nmc = new NabavkaMaterijalController(_context);
            nmc.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Zakljuci(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, _context.UlazMaterijal.ToList().Count);
            Assert.AreEqual(1, _context.UlazMaterijalStavke.ToList().Count);
        }

        
        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaMaterijalStavke_Index_VracaSveStavkeNabavkeMaterijalaSaDatimID(int id)
        {
            NabavkaMaterijalStavkeController nmc = new NabavkaMaterijalStavkeController(_context);

            nmc.TempData = GetTempDataForRedirect();

            var result = nmc.Index(id) as PartialViewResult;
            NabavkaMaterijalStavkeIndexVM model = result.Model as NabavkaMaterijalStavkeIndexVM;


            Assert.AreEqual(1, model.MaterijalStavkeNabavke.Count);
        }
        
        [TestMethod]
        [DataRow(1)]
        public void Test_NabavkaMaterijalStavke_Dodaj_VracaIspravanViewIModel(int id)
        {
            NabavkaMaterijalStavkeController nmc = new NabavkaMaterijalStavkeController(_context);

            nmc.TempData = GetTempDataForRedirect();

            var result = nmc.Dodaj(id) as PartialViewResult;
            NabavkaMaterijalStavkeDodajVM model = result.Model as NabavkaMaterijalStavkeDodajVM;

            Assert.IsNotNull(nmc.Dodaj(id));
            Assert.AreEqual(0, model.Materijali.ToList().Count);
            Assert.AreEqual(1, model.NabavkaId);

        }
        
        [TestMethod]
        public void Test_NabavkaMaterijalStavke_Snimi_ModelStateNotValid_ReturnsBadRequest()
        {
            NabavkaMaterijalStavkeController nmc = new NabavkaMaterijalStavkeController(_context);

            nmc.ModelState.AddModelError("NabavkaId", "Required");
            nmc.ModelState.AddModelError("MaterijalId", "Required");
            nmc.ModelState.AddModelError("Kol", "Required");


            var result = nmc.Snimi(new NabavkaMaterijalStavkeDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }
        
        [TestMethod]
        public void Test_NabavkaMaterijalStavke_Snimi_ModelStateValid_RedirectsToIndex()
        {
            NabavkaMaterijalStavkeController nmc = new NabavkaMaterijalStavkeController(_context);
            nmc.Url = GetUrlHelper();

            NabavkaMaterijalStavkeDodajVM nm = new NabavkaMaterijalStavkeDodajVM
            {
                NabavkaId = 1,
                MaterijalId = 1,
                Kol = 10
            };

            var result = (RedirectToActionResult)nmc.Snimi(nm);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }
        
        [TestMethod]
        [DataRow(1, 1)]
        public void Test_NabavkaMaterijalStavke_Obrisi_VracaNAIndex(int id, int idNabavka)
        {
            NabavkaMaterijalStavkeController nmc = new NabavkaMaterijalStavkeController(_context);
            nmc.Url = GetUrlHelper();

            var result = (RedirectToActionResult)nmc.Obrisi(id, idNabavka);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(1, result.RouteValues["id"]);
            Assert.AreEqual(0, _context.NabavkaMaterijalStavka.ToList().Count);
        }

        [TestMethod]
        public void Test_ProizvodniNalog_Index_ProsljedjujeNULLDatumINULLProizvod_VracaPrazanModel()
        {
            _context.Normativ.Remove(_context.Normativ.Last());
            _context.SaveChanges();

            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.Url = GetUrlHelper();

            var result = pn.Index(null, null) as ViewResult;
            ProizvodniNalogIndexVM model = result.Model as ProizvodniNalogIndexVM;

            Assert.IsNull(model);
        }

        [TestMethod]
        public void Test_ProizvodniNalog_Index_ProsljedjujeNULLDatumINULLProizvod_VracaSveNaloge()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.Url = GetUrlHelper();

            var result = pn.Index(null, null) as ViewResult;
            ProizvodniNalogIndexVM model = result.Model as ProizvodniNalogIndexVM;

            Assert.AreEqual(1,model.Nalozi.Count);
            Assert.AreEqual("NALOG-2020-8-7-1", model.Nalozi[0].BrNaloga);
        }

        [TestMethod]
        public void Test_ProizvodniNalog_Index_DatumDanasnji_ProizvodIDNULL_VracaNalogeNADanasnjiDatum()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.Url = GetUrlHelper();

            var result = pn.Index(DateTime.Now, null) as ViewResult;
            ProizvodniNalogIndexVM model = result.Model as ProizvodniNalogIndexVM;

            Assert.AreEqual(1, model.Nalozi.Count);
            Assert.AreEqual("NALOG-2020-8-7-1", model.Nalozi[0].BrNaloga);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_ProizvodniNalog_Index_DatumNULL_ProizvodIdPostojeci_VracaNalogZaDatiProizvod(int id)
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.Url = GetUrlHelper();

            var result = pn.Index(null, id) as ViewResult;
            ProizvodniNalogIndexVM model = result.Model as ProizvodniNalogIndexVM;

            Assert.AreEqual(1, model.Nalozi.Count);
            Assert.AreEqual("NALOG-2020-8-7-1", model.Nalozi[0].BrNaloga);
        }

        [TestMethod]
        public void Test_ProizvodniNalog_Dodaj_ViewNotNull_VracaIpravanModel()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.TempData = GetTempDataForRedirect();

            var result = pn.Dodaj() as ViewResult;
            ProizvodniNalogDodajVM model = result.Model as ProizvodniNalogDodajVM;

            Assert.IsNotNull(pn.Dodaj());
            Assert.AreEqual(1, model.Proizvodi.ToList().Count);
            Assert.AreEqual(1, model.SkladistaMat.ToList().Count);
            Assert.AreEqual(1, model.SkladistaPr.ToList().Count);
            
        }

        [TestMethod]
        public void Test_ProizvodniNalog_Snimi_ModelstateNotValid_VracaBadRequest()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);

            pn.ModelState.AddModelError("ProizvodId", "Required");
            pn.ModelState.AddModelError("SkladisteMaterijalaId", "Required");
            pn.ModelState.AddModelError("SkladisteProizvodaId", "Required");
            pn.ModelState.AddModelError("Kolicina", "Required");


            var result = pn.Snimi(new ProizvodniNalogDodajVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_ProizvodniNalog_Snimi_ModelStateValid_VracaNAAkcijuIndex()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            pn.Url = GetUrlHelper();

            ProizvodniNalogDodajVM model = new ProizvodniNalogDodajVM
            {
                ProizvodID = 2,
                SkladistePrID = 1,
                SkladisteMatID=2,
                Kol=5
            };

            var result = (RedirectToActionResult)pn.Snimi(model);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(2, _context.ProizvodniNalog.First().ProizvodId);

        }

        [TestMethod]
        [DataRow(1)]
        public void Test_ProizvodniNalog_Obrisi_PrimaId_VracaNaIndexView(int id)
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
           
            pn.Url = GetUrlHelper();

            var result = (RedirectToActionResult)pn.Obrisi(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(0, _context.ProizvodniNalog.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void test_ProizvodniNalog_Zakljuci_VracaNaIndex(int id)
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.ControllerContext = new ControllerContext()
            {
                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            pn.Url = GetUrlHelper();
           
            var result = (RedirectToActionResult)pn.Zakljuci(id);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual(true, _context.ProizvodniNalog.Last().Zakljucen);
            Assert.AreEqual(105, _context.ProizvodSkladiste.First().Kolicina);
        }

        [TestMethod]
        [DataRow(1)]
        public void Test_ProizvodniNalog_Uredi_PrimaId_Vraca(int id)
        {
            ProizvodniNalogController pn = new ProizvodniNalogController( _context);
            pn.TempData = GetTempDataForRedirect();

            ViewResult vr = pn.Uredi(id) as ViewResult;

            ProizvodniNalogUrediVM aktuelniP = vr.Model as ProizvodniNalogUrediVM;

            Assert.AreEqual("NALOG-2020-8-7-1", aktuelniP.BrNaloga);
        }

        [TestMethod]
        public void Test_ProizvodniNalog_SnimiEditovaniNalog_ModelStateNotValid_VracaBadRequest()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);

            pn.ModelState.AddModelError("ProizvodId", "Required");
            pn.ModelState.AddModelError("SkladisteMaterijalaId", "Required");
            pn.ModelState.AddModelError("SkladisteProizvodaId", "Required");
            pn.ModelState.AddModelError("Kolicina", "Required");


            var result = pn.SnimiEditovaniNalog(new ProizvodniNalogUrediVM());
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Test_ProizvodniNalog_SnimiEditovaniNalog_ModelstateValid_VracaNaIndex()
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.ControllerContext = new ControllerContext()
            {

                HttpContext = GetMockedHttpContext(_context.Korisnik.Find(2))
            };
            pn.Url = GetUrlHelper();

            ProizvodniNalogUrediVM model = new ProizvodniNalogUrediVM
            {
                Id=1,
                ProizvodId=1,
                SkladisteMatID=2,
                SkladistePrID=1,
                Kol=5
            };


            var result = (RedirectToActionResult)pn.SnimiEditovaniNalog(model);

            Assert.AreEqual("Index", result.ActionName);


        }

        [TestMethod]
        public void Test_ProizvodniNalog_Detalji_PrimaNULLId_VracaNULLModel()
        {
            ProizvodniNalogController pn= new ProizvodniNalogController(_context);
            pn.TempData = GetTempDataForRedirect();

            var result=pn.Detalji(null, null) as ViewResult;
            ProizvodniNalogDetaljiVM model = result.Model as ProizvodniNalogDetaljiVM;

            Assert.IsNull(model);
        }

        [TestMethod]
        [DataRow(1,1)]
        public void Test_ProizvodniNalog_DetaljiPrimaID_VracaStavkeNalogaSaDatimID(int id, int nalogId)
        {
            ProizvodniNalogController pn = new ProizvodniNalogController(_context);
            pn.TempData = GetTempDataForRedirect();

            var result = pn.Detalji(id, nalogId) as ViewResult;
            ProizvodniNalogDetaljiVM model = result.Model as ProizvodniNalogDetaljiVM;

            Assert.AreEqual("neki",model.StavkeNaloga[0].NazivMat);
        }
    }
}

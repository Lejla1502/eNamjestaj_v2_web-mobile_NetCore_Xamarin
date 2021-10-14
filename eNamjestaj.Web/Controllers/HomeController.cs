﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eNamjestaj.Web.Models;
using eNamjestaj.Data.Helper;
using eNamjestaj.Data;
using eNamjestaj.Data.Models;

namespace eNamjestaj.Web.Controllers
{
    public class HomeController : Controller
    {
        private MojContext ctx;
        public HomeController(MojContext _ctx)
        {
            ctx = _ctx;
        }
        public IActionResult Index()
        {
            
            Korisnik k = Autentifikacija.GetLogiraniKorisnik(HttpContext);

            if (k == null)
                return Redirect("/Autentifikacija/Index");//return RedirectToAction("Logout", "Autentifikacija", new { area = "" });
            else if (k.UlogaId == 1)
                return Redirect("/ModulAdministrator/Dashboard/Index");
            else if (k.UlogaId == 2)
                return Redirect("/ModulMenadzer/Dashboard/Index");
            else
                return Redirect("/Autentifikacija/Index");
        }

        public IActionResult Proba()
        {
            return View();
        }

        
    }
}

using Microsoft.AspNetCore.Mvc;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulAdministrator.ViewModels
{
    public class KupciIndexVM
    {
        public List<KorisnikInfo> Kupci { get; set; }
        public string KupciPretraga { get; set; }
        //page number variable
        [BindProperty(SupportsGet = true)]
        public int P { get; set; } = 1;

        //page size variable
        [BindProperty(SupportsGet = true)]
        public int S { get; set; } = 5;

        public int TotalRecords { get; set; } = 0;

        public class KorisnikInfo
        {
            public int KupacId { get; set; }
            public string KorisnickoIme { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Email { get; set; }
            public string Adresa { get; set; }
        }
    }
}

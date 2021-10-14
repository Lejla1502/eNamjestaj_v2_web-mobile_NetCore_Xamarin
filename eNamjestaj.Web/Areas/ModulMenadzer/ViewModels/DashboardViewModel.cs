using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class DashboardViewModel
    {
        public int BrProdanihProizvoda { get; set; }
        public int BrProizvoda { get; set; }
        public int BrKorisnika { get; set; }
        public int BrProizvodaNaSnizenju { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public decimal Zarada { get; set; }

        public List<int> KolicineNajprodavanijihProizvoda { get; set; }
        public List<string> NaziviNajprodavanijihProizvoda { get; set; }
        public List<int> BrProdanihProizvodaPoMjesecima { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class NarudzbeMenadzerDetaljiVM
    {
        public int NarudzbaID { get; set; }
        public string BrojNarudzbe { get; set; }
        public string Adresa { get; set; }
        public string ImePrezime { get; set; }
        public string Dostava { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public decimal TotalBezPDVa { get; set; }
        public decimal TotalSaPDVom { get; set; }
        public int BrojPutaOtkazao { get; set; }


        public List<NarudzbaStavkeInfo> StavkeNarudzbe { get; set; }
        public bool daLiIjednaStavkaManjkaNaStanju { get; set; }

        public class NarudzbaStavkeInfo
        {
            public string NazivProizvoda { get; set; }
            public int Kolicina { get; set; }
            public string Boja { get; set; }
            public decimal Cijena { get; set; }
            public int Popust { get; set; }
            public decimal TotalStavka { get; set; }
            public string KonacnaCijena { get; set; }
            public int DostupnaKolicinaNaSkladistu { get; set; }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Web.Areas.ModulMenadzer.ViewModels
{
    public class KategorijaIndexVM
    {
        public List<KategorijeInfo> Kategorije { get; set; }

        public class KategorijeInfo
        {
            public int Id { get; set; }
            public string NazivKategorije { get; set; }
            //public string NazivTopkategorije { get; set; }
        }
    }
}

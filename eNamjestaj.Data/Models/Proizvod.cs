using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.Data.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public string Slika { get; set; }

        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int VrstaProizvodaId { get; set; }
        public virtual VrstaProizvoda VrstaProizvoda { get; set; }
        
        public int OpisProizvodaId { get; set; }
        public virtual OpisProizvoda OpisProizvoda { get; set; }

        public ProizvodSkladiste ProizvodSkladiste { get; set; }
        public DobavljacProizvod DobavljacProizvod { get; set; }

        public Normativ Normativ { get; set; }


        public ICollection<ProizvodBoja> ProizvodBojas { get; set; }

        
    }
}

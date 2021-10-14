using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class ProizvodUpsertRequest
    {
        
        [Required(AllowEmptyStrings = false)]
        public string Naziv { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Sifra { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Cijena { get; set; }
        public string Slika { get; set; }
        public int KorisnikId { get; set; }
        public int VrstaProizvodaId { get; set; }
        public int? OpisProizvodaId { get; set; }
    }
}

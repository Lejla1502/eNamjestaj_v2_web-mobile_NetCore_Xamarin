using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Models
{
    public class MaterijalSkladiste
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int SkladisteId { get; set; }
        public virtual Skladiste Skladiste{get;set;}
        public int MaterijalId { get; set; }
        public  Materijal Materijal { get; set; }
    }
}

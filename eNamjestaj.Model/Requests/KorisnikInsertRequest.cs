using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eNamjestaj.Model.Requests
{
    public class KorisnikInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }
        [Required(AllowEmptyStrings =false)]
        [MinLength(4)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string PasswordConfirmation { get; set; }
        [Required]
        public int OpstinaId { get; set; }
        public int UlogaId { get; set; }

       
        /*[Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^(\+)?([0-9]){9,16}$")]*/
        
        //public byte[] Image { get; set; }
        //public List<int> Roles { get; set; } = new List<int>();
    }
}

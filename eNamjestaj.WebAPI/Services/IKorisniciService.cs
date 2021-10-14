using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IKorisniciService : ICRUDService<Model.Korisnik, object, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        
        //List<Korisnik> Get();
        //Model.Korisnik GetById(int id);
        //Model.Korisnik Insert(KorisnikInsertRequest request);

       //Task<Model.Korisnik>  Update(int id, KorisnikUpdateRequest request);
        //Model.Korisnik Authenticiraj(string username, string pass);
        Task<Model.Korisnik> Authenticiraj(KorisnikAutentikacijaRequest request);

        Task<Model.Korisnik> SignUp(KorisnikInsertRequest request);

    }
}

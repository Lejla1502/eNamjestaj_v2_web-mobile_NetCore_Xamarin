using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IKupacService : ICRUDService<Model.Kupac, object, KupacInsertRequest, KupacUpdateRequest>
    {
        List<Model.Kupac> Get();
        Model.Kupac GetByKorisnikId(int id);
        Task<Model.Kupac> SignUpKupac(KupacInsertRequest request);
        //Model.Kupac Update(int id, KupacInsertRequest request);
    }
}

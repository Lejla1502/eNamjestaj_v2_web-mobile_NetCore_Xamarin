using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IProizvodSkladisteService : IService<Model.ProizvodSkladiste, object>
    {
        //IList<ProizvodSkladiste> Get(ProizvodSkladisteSearchRequest search
        //
        int GetSkladisteKolicinaByProizvodId(int id);

    }
}

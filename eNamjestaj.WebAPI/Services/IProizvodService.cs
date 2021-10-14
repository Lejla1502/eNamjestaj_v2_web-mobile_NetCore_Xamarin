using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IProizvodService:ICRUDService<Model.Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest>
    {
        //IList<Proizvod> Get();
        Task<IEnumerable<ProizvodKatalogDisplayRequest>> GetProizvodiKatalog(ProizvodSearchRequest search);
        ProizvodKatalogDisplayRequest GetProizvodKatalogByProizvodId(int id);

        List<Model.Proizvod> Recommend(int kupacId, int proizvodId);

        Task<bool> CheckIfProductInCatalogue(int id);

    }
}

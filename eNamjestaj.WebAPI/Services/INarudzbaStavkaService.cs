using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface INarudzbaStavkaService : ICRUDService<Model.NarudzbaStavka, NarudzbaStavkaSearchRequest, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpdateRequest>
    {
        int GetStavkaIdByNarudzbaIProizvod(int narudzbaId, int proizvodId, int bojaId);
        List<NarudzbaStavka> GetStavkeByNarudzbaId(int narudzbaId);

        
    }
}

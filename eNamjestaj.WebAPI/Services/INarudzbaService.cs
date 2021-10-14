using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface INarudzbaService: ICRUDService<Model.Narudzba, object, NarudzbaInsertRequest, NarudzbaUpsertRequest>
    {
        // IList<Narudzba> Get();
        Task<Model.Narudzba> GetLast();
        Model.Narudzba GetAktivnaNarudzbaByKupacId(int id);
        Task<IEnumerable<NarudzbaProizvodDisplayRequest>> GetNarudzbaProizvodByNarudzbaId(int id);
        Task Zakljuci(int id, Model.Narudzba n);

        //Task DeleteOrderIfNoItemsLeft(int id);
        List<NarudzbaHistorijaDisplayRequest> GetHistorijaNArudzbiByKupacId(int id);
    }
}

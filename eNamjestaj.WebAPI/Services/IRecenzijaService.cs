using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IRecenzijaService : ICRUDService<Model.Recenzija, object, RecenzijaInsertRequest, Model.Recenzija>
    {
        Task<IEnumerable<RecenzijaDisplayRequest>> GetRecenzijaByProizvodId(int id);
        Task<Model.Recenzija> InsertRecenziju(RecenzijaInsertRequest req);
    }
}

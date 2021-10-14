using AutoMapper;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class RecenzijaService : BaseCRUDService<Model.Recenzija, object, Database.Recenzija, RecenzijaInsertRequest, Model.Recenzija>, IRecenzijaService
    {
        public RecenzijaService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<IEnumerable<RecenzijaDisplayRequest>> GetRecenzijaByProizvodId(int id)
        {
            var list = _context.Set<Recenzija>().Include(rec=>rec.Kupac).Where(r=>r.ProizvodId == id).ToList();

            var trazeneStavke = new List<RecenzijaDisplayRequest>();
            foreach (var r in list)
            {
                var recStavka = new RecenzijaDisplayRequest
                {
                    Kupac=r.Kupac.Ime+" "+r.Kupac.Prezime,
                    Datum=r.Datum,
                    Ocjena=Convert.ToInt32(r.Ocjena),
                    Sadrzaj=r.Sadrzaj
                };

                trazeneStavke.Add(recStavka);
            }

            return await Task.FromResult(trazeneStavke);

        }

        public  async Task<Model.Recenzija> InsertRecenziju(RecenzijaInsertRequest request)
        {
            if (_context.Set<Recenzija>().Where(x => x.KupacId == request.KupacId && x.ProizvodId == request.ProizvodId).Count() > 0)
                return null;

            else
            {
                var entity = _mapper.Map<Database.Recenzija>(request);

                await _context.Recenzija.AddAsync(entity);

                await _context.SaveChangesAsync();

                return _mapper.Map<Model.Recenzija>(entity);
            }
        }

    }
}
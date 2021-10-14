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
    public class NarudzbaStavkaService : BaseCRUDService<Model.NarudzbaStavka, NarudzbaStavkaSearchRequest, Database.NarudzbaStavka, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpdateRequest>, INarudzbaStavkaService
    {
        public NarudzbaStavkaService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public override async Task<Model.NarudzbaStavka> Update(int id, NarudzbaStavkaUpdateRequest request)
        {
            var entity = _context.NarudzbaStavka.Find(id);

            entity.Kolicina = request.Kolicina;


            //_mapper.Map(request, entity);

            await _context.SaveChangesAsync();


            return _mapper.Map<Model.NarudzbaStavka>(entity);
        }

        /*public  async Task Delete(int id)
        {
            var entity = _context.Set<NarudzbaStavka>().Find(id);

            _context.Set<NarudzbaStavka>().Remove(entity);



            var entityOrder = _context.Set<Narudzba>().Find(entity.Narudzba.Id);
            if(entityOrder.NarudzbaStavka.Count()<1)
                _context.Set<Narudzba>().Remove(entityOrder);

            await _context.SaveChangesAsync();
        }*/


        public int GetStavkaIdByNarudzbaIProizvod(int narudzbaId, int proizvodId, int bojaId)
        {
            int stavkaId = 0;
            foreach (var item in _context.Set<NarudzbaStavka>().Where(n => n.NarudzbaId == narudzbaId).ToList())
            {
                if (item.ProizvodId == proizvodId && item.BojaId==bojaId)
                    stavkaId = item.Id;
            }

            return stavkaId;



        }

        public List<Model.NarudzbaStavka> GetStavkeByNarudzbaId(int narudzbaId)
        {
            var list = _context.Set<NarudzbaStavka>().Where(n=>n.NarudzbaId==narudzbaId).ToList();

            return _mapper.Map<List<Model.NarudzbaStavka>>(list);
            


        }
    }
}

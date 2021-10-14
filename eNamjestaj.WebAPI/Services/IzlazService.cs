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
    public class IzlazService : BaseCRUDService<Model.Izlaz, object, Database.Izlaz, IzlazInsertRequest, Model.Izlaz>, IIzlazService
    {
        public IzlazService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {

        }
        public Model.Izlaz GetLast()
        {
            var izl = _context.Set<Izlaz>().Last();

            return _mapper.Map<Model.Izlaz>(izl);


        }

        public override async Task<Model.Izlaz> Insert(IzlazInsertRequest request)
        {

            
            // request.KorisnikId = _context.Korisnik.Last().Id;

            var entity = _mapper.Map<Database.Izlaz>(request);


            await _context.Izlaz.AddAsync(entity);

            await _context.SaveChangesAsync();



            foreach (var item in _context.NarudzbaStavka.Include(n=>n.Proizvod).Include(n=>n.Proizvod.ProizvodSkladiste).Where(n => n.NarudzbaId == request.NarudzbaId).ToList())
            {
                var izlazStavka = new IzlaziStavka
                {
                    IzlazId=entity.IzlazId,
                    ProizvodId=item.ProizvodId,
                    Cijena=item.CijenaProizvoda,
                    Popust=item.PopustNaCijenu,
                    Kolicina=item.Kolicina,
                    Konacnacijena=item.TotalStavke,
                    SkladisteId=item.Proizvod.ProizvodSkladiste.SkladisteId
                };

                var entityItem = _mapper.Map<Database.IzlaziStavka>(izlazStavka);


                await _context.IzlaziStavka.AddAsync(entityItem);

                await _context.SaveChangesAsync();
            }

            return _mapper.Map<Model.Izlaz>(entity);
        }

    }
}

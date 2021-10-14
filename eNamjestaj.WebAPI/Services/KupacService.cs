using AutoMapper;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
using eNamjestaj.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class KupacService : BaseCRUDService<Model.Kupac, object, Database.Kupac, KupacInsertRequest, KupacUpdateRequest>, IKupacService
    {
        private readonly eNamjestaj_v2Context _context;
        private readonly IMapper _mapper;
        public KupacService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Kupac> Get()
        {
            var list = _context.Set<Kupac>().ToList();

            return _mapper.Map<List<Model.Kupac>>(list);

        }

        public Model.Kupac GetByKorisnikId(int id)
        {
            var kupac = _context.Set<Kupac>().Where(x=>x.KorisnikId==id).First();

            return _mapper.Map<Model.Kupac>(kupac);

        }
        public override async Task<Model.Kupac> Insert(KupacInsertRequest request)
        {

            if (!await IsEmailUnique(request.Email))
            {
                throw new UserException("Email vec postoji");
            }

           // request.KorisnikId = _context.Korisnik.Last().Id;
            
            var entity = _mapper.Map<Database.Kupac>(request);


            await _context.Kupac.AddAsync(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<Model.Kupac>(entity);
        }

        public async Task<bool> IsEmailUnique(string Email)
        {
            return !await _context.Kupac.AnyAsync(i => i.Email == Email);
        }
        public async Task<Model.Kupac> SignUpKupac(KupacInsertRequest request)
        {
            
            var entity = _mapper.Map<Database.Kupac>(request);

            await _context.Kupac.AddAsync(entity);
            await _context.SaveChangesAsync();

            

            return _mapper.Map<Model.Kupac>(entity);
        }

        public override async Task<Model.Kupac> Update(int id, KupacUpdateRequest request)
        {
            var entity = _context.Kupac.Find(id);



            if (!await IsEmailUniqueUpdate(request.Email, id))
            {
                throw new UserException("Email vec postoji");
            }

            _context.Kupac.Attach(entity);
            _context.Kupac.Update(entity);

            
            _mapper.Map(request, entity);

            await _context.SaveChangesAsync();


            return _mapper.Map<Model.Kupac>(entity);
        }

        public async Task<bool> IsEmailUniqueUpdate(string Email, int id)
        {
            bool exists = true;
            List<Database.Kupac> korisnici = _context.Kupac.ToList();
            foreach (Database.Kupac k in korisnici)
            {
                if (k.Id != id)
                {
                    if (k.Email == Email)
                        exists = false;
                }

            }
            return exists;

        }

    }
}

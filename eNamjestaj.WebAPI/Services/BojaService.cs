using AutoMapper;
using eNamjestaj.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class BojaService:BaseService<Model.Boja,object,Database.Boja>, IBojaService
    {
        private readonly eNamjestaj_v2Context _context;
        private readonly IMapper _mapper;
        public BojaService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Boja> GetBojeByProizvodId(int id)
        {
            var boja = _context.Set<Boja>().Join(_context.Set<ProizvodBoja>(),
                p => p.Id,
                pb => pb.BojaId,
                (x, y) => new { Boja = x, ProizvodBoja = y }).Where(x => x.ProizvodBoja.ProizvodId == id)
                .Select(s => s.Boja).ToList();
                
                
           return _mapper.Map<List<Model.Boja>>(boja);
            


        }
    }
}

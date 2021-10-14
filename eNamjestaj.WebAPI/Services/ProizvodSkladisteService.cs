using AutoMapper;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class ProizvodSkladisteService : BaseService<Model.ProizvodSkladiste, object, Database.ProizvodSkladiste>, IProizvodSkladisteService
    {
        private readonly eNamjestaj_v2Context _context;
        private readonly IMapper _mapper;
        public ProizvodSkladisteService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public int GetSkladisteKolicinaByProizvodId(int id)
        {
            var kol = _context.Set<ProizvodSkladiste>().Where(n => n.ProizvodId == id).FirstOrDefault().Kolicina;

            return kol;



        }


    }
}

using AutoMapper;
using eNamjestaj.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class OpstinaService : IOpstinaService
    {
        private readonly eNamjestaj_v2Context _context;
        private readonly IMapper _mapper;
        public OpstinaService(eNamjestaj_v2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Opstina> Get()
        {
            var list = _context.Opstina.ToList();
            return _mapper.Map<List<Model.Opstina>>(list);
        }

        public Model.Opstina GetByID(int id)
        {
            var entity = _context.Opstina.Find(id);
            return _mapper.Map<Model.Opstina>(entity);
        }
    }
}

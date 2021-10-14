using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NarudzbaStavkaController : BaseCRUDController<Model.NarudzbaStavka, NarudzbaStavkaSearchRequest, NarudzbaStavkaUpsertRequest, NarudzbaStavkaUpdateRequest>
    {
        private readonly INarudzbaStavkaService _service;

        public NarudzbaStavkaController(INarudzbaStavkaService service) : base(service)
        {
            _service = service;
        }
        [HttpGet("GetStavkaIdByNarudzbaIProizvod/{narudzbaId}/{proizvodId}/{bojaId}")]
        public int GetStavkaIdByNarudzbaIProizvod(int narudzbaId,int proizvodId, int bojaId)
        {
            return _service.GetStavkaIdByNarudzbaIProizvod(narudzbaId,proizvodId, bojaId);
        }


        [HttpGet("GetStavkeByNarudzbaId/{narudzbaId}")]
        public List<Model.NarudzbaStavka> GetStavkeByNarudzbaId(int narudzbaId)
        {
            return _service.GetStavkeByNarudzbaId(narudzbaId);
        }

        
    }
}

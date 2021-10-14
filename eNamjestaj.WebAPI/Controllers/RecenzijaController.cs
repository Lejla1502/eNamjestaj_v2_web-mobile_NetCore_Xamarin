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
    public class RecenzijaController : BaseCRUDController<Model.Recenzija, object, RecenzijaInsertRequest, Model.Recenzija>
    {
        private readonly IRecenzijaService _service;

        public RecenzijaController(IRecenzijaService service) : base(service)
        {
            _service = service;
        }


        [HttpGet("GetRecenzijaByProizvodId/{id}")]
        public Task<IEnumerable<RecenzijaDisplayRequest>> GetRecenzijaByProizvodId(int id)
        {
            return _service.GetRecenzijaByProizvodId(id);
        }

        [HttpPost("InsertRecenziju")]
        public async Task<Model.Recenzija> InsertRecenziju(RecenzijaInsertRequest req)
        {
            return await _service.InsertRecenziju(req);
        }
    }
}

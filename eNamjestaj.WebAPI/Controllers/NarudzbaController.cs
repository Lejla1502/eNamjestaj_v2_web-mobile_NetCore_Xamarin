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
    public class NarudzbaController : BaseCRUDController<Model.Narudzba, object, NarudzbaInsertRequest, NarudzbaUpsertRequest>
    {
        private readonly INarudzbaService _service;

        public NarudzbaController(INarudzbaService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetLast")]

        public async Task<Model.Narudzba> GetLast()
        {
            return await _service.GetLast();
        }

        [HttpGet("GetAktivnaNarudzbaByKupacId/{id}")]
        public Model.Narudzba GetAktivnaNarudzbaByKupacId(int id)
        {
            return _service.GetAktivnaNarudzbaByKupacId(id);
        }

        [HttpGet("GetNarudzbaProizvodByNarudzbaId/{id}")]
        public Task<IEnumerable<NarudzbaProizvodDisplayRequest>> GetNarudzbaProizvodByNarudzbaId(int id)
        {
            return _service.GetNarudzbaProizvodByNarudzbaId(id);
        }

        [HttpGet("GetHistorijaNArudzbiByKupacId/{id}")]
        public List<NarudzbaHistorijaDisplayRequest> GetHistorijaNArudzbiByKupacId(int id)
        {
            return _service.GetHistorijaNArudzbiByKupacId(id);
        }

        [HttpPut("Zakljuci/{id}")]
        public async Task Zakljuci(int id, Model.Narudzba n)
        {
             await _service.Zakljuci(id,n);
        }

       /* [HttpDelete("DeleteOrderIfNoItemsLeft/{id}")]
        public async Task DeleteOrderIfNoItemsLeft(int id)
        {
            await _service.DeleteOrderIfNoItemsLeft(id);
        }*/

    }
}

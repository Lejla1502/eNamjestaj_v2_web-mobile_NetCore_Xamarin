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

    public class ProizvodController : BaseCRUDController<Model.Proizvod, ProizvodSearchRequest, ProizvodUpsertRequest, ProizvodUpsertRequest>
    {
        private readonly IProizvodService _service;

        public ProizvodController(IProizvodService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetProizvodiKatalog")]
        public Task<IEnumerable<ProizvodKatalogDisplayRequest>> GetProizvodiKatalog([FromQuery] ProizvodSearchRequest search)
        {
            return _service.GetProizvodiKatalog(search);
        }

        [HttpGet("GetProizvodKatalogByProizvodId/{id}")]
        public ProizvodKatalogDisplayRequest GetProizvodKatalogByProizvodId(int id)
        {
            return _service.GetProizvodKatalogByProizvodId(id);
        }

        [HttpGet("Recommend/{kupacId}/{proizvodId}")]
        public List<Model.Proizvod> Recommend(int kupacId, int proizvodId)
        {
            return _service.Recommend(kupacId, proizvodId);
        }

        [HttpGet("CheckIfProductInCatalogue/{id}")]
        public Task<bool> CheckIfProductInCatalogue(int id)
        {
            return _service.CheckIfProductInCatalogue(id);
        }

    }
}

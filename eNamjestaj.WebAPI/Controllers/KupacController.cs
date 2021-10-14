using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class KupacController:BaseCRUDController<Model.Kupac, object, KupacInsertRequest, KupacUpdateRequest>
    {
        private readonly IKupacService _service;
        //private readonly IRecommendationService<Model.Track> _recommendationService;

        public KupacController(IKupacService service) : base(service)
        {
            _service = service;
            //_recommendationService = recommendationService;
        }
       
        [HttpGet("GetByKorisnikId/{id}")]
        
        public Model.Kupac GetByKorisnikId(int id)
        {
            return _service.GetByKorisnikId(id);
        }

        /*[HttpPut("{id}")]
        public Model.Kupac Update(int id, [FromBody] KupacUpdateRequest request)
        {
            return _service.Update(id, request);
        }*/

        [AllowAnonymous]
        [HttpPost("SignUpKupac")]
        public async Task<Model.Kupac> SignUpKupac(KupacInsertRequest request)
        {
            return await _service.Insert(request);
        }

    }
}

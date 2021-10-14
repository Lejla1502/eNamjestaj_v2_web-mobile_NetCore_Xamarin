using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : BaseCRUDController<Model.Korisnik, object, KorisnikInsertRequest, KorisnikUpdateRequest>
    {
        private readonly IKorisniciService _service;
        //private readonly IRecommendationService<Model.Track> _recommendationService;

        public KorisniciController(IKorisniciService service) : base(service)
        {
            _service = service;
            //_recommendationService = recommendationService;
        }

       /* [AllowAnonymous]
        [HttpGet]
        public List<Model.Korisnik> Get()
        {
            return _service.Get();
        }
        */
       /* [HttpPut("{id}")]
        public Model.Korisnik Update(int id, [FromBody] KorisnikUpdateRequest request)
        {
            return _service.Update(id, request);
        }*/
        [AllowAnonymous]
        [HttpPost("Auth")]
        public async Task<Model.Korisnik> Authenticiraj(KorisnikAutentikacijaRequest request)
        {
            return await _service.Authenticiraj(request);
        }

        [AllowAnonymous]
        [HttpPost("SignUp")]
        public async Task<Model.Korisnik> SignUp(KorisnikInsertRequest request)
        {
            return await _service.Insert(request);
        }


    }
}

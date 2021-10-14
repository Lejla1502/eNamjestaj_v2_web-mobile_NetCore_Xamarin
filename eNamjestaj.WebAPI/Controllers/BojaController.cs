using eNamjestaj.Model;
using eNamjestaj.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Controllers
{
    
    public class BojaController : BaseController<Model.Boja, object>
    {
        private readonly IBojaService _service;
        //private readonly IRecommendationService<Model.Track> _recommendationService;

        public BojaController(IBojaService service) : base(service)
        {
            _service = service;
            //_recommendationService = recommendationService;
        }

        [HttpGet("GetBojeByProizvodId/{id}")]

        public List<Model.Boja> GetBojeByProizvodId(int id)
        {
            return _service.GetBojeByProizvodId(id);
        }
        
    }
}

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
    
    public class ProizvodSkladisteController : BaseController<Model.ProizvodSkladiste, object>
    {
        private readonly IProizvodSkladisteService _service;
        //private readonly IRecommendationService<Model.Track> _recommendationService;

        public ProizvodSkladisteController(IProizvodSkladisteService service) : base(service)
        {
            _service = service;
            //_recommendationService = recommendationService;
        }

        
        [HttpGet("GetSkladisteKolicinaByProizvodId/{id}")]

        public int GetSkladisteKolicinaByProizvodId(int id)
        {
            return _service.GetSkladisteKolicinaByProizvodId(id);
        }
    }
}

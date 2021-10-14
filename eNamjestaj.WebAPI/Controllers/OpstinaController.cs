using eNamjestaj.Model;
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
    public class OpstinaController :ControllerBase
    {
        private readonly IOpstinaService _service;
        
        public OpstinaController(IOpstinaService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        public List<Opstina> Get()
        {
            return _service.Get();
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public Model.Opstina GetByID(int id)
        {
            return _service.GetByID(id);
        }

    }
}

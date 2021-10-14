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
    
    public class IzlazController : BaseCRUDController<Model.Izlaz, object, IzlazInsertRequest, Model.Izlaz>
    {
        private readonly IIzlazService _service;

        public IzlazController(IIzlazService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("GetLast")]

        public Model.Izlaz GetLast()
        {
            return _service.GetLast();
        }
    }
}

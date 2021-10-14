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
    [Route("api/[controller]")]
    [ApiController]
    public class UlogaController : BaseController<Model.Uloga, object>
    {
        public UlogaController(IService<Uloga, object> service) : base(service)
        {

        }

    }
}
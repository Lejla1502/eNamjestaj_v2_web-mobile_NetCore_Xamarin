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

    public class OpisProizvodaController : BaseController<Model.OpisProizvoda, object>
    {
        public OpisProizvodaController(IService<OpisProizvoda, object> service) : base(service)
        {
        }

    }
}

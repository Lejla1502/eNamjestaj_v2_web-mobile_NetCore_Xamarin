using eNamjestaj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IOpstinaService
    {
        List<Opstina> Get();
        Opstina GetByID(int id);
    }
}

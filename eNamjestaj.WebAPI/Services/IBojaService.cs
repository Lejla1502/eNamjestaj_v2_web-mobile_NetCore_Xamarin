using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IBojaService:IService<Model.Boja,object>
    {
        List<Model.Boja> GetBojeByProizvodId(int id);
    }
}

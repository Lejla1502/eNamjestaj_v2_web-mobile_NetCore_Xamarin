using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface IIzlazService: ICRUDService<Model.Izlaz, object, IzlazInsertRequest, Model.Izlaz>
    {
        Model.Izlaz GetLast();
    }

}

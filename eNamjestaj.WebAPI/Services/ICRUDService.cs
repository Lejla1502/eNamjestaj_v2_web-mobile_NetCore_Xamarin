using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IService<T,TSearch>
    {
        Task<T> Insert (TInsert request);
        Task<T> Update (int id, TUpdate request);

        Task Delete(int id);
    }
}

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
    public class BaseCRUDController<T,TSearch, TInsert, TUpdate> : BaseController<T,TSearch>
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> _service;

        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
           _service = service;
        }

        [HttpPost]
        public async Task<T> Insert(TInsert request)
        {
            return await _service.Insert(request);
        }

        [HttpPut("{id}")]
        public async Task<T> Update(int id,[FromBody] TUpdate request)
        {
            return await _service.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}

using AutoMapper;
using eNamjestaj.Model.Requests;
using eNamjestaj.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class NarudzbaService : BaseCRUDService<Model.Narudzba, object, Database.Narudzba, NarudzbaInsertRequest, NarudzbaUpsertRequest>,INarudzbaService
    {
        public NarudzbaService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<Model.Narudzba> GetLast()
        {
             var nar = _context.Set<Narudzba>().Last();

             return await Task.FromResult(_mapper.Map<Model.Narudzba>(nar));
            

        }

        public Model.Narudzba GetAktivnaNarudzbaByKupacId(int id)
        {
             var nar = _context.Set<Narudzba>().Where(n=>n.KupacId==id && n.Aktivna==true).FirstOrDefault();
           
            return _mapper.Map<Model.Narudzba>(nar);
           
        }

        public List<NarudzbaHistorijaDisplayRequest> GetHistorijaNArudzbiByKupacId(int id)
        {
            var nar =_context.Set<Narudzba>().Include(i=>i.Izlaz).Where(n => n.KupacId == id && n.Aktivna == false).ToList();

            string status = "";
            decimal PDV = 17 / 100;
            List<NarudzbaHistorijaDisplayRequest> lista = new List<NarudzbaHistorijaDisplayRequest>();
            foreach (var n in nar)
            {
                if (n.Odbijena)
                    status = "Odbijena";
                if (n.Otkazano)
                    status = "Otkazana";
                if (n.NaCekanju)
                    status = "Na cekanju";
                if (_context.Izlaz.Where(i => i.NarudzbaId == n.Id).Count() > 0)
                {
                    if(n.Izlaz.Zakljucena)
                        status = "Kompletirana";
                }

                lista.Add(new NarudzbaHistorijaDisplayRequest { 
                    Id=n.Id,
                    Naziv=n.BrojNarudzbe,
                    Status=status,
                    Datum=n.Datum,
                    Total=n.Total+(n.Total*PDV ),
                    BrStavki=_context.NarudzbaStavka.Where(ns=>ns.NarudzbaId==n.Id).Count()
                });
            }

            return lista;

        }

        public async Task<IEnumerable<NarudzbaProizvodDisplayRequest>> GetNarudzbaProizvodByNarudzbaId(int id)
        {
            var nar = _context.Set<NarudzbaStavka>().Include(n=>n.Proizvod).Include(n=>n.Boja).Where(n => n.NarudzbaId == id);

            var trazeneStavke = new List<NarudzbaProizvodDisplayRequest>();


            foreach (var item in nar)
            {
                trazeneStavke.Add(new NarudzbaProizvodDisplayRequest { 
                    NazivProizvoda=item.Proizvod.Naziv,
                    Cijena=item.CijenaProizvoda,
                    Kolicina=item.Kolicina,
                    Slika=item.Proizvod.Slika,
                    TotalStavka=item.TotalStavke,
                    Boja=item.Boja.Naziv,
                    NarudzbaStavkaId=item.Id
                    
                });
            }

            return await Task.FromResult( trazeneStavke);
        }


        public async override Task Delete(int id)
        {
            var entity = _context.Set<Narudzba>().Find(id);

            if (_context.Set<NarudzbaStavka>().Where(ns => ns.NarudzbaId == id).Count() < 1)
            {
                _context.Set<Narudzba>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Zakljuci(int id, Model.Narudzba n)
        {
            _context.Narudzba.Find(id).Aktivna = false;
            _context.Narudzba.Find(id).NaCekanju = true;
            _context.Narudzba.Find(id).Odbijena = false;
            _context.Narudzba.Find(id).Otkazano = false;

            decimal sum = 0;

            foreach (var item in _context.NarudzbaStavka.Where(ns => ns.NarudzbaId == id).ToList())
            {
                sum += item.TotalStavke;
            }

            _context.Narudzba.Find(id).Total = sum;

            await _context.SaveChangesAsync();

        }
    }
}

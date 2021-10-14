using AutoMapper;
using eNamjestaj.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<Database.Korisnik, KorisnikInsertRequest>().ReverseMap();
            CreateMap<Database.Korisnik, KorisnikUpdateRequest>().ReverseMap();

            CreateMap<Database.Kupac, Model.Kupac>();
            CreateMap<Database.Kupac, KupacInsertRequest>().ReverseMap();
            CreateMap<Database.Kupac, KupacUpdateRequest>().ReverseMap();

            CreateMap<Database.Opstina, Model.Opstina>();

            CreateMap<Database.ProizvodSkladiste, Model.ProizvodSkladiste>();

            CreateMap<Database.Boja, Model.Boja>();

            CreateMap<Database.Proizvod, Model.Proizvod>().ReverseMap();
            CreateMap<Database.Proizvod, ProizvodUpsertRequest>().ReverseMap();

            CreateMap<Database.Narudzba, Model.Narudzba>().ReverseMap();
            CreateMap<Database.Narudzba, NarudzbaInsertRequest>().ReverseMap();
            CreateMap<Database.Narudzba, NarudzbaUpsertRequest>().ReverseMap();


            CreateMap<Database.NarudzbaStavka, Model.NarudzbaStavka>();
            CreateMap<Database.NarudzbaStavka, NarudzbaStavkaUpsertRequest>().ReverseMap();
            CreateMap<Database.Narudzba, NarudzbaStavkaUpdateRequest>().ReverseMap();

            CreateMap<Database.Izlaz, Model.Izlaz>();
            CreateMap<Database.Izlaz, IzlazInsertRequest>().ReverseMap();

            CreateMap<Database.IzlaziStavka, Model.IzlaziStavka>();

            CreateMap<Database.Recenzija, Model.Recenzija>();
            CreateMap<Database.Recenzija, RecenzijaInsertRequest>().ReverseMap();

        }
    }
}

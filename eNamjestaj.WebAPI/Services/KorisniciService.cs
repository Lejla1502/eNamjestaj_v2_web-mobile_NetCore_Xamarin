using AutoMapper;
using eNamjestaj.Model;
using eNamjestaj.Model.Requests;
using eNamjestaj.Mobile.Helpers;
using eNamjestaj.WebAPI.Controllers;
using eNamjestaj.WebAPI.Database;
using eNamjestaj.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eNamjestaj.WebAPI.Services
{
    public class KorisniciService : BaseCRUDService<Model.Korisnik, object, Database.Korisnik, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisniciService//IKorisniciService
    {
        private readonly eNamjestaj_v2Context _context;
        private readonly IMapper _mapper;
        public KorisniciService(eNamjestaj_v2Context context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       /* public List<Model.Korisnik> Get()
        {
            var list = _context.Set<Database.Korisnik>().ToList();

            return _mapper.Map<List<Model.Korisnik>>(list);

        }*/
        public async Task<Model.Korisnik> Authenticiraj(KorisnikAutentikacijaRequest request)
        {
            var user = _context.Korisnik.Include(x=>x.Uloga).FirstOrDefault(x => x.KorisnickoIme == request.Username);

            if (user != null)
            {
                var hashedPass = GenerateHash(user.LozinkaSalt, request.Password);

                if (hashedPass == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Korisnik>(user);
                }
            }

                    return null;
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

     

        
        public override async Task<Model.Korisnik> Insert(KorisnikInsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Lozinke se ne podudaraju!");
            }


            if (!await IsUsernameUnique(request.KorisnickoIme))
            {
                throw new UserException("Korisnicko ime vec postoji");
            }

            var entity = _mapper.Map<Database.Korisnik>(request);



            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            await _context.Korisnik.AddAsync(entity);

            await _context.SaveChangesAsync();

            
            return _mapper.Map<Model.Korisnik>(entity);
        }

        public override async Task<Model.Korisnik> Update(int id,KorisnikUpdateRequest request)
        {
            var entity = _context.Korisnik.Find(id);
            


            if (!await IsUsernameUniqueUpdate(request.KorisnickoIme,id))
            {
                throw new UserException("Korisnicko ime vec postoji");
            }

            _context.Korisnik.Attach(entity);
            _context.Korisnik.Update(entity);

            
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _mapper.Map(request, entity);

           await _context.SaveChangesAsync();


            return _mapper.Map<Model.Korisnik>(entity);
        }

        public async Task<Model.Korisnik> SignUp(KorisnikInsertRequest request)
        {
            if (request.Password != request.PasswordConfirmation)
            {
                throw new Exception("Passwords do not match!");
            }

            var entity = _mapper.Map<Database.Korisnik>(request);
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            await _context.Korisnik.AddAsync(entity);
            await _context.SaveChangesAsync();

            //await _context.UserRoles.AddAsync(userRole);
            //await _context.SaveChangesAsync();

            return _mapper.Map<Model.Korisnik>(entity);
        }

        public async Task<bool> IsEmailUnique(string Email)
        {
            return !await _context.Kupac.AnyAsync(i => i.Email == Email);
        }

        public  bool IsEmailUniqueNotAsync(string Email)
        {
            return  _context.Kupac.Any(i => i.Email == Email);
        }

        public async Task<bool> IsUsernameUnique(string Username)
        {
            return !await _context.Korisnik.AnyAsync(i => i.KorisnickoIme == Username);
        }

        public async Task<bool> IsUsernameUniqueUpdate(string Username, int id)
        {
            bool exists = true;
            List<Database.Korisnik> korisnici = _context.Korisnik.ToList();
            foreach (Database.Korisnik k in korisnici)
            {
                if (k.Id !=id)
                {
                    if (k.KorisnickoIme == Username)
                        exists= false;
                }

            }
            return exists;
            
        }
    }
}

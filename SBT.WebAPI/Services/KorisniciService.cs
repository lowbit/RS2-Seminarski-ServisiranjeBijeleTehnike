using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SBT.Model;
using SBT.Model.Requests;
using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public KorisniciService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.KorisniciModel Authenticiraj(string username, string pass)
        {
            var user = _context.Korisnici.Include("KorisniciUloge.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.KorisniciModel>(user);
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


        public List<Model.KorisniciModel> Get(KorisniciSearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if (request?.IsUlogeLoadingEnabled == true)
            {
                query = query.Include(x => x.KorisniciUloge);
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.KorisniciModel>>(list);
        }

        public Model.KorisniciModel GetById(int id)
        {
            var entity = _context.Korisnici.Include("KorisniciUloge.Uloga").Where(x => x.KorisnikId == id).FirstOrDefault();

            return _mapper.Map<Model.KorisniciModel>(entity);
        }

        public Model.KorisniciModel Insert(KorisniciInsertRequest request)
        {
            var entity = _mapper.Map<Korisnici>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            var uloge = request.Uloge;
            if(uloge == null || uloge.Count < 1)
            {
                uloge.Add(_context.Uloge.Where(x => x.Naziv == "korisnik").FirstOrDefault().UlogaId);
            }
            foreach (var uloga in uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                korisniciUloge.KorisnikId = entity.KorisnikId;
                korisniciUloge.UlogaId = uloga;
                korisniciUloge.DatumIzmjene = DateTime.Now;
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();

            return _mapper.Map<Model.KorisniciModel>(entity);
        }

        public Model.KorisniciModel Update(int id, KorisniciInsertRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.KorisniciModel>(entity);
        }
        public List<Model.KorisnikModel> GetKorisniciList(Model.Requests.SearchRequest request)
        {
            var query = _context.Korisnici.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(u => u.KorisnickoIme.Contains(request.Naziv));
            }
            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(u => u.Ime.Contains(request.Ime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(u => u.Prezime.Contains(request.Prezime));
            }
            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(u => u.Email.Contains(request.Email));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.KorisnikModel>>(list);
        }
        public List<Model.UlogeModel> GetUlogeList()
        {
            var uloge = _context.Uloge.ToList();
            return _mapper.Map<List<Model.UlogeModel>>(uloge);
        }

        public KorisnikModel AddKorisnik(KorisnikUpdateRequest request)
        {
            var entity = _mapper.Map<Database.Korisnici>(request);
            _context.Korisnici.Add(entity);
            _context.SaveChanges();

            if (request.Uloge.Count>0)
            {
                var role = _context.KorisniciUloge.Where(x => x.KorisnikId == entity.KorisnikId);
                _context.KorisniciUloge.RemoveRange(role);
                foreach (var item in request.Uloge)
                {
                    var korisnikUloga = new KorisniciUloge
                    {
                        KorisnikId = entity.KorisnikId,
                        UlogaId = item,
                        DatumIzmjene = DateTime.Now
                    };
                    _context.KorisniciUloge.Add(korisnikUloga);
                }
                _context.SaveChanges();
            }
            return _mapper.Map<KorisnikModel>(entity);
        }

        public KorisnikModel EditKorisnik(int id, KorisnikUpdateRequest request)
        {
            var entity = _context.Korisnici.Find(id);
            _context.Korisnici.Attach(entity);
            _context.Korisnici.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();
            if (request.Uloge !=null && request.Uloge.Count > 0)
            {
                var role = _context.KorisniciUloge.Where(x => x.KorisnikId == entity.KorisnikId);
                _context.KorisniciUloge.RemoveRange(role);
                foreach (var item in request.Uloge)
                {
                    var korisnikUloga = new KorisniciUloge
                    {
                        KorisnikId = entity.KorisnikId,
                        UlogaId = item,
                        DatumIzmjene = DateTime.Now
                    };
                    _context.KorisniciUloge.Add(korisnikUloga);
                }
            }
            _context.SaveChanges();
            return _mapper.Map<KorisnikModel>(entity);
        }

        public List<KorisniciModel> GetServiseriList()
        {
            var ko = _context.KorisniciUloge.Include(k=>k.Korisnik).Where(ko => ko.Uloga.Naziv == "serviser").ToList();
            List<KorisniciModel> km = new List<KorisniciModel>();
            foreach (var item in ko)
            {
                km.Add(_mapper.Map<Model.KorisniciModel>(item.Korisnik));
            }
            return km;
        }
    }
}

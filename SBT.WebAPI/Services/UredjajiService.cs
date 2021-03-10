using AutoMapper;
using SBT.Model;
using SBT.WebAPI.Database;
using SBT.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public class UredjajiService : IUredjajiService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UredjajiService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public UredjajModel GetUredjajById(int uredjajId)
        {
            var entity = _context.Uredjaji.Find(uredjajId);
            var returnObj = _mapper.Map<Model.UredjajModel>(entity);
            var slikaUredjaja = _context.SlikeUredjaja.Where(x => x.UredjajId == entity.UredjajId).OrderBy(x => x.SlikaUredjajaId).FirstOrDefault();
            if (slikaUredjaja != null)
            {
                returnObj.Slika = slikaUredjaja.Slika;
            }
            return returnObj;
        }
        public List<Model.UredjajModel> GetUredjajiList(Model.Requests.SearchRequest request)
        {
            var query = _context.Uredjaji.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.Naziv))
            {
                query = query.Where(u => u.Naziv.Contains(request.Naziv));
            }
            if (!string.IsNullOrWhiteSpace(request?.KategorijaId))
            {
                query = query.Where(u => u.KategorijaId.Equals(int.Parse(request.KategorijaId)));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.UredjajModel>>(list);
        }

        public List<KategorijaModel> GetKategorijeList()
        {
            var list = _context.Kategorije.ToList().OrderBy(k=>k.Naziv);
            return _mapper.Map<List<Model.KategorijaModel>>(list);
        }

        public List<ProizvodjacModel> GetProizvodjaciList()
        {
            var list = _context.Proizvodjaci.OrderBy(x => x.ProizvodjacId).ToList();
            return _mapper.Map<List<Model.ProizvodjacModel>>(list);
        }

        public List<UredjajModel> GetUredjajiByKategorijaList(int kategorijaId)
        {
            var list = _context.Uredjaji.Where(x=>x.KategorijaId==kategorijaId).OrderBy(x=>x.KategorijaId).ToList();
            return _mapper.Map<List<Model.UredjajModel>>(list);
        }

        public List<UredjajModel> GetUredjajiByProizvodjaciList(int proizvodjacId)
        {
            var list = _context.Uredjaji.Where(x => x.ProizvodjacId == proizvodjacId).ToList();
            return _mapper.Map<List<Model.UredjajModel>>(list);
        }

        public KategorijaModel AddKategorija(Model.Requests.KategorijaModelRequest request)
        {
            //throw new UserException("Test");
            var entity = _mapper.Map<Database.Kategorije>(request);
            _context.Kategorije.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<KategorijaModel>(entity);
        }

        public ProizvodjacModel AddProizvodjac(Model.Requests.ProizvodjacModelRequest request)
        {
            var entity = _mapper.Map<Database.Proizvodjaci>(request);
            _context.Proizvodjaci.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<ProizvodjacModel>(entity);
        }

        public UredjajModel AddUredjaj(Model.Requests.UredjajModelRequest request)
        {
            var entity = _mapper.Map<Database.Uredjaji>(request);
            _context.Uredjaji.Add(entity);
            _context.SaveChanges();
            //Dodaj sliku za uredjaj
            if (request.Slika != null)
            {
                var pictureForDevice = new SlikeUredjaja();
                pictureForDevice.UredjajId = entity.UredjajId;
                pictureForDevice.Slika = request.Slika;
                _context.SlikeUredjaja.Add(pictureForDevice);
                _context.SaveChanges();
            }
            return _mapper.Map<UredjajModel>(entity);
        }

        public UredjajModel EditUredjaj(int id, Model.Requests.UredjajModelRequest request)
        {
            var entity = _context.Uredjaji.Find(id);
            _context.Uredjaji.Attach(entity);
            _context.Uredjaji.Update(entity);
            _mapper.Map(request, entity);
            _context.SaveChanges();

            //Dodaj sliku za uredjaj
            if (request.Slika != null)
            {
                //Getaj prvu default sliku i updejtaj ili dodaj novu ako nema slike
                SlikeUredjaja pictureEntity = _context.SlikeUredjaja.Where(x=>x.UredjajId == entity.UredjajId).OrderBy(x=>x.SlikaUredjajaId).FirstOrDefault();
                if (pictureEntity != null)
                {
                    pictureEntity.Slika = request.Slika;
                    _context.SlikeUredjaja.Update(pictureEntity);
                }
                else
                {
                    var pictureForDevice = new SlikeUredjaja();
                    pictureForDevice.UredjajId = entity.UredjajId;
                    pictureForDevice.Slika = request.Slika;
                    _context.SlikeUredjaja.Add(pictureForDevice);
                }
                _context.SaveChanges();
            }
            return _mapper.Map<UredjajModel>(entity);
        }
    }
}

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

        public List<Model.UredjajModel> GetUredjajiList()
        {
            var list = _context.Uredjaji.ToList();
            return _mapper.Map<List<Model.UredjajModel>>(list);
        }

        public List<KategorijaModelAdd> GetKategorijeList()
        {
            var list = _context.Kategorije.ToList().OrderBy(k=>k.Naziv);
            return _mapper.Map<List<Model.KategorijaModelAdd>>(list);
        }

        public List<ProizvodjacModel> GetProizvodjaciList()
        {
            var list = _context.Proizvodjaci.ToList().OrderBy(u=>u.Naziv);
            return _mapper.Map<List<Model.ProizvodjacModel>>(list);
        }

        public List<UredjajModel> GetUredjajiByKategorijeList(int kategorijaId)
        {
            var list = _context.Uredjaji.Where(x=>x.Kategorije.Any(k=>k.KategorijaId==kategorijaId)).ToList();
            return _mapper.Map<List<Model.UredjajModel>>(list);
        }

        public List<UredjajModel> GetUredjajiByProizvodjaciList(int proizvodjacId)
        {
            var list = _context.Uredjaji.Where(x => x.ProizvodjacId == proizvodjacId).ToList();
            return _mapper.Map<List<Model.UredjajModel>>(list);
        }

        public KategorijaModelAdd AddKategorija(Model.Requests.KategorijaModelRequest request)
        {
            //throw new UserException("Test");
            var entity = _mapper.Map<Database.Kategorije>(request);
            _context.Kategorije.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<KategorijaModelAdd>(entity);
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
            return _mapper.Map<UredjajModel>(entity);
        }

        public UredjajModel EditUredjaj(int uredjajId, Model.Requests.UredjajModelRequest request)
        {
            var entity = _context.Uredjaji.Find(uredjajId);
            _context.Uredjaji.Attach(entity);
            _context.Uredjaji.Update(entity);
            entity = _mapper.Map<Database.Uredjaji>(request);
            _context.SaveChanges();
            return _mapper.Map<UredjajModel>(entity);
        }
    }
}

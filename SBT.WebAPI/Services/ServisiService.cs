using AutoMapper;
using SBT.Model;
using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public class ServisiService : IServisiService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ServisiService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.ServisModel> GetList()
        {
            var list = _context.Servisi.ToList();
            return _mapper.Map<List<Model.ServisModel>>(list);
        }
    }
}

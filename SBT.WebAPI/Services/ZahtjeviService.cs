using AutoMapper;
using SBT.Model;
using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public class ZahtjeviService : IZahtjeviService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ZahtjeviService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ZahtjevModel> GetZahtjeviList()
        {
            var list = _context.Zahtjevi.ToList();
            return _mapper.Map<List<Model.ZahtjevModel>>(list);
        }
    }
}

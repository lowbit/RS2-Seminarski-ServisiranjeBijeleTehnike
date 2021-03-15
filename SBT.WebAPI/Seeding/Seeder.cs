using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class Seeder
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Seeder(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Seed()
        {
        }
    }
}

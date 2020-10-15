using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class UredjajiKategorija
    {
        public int UredjajId { get; set; }
        public Uredjaji Uredjaj { get; set; }
        public int KategorijaId { get; set; }
        public Kategorije Kategorija { get; set; }
    }
}

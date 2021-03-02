using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class Uredjaji
    {
        [Key]
        public int UredjajId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int KategorijaId { get; set; }
        public Kategorije Kategorija { get; set; }
        public int ProizvodjacId { get; set; }
        public Proizvodjaci Proizvodjac { get; set; }
        public List<SlikeUredjaja> SlikeUredjaja { get; set; }

    }
}

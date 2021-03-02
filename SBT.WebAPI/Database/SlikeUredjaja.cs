using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class SlikeUredjaja
    {
        [Key]
        public int SlikaUredjajaId { get; set; }
        public byte[] Slika { get; set; }
        public int UredjajId { get; set; }
        public Uredjaji Uredjaj { get; set; }
    }
}

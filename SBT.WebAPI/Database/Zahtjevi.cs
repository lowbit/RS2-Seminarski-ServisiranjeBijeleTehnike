using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class Zahtjevi
    {
        [Key]
        public int ZahtjevId { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Status { get; set; }
        public int UredjajId { get; set; }
        public Uredjaji Uredjaj { get; set; }
        public int TipPlacanjaId { get; set; }
        public TipPlacanja TipPlacanja { get; set; }
        public int TipDostaveId { get; set; }
        public TipDostave TipDostave { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model
{
    public class ZahtjevModel
    {
        public int ZahtjevId { get; set; }
        public string Napomena { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string Status { get; set; }
    }
}

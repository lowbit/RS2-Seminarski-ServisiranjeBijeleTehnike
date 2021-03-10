using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model
{
    public class StanjeServisaModel
    {
        public int StanjeServisaId { get; set; }
        public string Napomena { get; set; }
        public string TrenutniStatus { get; set; }
        public DateTime Azurirano { get; set; }
    }
}

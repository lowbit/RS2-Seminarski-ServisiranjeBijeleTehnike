using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model.Requests
{
    public class StanjeServisaInsertRequest
    {
        public int ServisId { get; set; }
        public string Napomena { get; set; }
        public string TrenutniStatus { get; set; }
        public double Cijena { get; set; }
        public int Ocijena { get; set; }
        public DateTime Azurirano { get; set; }
    }
}

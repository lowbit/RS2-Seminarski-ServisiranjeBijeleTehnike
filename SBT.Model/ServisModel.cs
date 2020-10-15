using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model
{
    public class ServisModel
    {
        public int ServisId { get; set; }
        public string Opis { get; set; }
        public DateTime DatumServisa { get; set; }
        public double Cijena { get; set; }
        public int Ocjena { get; set; }
        public string Status { get; set; }
        public int ZahtjevId { get; set; }
    }
}

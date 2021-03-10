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
        public int OcjenaServisa { get; set; }
        public string Status { get; set; }
        public string UredjajNaziv { get; set; }
        public string ServiserIme { get; set; }
        public string KlijentIme { get; set; }
        public string TipPlacanjaNaziv { get; set; }
        public string TipDostaveNaziv { get; set; }
    }
}

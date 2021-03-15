using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model.Requests
{
    public class ServisInsertRequest
    {
        public string Opis { get; set; }
        public DateTime DatumServisa { get; set; }
        public double Cijena { get; set; }
        public int OcjenaServisa { get; set; }
        public int StatusServisaId { get; set; }
        public int UredjajId { get; set; }
        public int KlijentId { get; set; }
        public int TipPlacanjaId { get; set; }
        public int TipDostaveId { get; set; }
    }
}

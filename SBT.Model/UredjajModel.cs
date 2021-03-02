using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model
{
    public class UredjajModel
    {
        public int UredjajId { get; set; }
        public int KategorijaId { get; set; }
        public int ProizvodjacId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
    }
}

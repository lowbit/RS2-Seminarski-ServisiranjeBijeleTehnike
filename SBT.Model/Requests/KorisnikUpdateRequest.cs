using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public byte[] Slika { get; set; }
        public List<int> Uloge { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model
{
    public class KorisniciUlogeModel
    {
        public int KorisnikUlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public int KorisnikId { get; set; }
        public KorisniciModel Korisnik { get; set; }
        public int UlogaId { get; set; }
        public UlogeModel Uloga { get; set; }
    }
}

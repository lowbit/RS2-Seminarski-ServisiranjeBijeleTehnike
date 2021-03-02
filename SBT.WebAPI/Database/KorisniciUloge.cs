using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public partial class KorisniciUloge
    {
        [Key]
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public Korisnici Korisnik { get; set; }
        public Uloge Uloga { get; set; }
    }
}

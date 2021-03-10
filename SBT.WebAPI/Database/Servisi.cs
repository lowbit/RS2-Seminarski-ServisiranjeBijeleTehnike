using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SBT.WebAPI.Database
{
    public class Servisi
    {
        [Key]
        public int ServisId { get; set; }
        public string Opis { get; set; }
        public DateTime DatumServisa { get; set; }
        public double Cijena { get; set; }
        public int OcjenaServisa { get; set; }
        public int StatusServisaId { get; set; }
        public StatusServisa Status { get; set; }
        public int ServiserId { get; set; }
        public Korisnici Serviser { get; set; }
        public int KlijentId { get; set; }
        public Korisnici Klijent { get; set; }
        public int UredjajId { get; set; }
        public Uredjaji Uredjaj { get; set; }
        public int TipPlacanjaId { get; set; }
        public TipPlacanja TipPlacanja { get; set; }
        public int TipDostaveId { get; set; }
        public TipDostave TipDostave { get; set; }
        public ICollection<StanjeServisa> StanjeServisa { get; set; }
    }
}

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
        public int Ocjena { get; set; }
        public string Status { get; set; }
        public int ZahtjevId { get; set; }
        public Zahtjevi Zahtjev { get; set; }
    }
}

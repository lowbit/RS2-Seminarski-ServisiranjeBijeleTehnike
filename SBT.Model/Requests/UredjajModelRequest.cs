using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SBT.Model.Requests
{
    public class UredjajModelRequest
    {
        public int KategorijaId { get; set; }
        public int ProizvodjacId { get; set; }
        [Required]
        [MinLength(3)]
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public byte[] Slika { get; set; }
    }
}

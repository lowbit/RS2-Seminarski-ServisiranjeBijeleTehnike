using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SBT.Model.Requests
{
    public class ProizvodjacModelRequest
    {
        public int ProizvodjacId { get; set; }
        [Required]
        [MinLength(3)]
        public string Naziv { get; set; }
    }
}

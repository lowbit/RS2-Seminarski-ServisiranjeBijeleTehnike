﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class Proizvodjaci
    {
        [Key]
        public int ProizvodjacId { get; set; }
        public string Naziv { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public bool IsUlogeLoadingEnabled { get; set; }
    }
}

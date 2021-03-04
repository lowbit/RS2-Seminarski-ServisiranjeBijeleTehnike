using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model.Requests
{
    public class SearchRequest
    {
        public string Naziv { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
    }
}

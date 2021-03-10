using System;
using System.Collections.Generic;
using System.Text;

namespace SBT.Model.Requests
{
    public class SearchRequestServis
    {
        public string ImeServisera { get; set; }
        public string ImeKlijenta { get; set; }
        public string PrezimeKlijenta { get; set; }
        public string EmailKlijenta { get; set; }
        public bool KoristiDatum { get; set; }
        public DateTime DatumServisa { get; set; }
    }
}

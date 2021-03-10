using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class StanjeServisa
    {
        [Key]
        public int StanjeServisaId { get; set; }
        public string Napomena { get; set; }
        public int StatusServisaId { get; set; }
        public StatusServisa TrenutniStatus { get; set; }
        public DateTime Azurirano { get; set; }

    }
}

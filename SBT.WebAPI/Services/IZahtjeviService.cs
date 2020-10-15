using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public interface IZahtjeviService
    {
        List<Model.ZahtjevModel> GetZahtjeviList();
    }
}

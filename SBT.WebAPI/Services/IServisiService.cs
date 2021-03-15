using SBT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public interface IServisiService
    {
        List<Model.ServisModel> GetList();
        List<Model.ServisModel> GetServisiList(Model.Requests.SearchRequestServis request);
        Model.ServisModel GetById(int id);
    }
}

using SBT.Model;
using SBT.Model.Requests;
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
        Model.ServisModel AddServis(Model.Requests.ServisInsertRequest request);
        List<Model.ServisModel> GetServisiByUser(SearchMobileServiceRequest request);
        List<Model.StatusServisaModel> GetVrsteStatusa();
    }
}

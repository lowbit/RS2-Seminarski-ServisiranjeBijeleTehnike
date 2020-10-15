using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public interface IUredjajiService
    {
        List<Model.UredjajModel> GetUredjajiList();
        List<Model.KategorijaModelAdd> GetKategorijeList();
        List<Model.ProizvodjacModel> GetProizvodjaciList();
        List<Model.UredjajModel> GetUredjajiByKategorijeList(int kategorijaId);
        List<Model.UredjajModel> GetUredjajiByProizvodjaciList(int proizvodjacId);
        Model.KategorijaModelAdd AddKategorija(Model.Requests.KategorijaModelRequest request);
        Model.ProizvodjacModel AddProizvodjac(Model.Requests.ProizvodjacModelRequest request);
        Model.UredjajModel AddUredjaj(Model.Requests.UredjajModelRequest request);
        Model.UredjajModel EditUredjaj(int uredjajId, Model.Requests.UredjajModelRequest request);
    }
}

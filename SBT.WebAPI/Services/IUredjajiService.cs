using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public interface IUredjajiService
    {
        Model.UredjajModel GetUredjajById(int uredjajId);
        List<Model.UredjajModel> GetUredjajiList(Model.Requests.SearchRequest request);
        List<Model.KategorijaModel> GetKategorijeList();
        List<Model.KategorijaModel> GetKategorijeListNotEmpty();
        List<Model.ProizvodjacModel> GetProizvodjaciList();
        List<Model.UredjajModel> GetUredjajiByKategorijaList(int kategorijaId);
        List<Model.UredjajModel> GetUredjajiByProizvodjaciList(int proizvodjacId);
        Model.KategorijaModel AddKategorija(Model.Requests.KategorijaModelRequest request);
        Model.ProizvodjacModel AddProizvodjac(Model.Requests.ProizvodjacModelRequest request);
        Model.UredjajModel AddUredjaj(Model.Requests.UredjajModelRequest request);
        Model.UredjajModel EditUredjaj(int uredjajId, Model.Requests.UredjajModelRequest request);
    }
}

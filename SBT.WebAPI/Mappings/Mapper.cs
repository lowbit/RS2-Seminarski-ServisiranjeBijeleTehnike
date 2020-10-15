using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Mappings
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Servisi, Model.ServisModel>().ReverseMap();
            CreateMap<Database.Uredjaji, Model.UredjajModel>().ReverseMap();
            CreateMap<Database.Kategorije, Model.KategorijaModelAdd>().ReverseMap();
            CreateMap<Database.Proizvodjaci, Model.ProizvodjacModel>().ReverseMap();
            CreateMap<Database.Uredjaji, Model.Requests.UredjajModelRequest>().ReverseMap();
            CreateMap<Database.Kategorije, Model.Requests.KategorijaModelRequest>().ReverseMap();
            CreateMap<Database.Proizvodjaci, Model.Requests.ProizvodjacModelRequest>().ReverseMap();
            CreateMap<Database.Zahtjevi, Model.ZahtjevModel>().ReverseMap();
        }
    }
}

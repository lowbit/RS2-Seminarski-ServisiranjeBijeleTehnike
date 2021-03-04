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
            CreateMap<Database.Korisnici, Model.KorisniciModel>().ReverseMap();
            CreateMap<Database.Korisnici, Model.Requests.KorisniciInsertRequest>().ReverseMap();
            CreateMap<Database.Korisnici, Model.KorisnikModel>().ReverseMap();
            CreateMap<Database.Korisnici, Model.Requests.KorisnikUpdateRequest>().ReverseMap();
            CreateMap<Database.Uloge, Model.UlogeModel>().ReverseMap();
            CreateMap<Database.KorisniciUloge, Model.KorisniciUlogeModel>().ReverseMap();
            CreateMap<Database.Servisi, Model.ServisModel>().ReverseMap();
            CreateMap<Database.Uredjaji, Model.UredjajModel>().ReverseMap();
            CreateMap<Database.Kategorije, Model.KategorijaModel>().ReverseMap();
            CreateMap<Database.Proizvodjaci, Model.ProizvodjacModel>().ReverseMap();
            CreateMap<Database.Uredjaji, Model.Requests.UredjajModelRequest>().ReverseMap();
            CreateMap<Database.Kategorije, Model.Requests.KategorijaModelRequest>().ReverseMap();
            CreateMap<Database.Proizvodjaci, Model.Requests.ProizvodjacModelRequest>().ReverseMap();
            CreateMap<Database.Zahtjevi, Model.ZahtjevModel>().ReverseMap();
        }
    }
}

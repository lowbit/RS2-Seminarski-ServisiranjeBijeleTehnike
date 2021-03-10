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
            CreateMap<Database.Uredjaji, Model.UredjajModel>().ReverseMap();
            CreateMap<Database.Kategorije, Model.KategorijaModel>().ReverseMap();
            CreateMap<Database.Proizvodjaci, Model.ProizvodjacModel>().ReverseMap();
            CreateMap<Database.Uredjaji, Model.Requests.UredjajModelRequest>().ReverseMap();
            CreateMap<Database.Kategorije, Model.Requests.KategorijaModelRequest>().ReverseMap();
            CreateMap<Database.Proizvodjaci, Model.Requests.ProizvodjacModelRequest>().ReverseMap();
            CreateMap<Database.Servisi, Model.ServisModel>()
                .ForMember(dest=>dest.KlijentIme, opt=>opt.MapFrom(src=>src.Klijent.Ime))
                .ForMember(dest => dest.KlijentIme, opt => opt.MapFrom(src => src.Klijent.Ime + " " + src.Klijent.Prezime))
                .ForMember(dest => dest.ServiserIme, opt => opt.MapFrom(src => src.Serviser.Ime + " " + src.Serviser.Prezime))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Naziv))
                .ForMember(dest => dest.TipDostaveNaziv, opt => opt.MapFrom(src => src.TipDostave.Naziv))
                .ForMember(dest => dest.TipPlacanjaNaziv, opt => opt.MapFrom(src => src.TipPlacanja.Naziv))
                .ForMember(dest => dest.UredjajNaziv, opt => opt.MapFrom(src => src.Uredjaj.Naziv));
            CreateMap<Database.TipPlacanja, Model.TipPlacanjaModel>().ReverseMap();
            CreateMap<Database.TipDostave, Model.TipDostaveModel>().ReverseMap();
            CreateMap<Database.StatusServisa, Model.StatusServisaModel>().ReverseMap();
            CreateMap<Database.StanjeServisa, Model.StanjeServisaModel>().ReverseMap();
        }
    }
}

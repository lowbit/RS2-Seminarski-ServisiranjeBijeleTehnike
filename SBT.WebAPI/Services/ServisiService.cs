﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SBT.Model;
using SBT.Model.Requests;
using SBT.WebAPI.Database;
using SBT.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Services
{
    public class ServisiService : IServisiService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ServisiService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ServisModel AddServis(ServisInsertRequest request)
        {
            var entity = _mapper.Map<Database.Servisi>(request);
            Recommender recommender = new Recommender(_context, _mapper);
            var dodjeljeniServiser = recommender.GetServisera(request.UredjajId);
            if (dodjeljeniServiser == null)
            {
                dodjeljeniServiser = _context.KorisniciUloge.Include(k => k.Korisnik).Where(ko => ko.Uloga.Naziv == "serviser").Select(k=>k.Korisnik).FirstOrDefault();
            }
            entity.ServiserId = dodjeljeniServiser.KorisnikId;
            _context.Servisi.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<ServisModel>(entity);
        }

        public ServisModel GetById(int id)
        {

            var entity = _context.Servisi.Include("Serviser").Include("Klijent").Include("Status")
                            .Include("Uredjaj").Include("TipPlacanja").Include("TipDostave").Include("StanjeServisa").Include("StanjeServisa.TrenutniStatus").Where(x => x.ServisId == id).FirstOrDefault();


            return _mapper.Map<Model.ServisModel>(entity);
        }

        public List<Model.ServisModel> GetList()
        {
            var list = _context.Servisi.ToList();
            return _mapper.Map<List<Model.ServisModel>>(list);
        }

        public List<ServisModel> GetServisiByUser(int id)
        {
            var query = _context.Servisi.Include("Serviser").Include("Klijent").Include("Status")
                            .Include("Uredjaj").Include("TipPlacanja").Include("TipDostave").AsQueryable();
            var isKorisnik = false;
            var isServiser = false;
            if (id>0)
            {
                var korisnik = _context.Korisnici.Include("KorisniciUloge.Uloga").Where(x=>x.KorisnikId == id).FirstOrDefault();
                if (korisnik != null)
                {
                    foreach (var item in korisnik.KorisniciUloge)
                    {
                        if(item.Uloga.Naziv == "korisnik")
                        {
                            isKorisnik = true;
                        } 
                        if (item.Uloga.Naziv == "serviser")
                        {
                            isServiser = true;
                        }
                    }
                }
                if (isServiser)
                {
                    query = query.Where(u => u.ServiserId == id);
                    var list = query.ToList();
                    return _mapper.Map<List<Model.ServisModel>>(list);
                } 
                else if (isKorisnik)
                {
                    query = query.Where(u => u.KlijentId == id);
                    var list = query.ToList();
                    return _mapper.Map<List<Model.ServisModel>>(list);
                }
            }
            return null;
        }

        public List<ServisModel> GetServisiList(SearchRequestServis request)
        {
            var query = _context.Servisi.Include("Serviser").Include("Klijent").Include("Status")
                            .Include("Uredjaj").Include("TipPlacanja").Include("TipDostave").AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.ImeServisera))
            {
                query = query.Where(u => u.Serviser.Ime.Contains(request.ImeServisera));
            }
            if (!string.IsNullOrWhiteSpace(request?.ImeKlijenta))
            {
                query = query.Where(u => u.Klijent.Ime.Contains(request.ImeKlijenta));
            }
            if (!string.IsNullOrWhiteSpace(request?.PrezimeKlijenta))
            {
                query = query.Where(u => u.Klijent.Prezime.Contains(request.PrezimeKlijenta));
            }
            if (!string.IsNullOrWhiteSpace(request?.EmailKlijenta))
            {
                query = query.Where(u => u.Klijent.Email.Contains(request.EmailKlijenta));
            }
            if (request.KoristiDatum)
            {
                query = query.Where(u => u.DatumServisa.Date.Equals(request.DatumServisa.Date));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.ServisModel>>(list);
        }
    }
}

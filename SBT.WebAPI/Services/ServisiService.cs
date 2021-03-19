using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SBT.Model;
using SBT.Model.Requests;
using SBT.WebAPI.Database;
using SBT.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Mail;
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
                dodjeljeniServiser = _context.KorisniciUloge.Include(k => k.Korisnik).Where(ko => ko.Uloga.Naziv == "serviser").Select(k => k.Korisnik).FirstOrDefault();
            }
            entity.ServiserId = dodjeljeniServiser.KorisnikId;
            var status1 = _context.StatusServisa.Where(x => x.Naziv == "Servis napravljen").FirstOrDefault();
            var status2 = _context.StatusServisa.Where(x => x.Naziv == "Servis dodjeljen serviseru").FirstOrDefault();
            entity.StatusServisaId = status2.StatusServisaId;
            _context.Servisi.Add(entity);
            _context.SaveChanges();
            StanjeServisa ss1 = new StanjeServisa();
            ss1.Azurirano = DateTime.Now;
            ss1.Napomena = "Servir kreiran";
            ss1.ServisId = entity.ServisId;
            ss1.StatusServisaId = status1.StatusServisaId;
            _context.StanjeServisa.Add(ss1);
            _context.SaveChanges();
            StanjeServisa ss2 = new StanjeServisa();
            ss2.Azurirano = DateTime.Now;
            ss2.Napomena = "Servis uspjesno dodjeljen serviseru";
            ss2.ServisId = entity.ServisId;
            ss2.StatusServisaId = status2.StatusServisaId;
            _context.StanjeServisa.Add(ss2);
            _context.SaveChanges();
            return _mapper.Map<ServisModel>(entity);
        }

        public ServisModel GetById(int id)
        {

            var entity = _context.Servisi.Include("Serviser").Include("Klijent").Include("Status")
                            .Include("Uredjaj").Include("TipPlacanja").Include("TipDostave").Include("StanjeServisa.TrenutniStatus").Include("Uredjaj.SlikeUredjaja").Where(x => x.ServisId == id).FirstOrDefault();

            entity.StanjeServisa = _context.StanjeServisa.Where(x => x.ServisId == id).OrderByDescending(x => x.StanjeServisaId).ToList();
            return _mapper.Map<Model.ServisModel>(entity);
        }

        public List<Model.ServisModel> GetList()
        {
            var list = _context.Servisi.ToList();
            return _mapper.Map<List<Model.ServisModel>>(list);
        }

        public List<ServisModel> GetServisiByUser(SearchMobileServiceRequest request)
        {
            var query = _context.Servisi.Include("Serviser").Include("Klijent").Include("Status")
                            .Include("Uredjaj").Include("TipPlacanja").Include("TipDostave").AsQueryable();
            var isKorisnik = false;
            var isServiser = false;
            if (request.VrstaStatusaId > 0)
            {
                query = query.Where(x => x.StatusServisaId == request.VrstaStatusaId);
            }
            if (request.KorisnikId > 0)
            {
                var korisnik = _context.Korisnici.Include("KorisniciUloge.Uloga").Where(x => x.KorisnikId == request.KorisnikId).FirstOrDefault();
                if (korisnik != null)
                {
                    foreach (var item in korisnik.KorisniciUloge)
                    {
                        if (item.Uloga.Naziv == "korisnik")
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
                    query = query.Where(u => u.ServiserId == request.KorisnikId);
                    var list = query.OrderByDescending(x => x.DatumServisa).ToList();
                    return _mapper.Map<List<Model.ServisModel>>(list);
                }
                else if (isKorisnik)
                {
                    query = query.Where(u => u.KlijentId == request.KorisnikId);
                    var list = query.OrderByDescending(x => x.DatumServisa).ToList();
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

        public List<TipDostaveModel> GetTipoveDostave()
        {
            var tipovi = _context.TipDostave.OrderBy(x => x.TipDostaveId).ToList();
            return _mapper.Map<List<Model.TipDostaveModel>>(tipovi);
        }

        public List<TipPlacanjaModel> GetTipovePlacanja()
        {
            var tipovi = _context.TipPlacanja.OrderBy(x => x.TipPlacanjaId).ToList();
            return _mapper.Map<List<Model.TipPlacanjaModel>>(tipovi);
        }

        public List<StatusServisaModel> GetVrsteStatusa()
        {
            var statusi = _context.StatusServisa.OrderBy(x => x.StatusServisaId).ToList();
            return _mapper.Map<List<Model.StatusServisaModel>>(statusi);
        }

        public StanjeServisaInsertRequest StanjeServisaAdd(StanjeServisaInsertRequest request)
        {
            var entity = new StanjeServisa();
            entity.Azurirano = request.Azurirano;
            entity.Napomena = request.Napomena;
            entity.ServisId = request.ServisId;
            var statusServisa = _context.StatusServisa.Where(x => x.Naziv == request.TrenutniStatus).FirstOrDefault();
            entity.StatusServisaId = statusServisa.StatusServisaId;
            _context.StanjeServisa.Add(entity);
            _context.SaveChanges();
            var servis = _context.Servisi.Find(request.ServisId);
            if (request.Ocijena != 0)
            {
                servis.OcjenaServisa = request.Ocijena;
            }
            if (request.Cijena != 0)
            {
                servis.Cijena = request.Cijena;
            }
            servis.StatusServisaId = statusServisa.StatusServisaId;
            _context.Servisi.Update(servis);
            _context.SaveChanges();
            var zavrsniStatusServisa = _context.StatusServisa.Where(x => x.Naziv == "Servis zavrsen").FirstOrDefault();
            //Send Email Does not work locally with emulators (Needs SSL for Sending Mail, but emulator does not work with SSL)
            //if (entity.StatusServisaId == zavrsniStatusServisa.StatusServisaId)
            //{
            //    var klijent = _context.Korisnici.Where(x => x.KorisnikId == servis.KlijentId).FirstOrDefault();
            //    using (MailMessage mm = new MailMessage("", klijent.Email))
            //    {
            //        mm.Subject = "Servis završen";
            //        mm.Body = "Vaš uređaj je spreman, provjerite na aplikaciji stanje.";
            //        mm.IsBodyHtml = false;
            //        using (SmtpClient smtp = new SmtpClient())
            //        {
            //            smtp.Host = "smtp.gmail.com";
            //            smtp.EnableSsl = true;
            //            NetworkCredential NetworkCred = new NetworkCredential("", "");
            //            smtp.UseDefaultCredentials = true;
            //            smtp.Credentials = NetworkCred;
            //            smtp.Port = 587;
            //            smtp.Send(mm);
            //        }
            //    }
            //}
            return request;
        }
    }
}

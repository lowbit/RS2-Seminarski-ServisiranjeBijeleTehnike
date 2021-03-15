using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SBT.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Utils
{
    public class Recommender
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        Dictionary<int, List<Servisi>> servisi = new Dictionary<int, List<Servisi>>();
        public Recommender(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Korisnici GetServisera(int uredjajId)
        {
            UcitajServise(uredjajId);
            List<Servisi> ocjeneKategorije = _context.Servisi.Include(x=>x.Uredjaj).Where(x => x.Uredjaj.KategorijaId == uredjajId).ToList();
            List<Servisi> zajednickeOcjene1 = new List<Servisi>(); 
            List<Servisi> zajednickeOcjene2 = new List<Servisi>();
            List<Korisnici> preporuceniServiseri = new List<Korisnici>();
            foreach (var item in servisi)
            {
                foreach (var item2 in ocjeneKategorije)
                {
                    if(item.Value.Where(x=>x.Uredjaj.KategorijaId==item2.Uredjaj.KategorijaId).Count() > 0)
                    {
                        zajednickeOcjene1.Add(item2);
                        zajednickeOcjene2.Add(item.Value.Where(x => x.Uredjaj.KategorijaId == item2.Uredjaj.KategorijaId).First());
                    }
                }
                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);
                if(slicnost > 0.5)
                {
                    preporuceniServiseri.Add(_context.Korisnici.Where(k => k.KorisnikId == item.Key).FirstOrDefault());
                }
                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }
            return preporuceniServiseri.Count > 0 ? preporuceniServiseri[0] : null; ;
        }

        private double GetSlicnost(List<Servisi> zajednickeOcjene1, List<Servisi> zajednickeOcjene2)
        {
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
                return 0;
            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;
            for (int i = 0; i < zajednickeOcjene1.Count; i++)
            {
                brojnik = zajednickeOcjene1[i].OcjenaServisa * zajednickeOcjene2[i].OcjenaServisa;
                nazivnik1 = zajednickeOcjene1[i].OcjenaServisa * zajednickeOcjene1[i].OcjenaServisa;
                nazivnik2 = zajednickeOcjene2[i].OcjenaServisa * zajednickeOcjene2[i].OcjenaServisa;
            }
            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);
            double nazivnik = nazivnik1 * nazivnik2;
            if (nazivnik == 0)
                return 0;
            return brojnik / nazivnik;
        }

        private void UcitajServise(int uredjajId)
        {
            Uredjaji uredjaj = _context.Uredjaji.Find(uredjajId);
            List<Servisi> servisiIsteKategorije = _context.Servisi.Include(x => x.Uredjaj).Where(x => x.Uredjaj.KategorijaId == uredjaj.KategorijaId).ToList();
            List<int> serviseri = new List<int>();
            List<Servisi> servisiServisera;
            foreach (var servis in servisiIsteKategorije)
            {
                if (servis.OcjenaServisa > 0)
                {
                    if (!serviseri.Contains(servis.ServiserId))
                    {
                        serviseri.Add(servis.ServiserId);
                    }
                }
            }
            foreach (var serviser in serviseri)
            {
                servisiServisera = new List<Servisi>();
                foreach (var servis in servisiIsteKategorije)
                {
                    if (servis.OcjenaServisa > 0 && servis.ServiserId==serviser)
                    {
                        servisiServisera.Add(servis);
                    }
                }
                servisi.Add(serviser, servisiServisera);
            }
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public class Seeder
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public Seeder(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task SeedData()
        {
            _context.Database.EnsureCreated();
            if (!_context.Kategorije.Any())
            {
                _context.Kategorije.AddRange(
                        new Kategorije { Naziv = "Frižideri" },
                        new Kategorije { Naziv = "Zamrzivači" },
                        new Kategorije { Naziv = "Električni šporeti" },
                        new Kategorije { Naziv = "Plinski šporeti" },
                        new Kategorije { Naziv = "Mašine za pranje veša" },
                        new Kategorije { Naziv = "Mašine za sušenje veša" },
                        new Kategorije { Naziv = "Mašine za pranje posuđa" },
                        new Kategorije { Naziv = "Uljni radijatori" },
                        new Kategorije { Naziv = "Grijalice" },
                        new Kategorije { Naziv = "Konvektori" },
                        new Kategorije { Naziv = "Kamini" },
                        new Kategorije { Naziv = "Peći na čvrsto gorivo" },
                        new Kategorije { Naziv = "Klima uređaji" },
                        new Kategorije { Naziv = "Ventilatori" },
                        new Kategorije { Naziv = "Bojleri" },
                        new Kategorije { Naziv = "Kuhinjske Nape" }
                    );
                _context.SaveChanges();
            }
            if (!_context.Proizvodjaci.Any())
            {
                _context.Proizvodjaci.AddRange(
                        new Proizvodjaci { Naziv = "Beko" },
                        new Proizvodjaci { Naziv = "Bosch" },
                        new Proizvodjaci { Naziv = "Electrolux" },
                        new Proizvodjaci { Naziv = "Ferre" },
                        new Proizvodjaci { Naziv = "Gorenje" },
                        new Proizvodjaci { Naziv = "Indesit" },
                        new Proizvodjaci { Naziv = "Miele" },
                        new Proizvodjaci { Naziv = "Rowenta" },
                        new Proizvodjaci { Naziv = "Samsung" },
                        new Proizvodjaci { Naziv = "Vox" },
                        new Proizvodjaci { Naziv = "Whirlpool" },
                        new Proizvodjaci { Naziv = "Candy" }
                    );
                _context.SaveChanges();
            }
            if (!_context.Uredjaji.Any())
            {
                var kategorija1 = _context.Kategorije.Where(k => k.Naziv == "Frižideri").FirstOrDefault();
                var kategorija2 = _context.Kategorije.Where(k => k.Naziv == "Grijalice").FirstOrDefault();
                var kategorija3 = _context.Kategorije.Where(k => k.Naziv == "Mašine za pranje veša").FirstOrDefault();
                var proizvodjac1 = _context.Proizvodjaci.Where(p => p.Naziv == "Beko").FirstOrDefault();
                var proizvodjac2 = _context.Proizvodjaci.Where(p => p.Naziv == "Gorenje").FirstOrDefault();
                var proizvodjac3 = _context.Proizvodjaci.Where(p => p.Naziv == "Candy").FirstOrDefault();
                var proizvodjac4 = _context.Proizvodjaci.Where(p => p.Naziv == "Samsung").FirstOrDefault();
                _context.Uredjaji.AddRange(
                        new Uredjaji
                        {
                            Naziv = "Samsung frizider",
                            KategorijaId = kategorija1.KategorijaId,
                            ProizvodjacId = proizvodjac4.ProizvodjacId,
                            Opis = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.",
                        },
                        new Uredjaji
                        {
                            Naziv = "Candy masina za ves",
                            KategorijaId = kategorija1.KategorijaId,
                            ProizvodjacId = proizvodjac1.ProizvodjacId,
                            Opis = "Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu.",
                        },
                        new Uredjaji
                        {
                            Naziv = "Gorenje grijalica",
                            KategorijaId = kategorija2.KategorijaId,
                            ProizvodjacId = proizvodjac2.ProizvodjacId,
                            Opis = "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim.",
                        },
                        new Uredjaji
                        {
                            Naziv = "Beko frizider",
                            KategorijaId = kategorija1.KategorijaId,
                            ProizvodjacId = proizvodjac1.ProizvodjacId,
                            Opis = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa.",
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.SlikeUredjaja.Any())
            {
                var uredjaji = _context.Uredjaji.ToList();
                _context.SlikeUredjaja.AddRange(
                        new SlikeUredjaja
                        {
                            Slika = ReadFile("Images/bekoFrizider.png"),
                            UredjajId = uredjaji[0].UredjajId
                        },
                        new SlikeUredjaja
                        {
                            Slika = ReadFile("Images/gorenjeGrijalica.png"),
                            UredjajId = uredjaji[1].UredjajId
                        },
                        new SlikeUredjaja
                        {
                            Slika = ReadFile("Images/candyMasina.png"),
                            UredjajId = uredjaji[2].UredjajId
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.Uloge.Any())
            {
                _context.Uloge.AddRange(
                        new Uloge
                        {
                            Naziv = "admin"
                        },
                        new Uloge
                        {
                            Naziv = "serviser"
                        },
                        new Uloge
                        {
                            Naziv = "korisnik"
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.Korisnici.Any())
            {
                _context.Korisnici.AddRange(
                        new Korisnici
                        {
                            Ime = "Rijad",
                            Prezime = "Spahić",
                            Email = "rijad.spahic@edu.fit.ba",
                            KorisnickoIme = "desktop",
                            LozinkaHash = "19TZFVQUWL66HvlHGP001RP8N24=",
                            LozinkaSalt = "Lbm29E5AFt6DRiztYw4QaQ==",
                            Slika = ReadFile("Images/user1.png"),
                        },
                        new Korisnici
                        {
                            Ime = "Eldin",
                            Prezime = "Tiro",
                            Email = "eldin.tiro@edu.fit.ba",
                            KorisnickoIme = "serviser",
                            LozinkaHash = "07ZLn15vrxFMThX5w2QCKfhnHlA=",
                            LozinkaSalt = "0pBhY4NHGeGcNJdhOZYyUQ==",
                            Slika = ReadFile("Images/user2.png"),
                        },
                        new Korisnici
                        {
                            Ime = "Amer",
                            Prezime = "Bilić",
                            Email = "amer.bilic@edu.fit.ba",
                            KorisnickoIme = "korisnik",
                            LozinkaHash = "IhFdfIjML0ors8/GONI0TjqWTkM=",
                            LozinkaSalt = "CjHVi4+z3fTtun6tWrdTMQ==",
                            Slika = ReadFile("Images/user3.png"),
                        },
                        new Korisnici
                        {
                            Ime = "Enis",
                            Prezime = "Mulić",
                            Email = "enis.mulic@edu.fit.ba",
                            KorisnickoIme = "serviser2",
                            LozinkaHash = "ACrjjI8A/GqLMoroaajJ+u+TjIQ=",
                            LozinkaSalt = "YUducthd+QYkHLx35UFe4Q==",
                        },
                        new Korisnici
                        {
                            Ime = "Irma",
                            Prezime = "Masleša",
                            Email = "irma.maslesa@edu.fit.ba",
                            KorisnickoIme = "korisnik2",
                            LozinkaHash = "jFK60qom8/BeUQWW8gRJ3/oRaOE=",
                            LozinkaSalt = "ConJxTwH3ISJWzhgacLTHg==",
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.KorisniciUloge.Any())
            {
                var ulogaAdmin = _context.Uloge.Where(u => u.Naziv == "admin").FirstOrDefault();
                var ulogaServiser = _context.Uloge.Where(u => u.Naziv == "serviser").FirstOrDefault();
                var ulogaKorisnik = _context.Uloge.Where(u => u.Naziv == "korisnik").FirstOrDefault();
                var korisnikAdmin = _context.Korisnici.Where(k => k.KorisnickoIme == "desktop").FirstOrDefault();
                var korisnikServiser = _context.Korisnici.Where(k => k.KorisnickoIme == "serviser").FirstOrDefault();
                var korisnikKorisnik = _context.Korisnici.Where(k => k.KorisnickoIme == "korisnik").FirstOrDefault();
                var korisnikServiser2 = _context.Korisnici.Where(k => k.KorisnickoIme == "serviser2").FirstOrDefault();
                var korisnikKorisnik2 = _context.Korisnici.Where(k => k.KorisnickoIme == "korisnik2").FirstOrDefault();
                _context.KorisniciUloge.AddRange(
                    new KorisniciUloge
                    {
                        KorisnikId = korisnikAdmin.KorisnikId,
                        UlogaId = ulogaAdmin.UlogaId,
                        DatumIzmjene = DateTime.Now,
                    },
                    new KorisniciUloge
                    {
                        KorisnikId = korisnikServiser.KorisnikId,
                        UlogaId = ulogaServiser.UlogaId,
                        DatumIzmjene = DateTime.Now
                    },
                    new KorisniciUloge
                    {
                        KorisnikId = korisnikKorisnik.KorisnikId,
                        UlogaId = ulogaKorisnik.UlogaId,
                        DatumIzmjene = DateTime.Now
                    },
                    new KorisniciUloge
                    {
                        KorisnikId = korisnikServiser2.KorisnikId,
                        UlogaId = ulogaServiser.UlogaId,
                        DatumIzmjene = DateTime.Now
                    },
                    new KorisniciUloge
                    {
                        KorisnikId = korisnikKorisnik2.KorisnikId,
                        UlogaId = ulogaKorisnik.UlogaId,
                        DatumIzmjene = DateTime.Now
                    }
                );
                _context.SaveChanges();

            }
            if (!_context.TipDostave.Any())
            {
                _context.TipDostave.AddRange(
                        new TipDostave
                        {
                            Naziv = "Na lice mjesta"
                        },
                        new TipDostave
                        {
                            Naziv = "Korisnik transportuje"
                        },
                        new TipDostave
                        {
                            Naziv = "NServiser transportuje"
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.TipPlacanja.Any())
            {
                _context.TipPlacanja.AddRange(
                        new TipPlacanja
                        {
                            Naziv = "Licno"
                        },
                        new TipPlacanja
                        {
                            Naziv = "Kartica"
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.StatusServisa.Any())
            {
                _context.StatusServisa.AddRange(
                        new StatusServisa
                        {
                            Naziv = "Servis zavrsen"
                        },
                        new StatusServisa
                        {
                            Naziv = "Cekanje na odgovor servisera"
                        },
                        new StatusServisa
                        {
                            Naziv = "Cekanje na odgovor klijenta"
                        },
                        new StatusServisa
                        {
                            Naziv = "Servis u izradi"
                        },
                        new StatusServisa
                        {
                            Naziv = "Servis dodjeljen serviseru"
                        },
                        new StatusServisa
                        {
                            Naziv = "Servis napravljen"
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.Servisi.Any())
            {
                var korisnik = _context.Korisnici.Where(k => k.KorisnickoIme == "korisnik").FirstOrDefault();
                var serviser = _context.Korisnici.Where(k => k.KorisnickoIme == "serviser").FirstOrDefault();
                var korisnik2 = _context.Korisnici.Where(k => k.KorisnickoIme == "korisnik2").FirstOrDefault();
                var serviser2 = _context.Korisnici.Where(k => k.KorisnickoIme == "serviser2").FirstOrDefault();
                var statusServisa = _context.StatusServisa.Where(s => s.Naziv == "Servis zavrsen").FirstOrDefault();
                var tipDostave = _context.TipDostave.Where(td => td.Naziv == "Korisnik transportuje").FirstOrDefault();
                var tipPlacanja = _context.TipPlacanja.Where(tp => tp.Naziv == "Licno").FirstOrDefault();
                var uredjaj = _context.Uredjaji.Where(u => u.Naziv == "Beko frizider").FirstOrDefault();
                var uredjaj2 = _context.Uredjaji.Where(u => u.Naziv == "Samsung frizider").FirstOrDefault();
                var uredjaj3 = _context.Uredjaji.Where(u => u.Naziv == "Gorenje grijalica").FirstOrDefault();
                _context.Servisi.AddRange(
                        new Servisi
                        {
                            KlijentId = korisnik.KorisnikId,
                            ServiserId = serviser.KorisnikId,
                            StatusServisaId = statusServisa.StatusServisaId,
                            TipDostaveId = tipDostave.TipDostaveId,
                            TipPlacanjaId = tipPlacanja.TipPlacanjaId,
                            UredjajId = uredjaj.UredjajId,
                            Opis = "Zamrzivač prestao raditi",
                            Cijena = 60,
                            DatumServisa = DateTime.Now,
                            OcjenaServisa = 5,
                        },
                        new Servisi
                        {
                            KlijentId = korisnik2.KorisnikId,
                            ServiserId = serviser.KorisnikId,
                            StatusServisaId = statusServisa.StatusServisaId,
                            TipDostaveId = tipDostave.TipDostaveId,
                            TipPlacanjaId = tipPlacanja.TipPlacanjaId,
                            UredjajId = uredjaj2.UredjajId,
                            Opis = "Frižider prestao hladiti",
                            Cijena = 80,
                            DatumServisa = DateTime.Now,
                            OcjenaServisa = 4,
                        },
                        new Servisi
                        {
                            KlijentId = korisnik.KorisnikId,
                            ServiserId = serviser2.KorisnikId,
                            StatusServisaId = statusServisa.StatusServisaId,
                            TipDostaveId = tipDostave.TipDostaveId,
                            TipPlacanjaId = tipPlacanja.TipPlacanjaId,
                            UredjajId = uredjaj.UredjajId,
                            Opis = "Frižider prestao hladiti",
                            Cijena = 80,
                            DatumServisa = DateTime.Now,
                            OcjenaServisa = 2,
                        },
                        new Servisi
                        {
                            KlijentId = korisnik2.KorisnikId,
                            ServiserId = serviser2.KorisnikId,
                            StatusServisaId = statusServisa.StatusServisaId,
                            TipDostaveId = tipDostave.TipDostaveId,
                            TipPlacanjaId = tipPlacanja.TipPlacanjaId,
                            UredjajId = uredjaj3.UredjajId,
                            Opis = "Ne radi...",
                            Cijena = 35,
                            DatumServisa = DateTime.Now,
                            OcjenaServisa = 2,
                        }
                    );
                _context.SaveChanges();
            }
            if (!_context.StanjeServisa.Any())
            {
                var servisi = _context.Servisi.ToList();
                var statusiServisa = _context.StatusServisa.OrderBy(s=>s.StatusServisaId).ToList();
                List<StanjeServisa> stanjaServisa = new List<StanjeServisa>();
                
                foreach (var item in servisi)
                {
                    for (int i = 0; i < statusiServisa.Count; i++)
                    {
                        stanjaServisa.Add(new StanjeServisa
                        {
                            Azurirano = DateTime.Now,
                            Napomena = statusiServisa[i].Naziv,
                            StatusServisaId = statusiServisa[i].StatusServisaId,
                            ServisId = item.ServisId
                        }
                        );
                    }
                }
                _context.StanjeServisa.AddRange(stanjaServisa);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }
        public static byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes 
            //to read from file.
            //In this case we want to read entire file. 
            //So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);

            return data;
        }
    }
}

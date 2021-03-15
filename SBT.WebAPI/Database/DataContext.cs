using Microsoft.EntityFrameworkCore;
using SBT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBT.WebAPI.Database
{
    public partial class DataContext: DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UredjajiKategorija>().HasKey(uk => new { uk.UredjajId, uk.KategorijaId });
            //modelBuilder.Entity<UredjajiKategorija>().HasOne(uk => uk.Uredjaj).WithMany(u => u.Kategorije).HasForeignKey(uk => uk.UredjajId);
            //modelBuilder.Entity<UredjajiKategorija>().HasOne(uk => uk.Kategorija).WithMany(k => k.Uredjaji).HasForeignKey(uk => uk.KategorijaId);
            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Korisnici");
                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloge)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Uloge");
            });
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Korisnici> Korisnici { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }
        public virtual DbSet<Kategorije> Kategorije { get; set; }
        public virtual DbSet<Proizvodjaci> Proizvodjaci { get; set; }
        public virtual DbSet<Servisi> Servisi { get; set; }
        public virtual DbSet<StanjeServisa> StanjeServisa { get; set; }
        public virtual DbSet<StatusServisa> StatusServisa { get; set; }
        public virtual DbSet<SlikeUredjaja> SlikeUredjaja { get; set; }
        public virtual DbSet<TipDostave> TipDostave { get; set; }
        public virtual DbSet<TipPlacanja> TipPlacanja { get; set; }
        public virtual DbSet<Uredjaji> Uredjaji { get; set; }
    }
}

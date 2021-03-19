﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SBT.WebAPI.Database;

namespace SBT.WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210228203511_pictureBlob")]
    partial class pictureBlob
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SBT.WebAPI.Database.Kategorije", b =>
                {
                    b.Property<int>("KategorijaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.HasKey("KategorijaId");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Proizvodjaci", b =>
                {
                    b.Property<int>("ProizvodjacId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.HasKey("ProizvodjacId");

                    b.ToTable("Proizvodjaci");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Servisi", b =>
                {
                    b.Property<int>("ServisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Cijena")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("DatumServisa")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Ocjena")
                        .HasColumnType("integer");

                    b.Property<string>("Opis")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("ZahtjevId")
                        .HasColumnType("integer");

                    b.HasKey("ServisId");

                    b.HasIndex("ZahtjevId");

                    b.ToTable("Servisi");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.SlikeUredjaja", b =>
                {
                    b.Property<int>("SlikaUredjajaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Slika")
                        .HasColumnType("bytea");

                    b.Property<int>("UredjajId")
                        .HasColumnType("integer");

                    b.HasKey("SlikaUredjajaId");

                    b.HasIndex("UredjajId");

                    b.ToTable("SlikeUredjaja");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.TipDostave", b =>
                {
                    b.Property<int>("TipDostaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.HasKey("TipDostaveId");

                    b.ToTable("TipDostave");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.TipPlacanja", b =>
                {
                    b.Property<int>("TipPlacanjaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.HasKey("TipPlacanjaId");

                    b.ToTable("TipPlacanja");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Uredjaji", b =>
                {
                    b.Property<int>("UredjajId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("KategorijaId")
                        .HasColumnType("integer");

                    b.Property<string>("Naziv")
                        .HasColumnType("text");

                    b.Property<string>("Opis")
                        .HasColumnType("text");

                    b.Property<int>("ProizvodjacId")
                        .HasColumnType("integer");

                    b.HasKey("UredjajId");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("ProizvodjacId");

                    b.ToTable("Uredjaji");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Zahtjevi", b =>
                {
                    b.Property<int>("ZahtjevId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DatumKreiranja")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Napomena")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<int>("TipDostaveId")
                        .HasColumnType("integer");

                    b.Property<int>("TipPlacanjaId")
                        .HasColumnType("integer");

                    b.Property<int>("UredjajId")
                        .HasColumnType("integer");

                    b.HasKey("ZahtjevId");

                    b.HasIndex("TipDostaveId");

                    b.HasIndex("TipPlacanjaId");

                    b.HasIndex("UredjajId");

                    b.ToTable("Zahtjevi");
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Servisi", b =>
                {
                    b.HasOne("SBT.WebAPI.Database.Zahtjevi", "Zahtjev")
                        .WithMany()
                        .HasForeignKey("ZahtjevId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SBT.WebAPI.Database.SlikeUredjaja", b =>
                {
                    b.HasOne("SBT.WebAPI.Database.Uredjaji", "Uredjaj")
                        .WithMany("SlikeUredjaja")
                        .HasForeignKey("UredjajId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Uredjaji", b =>
                {
                    b.HasOne("SBT.WebAPI.Database.Kategorije", "Kategorija")
                        .WithMany("Uredjaji")
                        .HasForeignKey("KategorijaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SBT.WebAPI.Database.Proizvodjaci", "Proizvodjac")
                        .WithMany()
                        .HasForeignKey("ProizvodjacId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SBT.WebAPI.Database.Zahtjevi", b =>
                {
                    b.HasOne("SBT.WebAPI.Database.TipDostave", "TipDostave")
                        .WithMany()
                        .HasForeignKey("TipDostaveId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SBT.WebAPI.Database.TipPlacanja", "TipPlacanja")
                        .WithMany()
                        .HasForeignKey("TipPlacanjaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SBT.WebAPI.Database.Uredjaji", "Uredjaj")
                        .WithMany()
                        .HasForeignKey("UredjajId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

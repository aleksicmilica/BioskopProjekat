﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace proj2._0.Migrations
{
    [DbContext(typeof(BioskopContext))]
    partial class BioskopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Bioskop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Bioskopi");
                });

            modelBuilder.Entity("Models.BioskopFilm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BioskopId")
                        .HasColumnType("int");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BioskopId");

                    b.HasIndex("FilmId");

                    b.ToTable("BioskopiFilmovi");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<DateTime>("datumKraja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("datumPocetka")
                        .HasColumnType("datetime2");

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("zanr")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Filmovi");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ProjekcijaId")
                        .HasColumnType("int");

                    b.Property<int?>("korisnikId")
                        .HasColumnType("int");

                    b.Property<int?>("sedisteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjekcijaId");

                    b.HasIndex("korisnikId");

                    b.HasIndex("sedisteId");

                    b.ToTable("Karte");
                });

            modelBuilder.Entity("Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("admin")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("Models.Projekcija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BioskopId")
                        .HasColumnType("int");

                    b.Property<int?>("FilmId")
                        .HasColumnType("int");

                    b.Property<int?>("salaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("vreme")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BioskopId");

                    b.HasIndex("FilmId");

                    b.HasIndex("salaId");

                    b.ToTable("Projkecije");
                });

            modelBuilder.Entity("Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BioskopId")
                        .HasColumnType("int");

                    b.Property<int>("BrRedova")
                        .HasColumnType("int");

                    b.Property<int>("BrSedistaPoRedu")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BioskopId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("Models.Sediste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BrReda")
                        .HasColumnType("int");

                    b.Property<int>("BrSedistaURedu")
                        .HasColumnType("int");

                    b.Property<int?>("salaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("salaId");

                    b.ToTable("Sedista");
                });

            modelBuilder.Entity("Models.BioskopFilm", b =>
                {
                    b.HasOne("Models.Bioskop", "Bioskop")
                        .WithMany("Filmovi")
                        .HasForeignKey("BioskopId");

                    b.HasOne("Models.Film", "Film")
                        .WithMany("Bioskopi")
                        .HasForeignKey("FilmId");

                    b.Navigation("Bioskop");

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.HasOne("Models.Projekcija", "Projekcija")
                        .WithMany("Karte")
                        .HasForeignKey("ProjekcijaId");

                    b.HasOne("Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnikId");

                    b.HasOne("Models.Sediste", "sediste")
                        .WithMany()
                        .HasForeignKey("sedisteId");

                    b.Navigation("korisnik");

                    b.Navigation("Projekcija");

                    b.Navigation("sediste");
                });

            modelBuilder.Entity("Models.Projekcija", b =>
                {
                    b.HasOne("Models.Bioskop", "Bioskop")
                        .WithMany("Projekcije")
                        .HasForeignKey("BioskopId");

                    b.HasOne("Models.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId");

                    b.HasOne("Models.Sala", "sala")
                        .WithMany()
                        .HasForeignKey("salaId");

                    b.Navigation("Bioskop");

                    b.Navigation("Film");

                    b.Navigation("sala");
                });

            modelBuilder.Entity("Models.Sala", b =>
                {
                    b.HasOne("Models.Bioskop", null)
                        .WithMany("Sale")
                        .HasForeignKey("BioskopId");
                });

            modelBuilder.Entity("Models.Sediste", b =>
                {
                    b.HasOne("Models.Sala", "sala")
                        .WithMany()
                        .HasForeignKey("salaId");

                    b.Navigation("sala");
                });

            modelBuilder.Entity("Models.Bioskop", b =>
                {
                    b.Navigation("Filmovi");

                    b.Navigation("Projekcije");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Models.Film", b =>
                {
                    b.Navigation("Bioskopi");
                });

            modelBuilder.Entity("Models.Projekcija", b =>
                {
                    b.Navigation("Karte");
                });
#pragma warning restore 612, 618
        }
    }
}

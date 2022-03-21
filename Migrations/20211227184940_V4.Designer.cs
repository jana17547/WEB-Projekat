﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Web.Migrations
{
    [DbContext(typeof(AutoSkolaContext))]
    [Migration("20211227184940_V4")]
    partial class V4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.Kandidat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<string>("DatumUpisa")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DatumUpisa");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Prezime");

                    b.Property<int>("Staus")
                        .HasColumnType("int")
                        .HasColumnName("Staus");

                    b.HasKey("ID");

                    b.ToTable("Kandidat");
                });

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .UseIdentityColumn();

                    b.Property<double>("Cena")
                        .HasMaxLength(10)
                        .HasColumnType("float")
                        .HasColumnName("Cena");

                    b.Property<string>("GodineStarosti")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GodineStarosti");

                    b.Property<string>("Naziv")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("Naziv");

                    b.HasKey("ID");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("Models.Polaganje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DatumPolaganja")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Tip")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Polaganja");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("KandidatID")
                        .HasColumnType("int");

                    b.Property<int?>("KategorijaID")
                        .HasColumnType("int");

                    b.Property<int>("Poeni")
                        .HasColumnType("int");

                    b.Property<int?>("PolaganjeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KandidatID");

                    b.HasIndex("KategorijaID");

                    b.HasIndex("PolaganjeID");

                    b.ToTable("KandidatiKategorije");
                });

            modelBuilder.Entity("Models.Spoj", b =>
                {
                    b.HasOne("Models.Kandidat", "Kandidat")
                        .WithMany("KandidatKategorija")
                        .HasForeignKey("KandidatID");

                    b.HasOne("Models.Kategorija", "Kategorija")
                        .WithMany("KategorijaKandidat")
                        .HasForeignKey("KategorijaID");

                    b.HasOne("Models.Polaganje", "Polaganje")
                        .WithMany("KandidatiKategorije")
                        .HasForeignKey("PolaganjeID");

                    b.Navigation("Kandidat");

                    b.Navigation("Kategorija");

                    b.Navigation("Polaganje");
                });

            modelBuilder.Entity("Models.Kandidat", b =>
                {
                    b.Navigation("KandidatKategorija");
                });

            modelBuilder.Entity("Models.Kategorija", b =>
                {
                    b.Navigation("KategorijaKandidat");
                });

            modelBuilder.Entity("Models.Polaganje", b =>
                {
                    b.Navigation("KandidatiKategorije");
                });
#pragma warning restore 612, 618
        }
    }
}

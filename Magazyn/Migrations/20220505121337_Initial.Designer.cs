﻿using Magazyn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Magazyn.Migrations
{
    [DbContext(typeof(MagazynDBContext))]
    [Migration("20220505121337_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Magazyn.Models.Akcesoria", b =>
                {
                    b.Property<int>("AkcesoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AkcesoriaID"), 1L, 1);

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AkcesoriaID");

                    b.ToTable("Akcesoria");
                });

            modelBuilder.Entity("Magazyn.Models.Plyty", b =>
                {
                    b.Property<int>("PlytyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlytyID"), 1L, 1);

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typ")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlytyID");

                    b.ToTable("Plyty");
                });

            modelBuilder.Entity("Magazyn.Models.Prowadnice", b =>
                {
                    b.Property<int>("ProwadniceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProwadniceID"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Dlugosc")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Samodomyk")
                        .HasColumnType("bit");

                    b.HasKey("ProwadniceID");

                    b.ToTable("Prowadnice");
                });

            modelBuilder.Entity("Magazyn.Models.RozmiaryPlyt", b =>
                {
                    b.Property<int>("RozmiarPlytyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RozmiarPlytyID"), 1L, 1);

                    b.Property<int>("Dlugosc")
                        .HasColumnType("int");

                    b.Property<int>("Grubosc")
                        .HasColumnType("int");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int>("PlytaID")
                        .HasColumnType("int");

                    b.Property<int>("Szerokosc")
                        .HasColumnType("int");

                    b.HasKey("RozmiarPlytyID");

                    b.HasIndex("PlytaID");

                    b.ToTable("RozmiaryPlyt");
                });

            modelBuilder.Entity("Magazyn.Models.Uchwyty", b =>
                {
                    b.Property<int>("UchwytID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UchwytID"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<string>("Kolor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rozstaw")
                        .HasColumnType("int");

                    b.HasKey("UchwytID");

                    b.ToTable("Uchwyty");
                });

            modelBuilder.Entity("Magazyn.Models.Zawiasy", b =>
                {
                    b.Property<int>("ZawiasID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZawiasID"), 1L, 1);

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hamulec")
                        .HasColumnType("bit");

                    b.Property<int>("Ilosc")
                        .HasColumnType("int");

                    b.Property<int>("Kat_Otwarcia")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Sprezyna")
                        .HasColumnType("bit");

                    b.HasKey("ZawiasID");

                    b.ToTable("Zawiasy");
                });

            modelBuilder.Entity("Magazyn.Models.RozmiaryPlyt", b =>
                {
                    b.HasOne("Magazyn.Models.Plyty", "Plyta")
                        .WithMany("RozmiaryPlyt")
                        .HasForeignKey("PlytaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plyta");
                });

            modelBuilder.Entity("Magazyn.Models.Plyty", b =>
                {
                    b.Navigation("RozmiaryPlyt");
                });
#pragma warning restore 612, 618
        }
    }
}

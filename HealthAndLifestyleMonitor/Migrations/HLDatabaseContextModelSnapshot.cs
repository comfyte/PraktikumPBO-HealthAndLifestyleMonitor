﻿// <auto-generated />
using HealthAndLifestyleMonitor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthAndLifestyleMonitor.Migrations
{
    [DbContext(typeof(HLDatabaseContext))]
    partial class HLDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("HealthAndLifestyleMonitor.DatabaseModels.AirMinumModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Jumlah")
                        .HasColumnType("REAL");

                    b.Property<string>("Tanggal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Waktu")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DaftarAirMinum");
                });

            modelBuilder.Entity("HealthAndLifestyleMonitor.DatabaseModels.JadwalObatModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Deskripsi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hari")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nama")
                        .HasColumnType("TEXT");

                    b.Property<string>("Waktu")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DaftarJadwalObat");
                });

            modelBuilder.Entity("HealthAndLifestyleMonitor.DatabaseModels.TekananDarahModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Diastolik")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sistolik")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TanggalWaktu")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DaftarTekananDarah");
                });
#pragma warning restore 612, 618
        }
    }
}

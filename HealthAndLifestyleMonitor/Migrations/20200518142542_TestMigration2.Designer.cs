﻿// <auto-generated />
using HealthAndLifestyleMonitor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HealthAndLifestyleMonitor.Migrations
{
    [DbContext(typeof(HLDatabaseContext))]
    [Migration("20200518142542_TestMigration2")]
    partial class TestMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
        }
    }
}

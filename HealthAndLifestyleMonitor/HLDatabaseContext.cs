using HealthAndLifestyleMonitor.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public class HLDatabaseContext : DbContext
    {
        public DbSet<AirMinumModel> DaftarAirMinum { get; set; }
        public DbSet<JadwalObatModel> DaftarJadwalObat { get; set; }
        public DbSet<TekananDarahModel> DaftarTekananDarah { get; set; }
        public DbSet<UserPref> UserPrefs { get; set; }

        public HLDatabaseContext()
        {
            // Memastikan database telah terbuat
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=HLDatabase.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Pengaturan default
            modelBuilder.Entity<UserPref>().HasData(new List<UserPref>
            {
                new UserPref
                {
                    Id = 1,
                    Name = "temperature-unit",
                    StringValue = "C"
                },
                new UserPref
                {
                    Id = 2,
                    Name = "weather-location",
                    StringValue = "Yogyakarta"
                },
                new UserPref
                {
                    Id = 3,
                    Name = "sistolik-max",
                    IntValue = 120
                },
                new UserPref
                {
                    Id = 4,
                    Name = "diastolik-max",
                    IntValue = 80
                },
                new UserPref
                {
                    Id = 5,
                    Name = "sistolik-min",
                    IntValue = 90
                },
                new UserPref
                {
                    Id = 6,
                    Name = "diastolik-min",
                    IntValue = 60
                }
            });
        }
    }
}

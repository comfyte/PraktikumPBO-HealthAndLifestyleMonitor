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
        // add UserPrefs

        public HLDatabaseContext()
        {
            // Memastikan database telah terbuat
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=HLDatabase.db");
    }
}

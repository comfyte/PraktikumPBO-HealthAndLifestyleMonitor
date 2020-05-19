﻿using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public abstract class HLBase
    {
        public abstract void Tambah(int tambahan);

        // Method untuk submit data air minum
        protected void Submit(AirMinumModel dataAirMinum)
        {
            dataAirMinum.Tanggal = DateTime.Now.ToString("yyyy-MM-dd");
            dataAirMinum.Waktu = DateTime.Now.ToString("HH:mm");
            using (var db = new HLDatabaseContext())
            {
                db.Add(dataAirMinum);
                db.SaveChanges();
            }
        }

        // Method untuk submit data obat
        protected void Submit(string nama, string deskripsi)
        {
            // Database handling
        }

        protected void ParseTime()
        {
            // Get current time
        }
    }
}

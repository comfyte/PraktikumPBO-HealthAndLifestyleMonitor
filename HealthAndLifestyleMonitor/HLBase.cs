using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public abstract class HLBase
    {
        // Make protected?
        public static string TanggalSekarang
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd"); }
        }

        public static string WaktuSekarang
        {
            get { return DateTime.Now.ToString("HH:mm"); }
        }

        //public abstract void Tambah(int tambahan);
        //public abstract void Tambah(int sistolik, int diastolik);

        // Method untuk submit data air minum
        protected void Submit(AirMinumModel dataAirMinum)
        {
            dataAirMinum.Tanggal = TanggalSekarang;
            dataAirMinum.Waktu = WaktuSekarang;
            using (var db = new HLDatabaseContext())
            {
                db.Add(dataAirMinum);
                db.SaveChanges();
            }
        }

        // Method untuk submit data pengukuran tekanan darah
        protected void Submit(TekananDarahModel dataTekananDarah)
        {
            dataTekananDarah.TanggalWaktu = TanggalSekarang + " " + WaktuSekarang;
            using (var db = new HLDatabaseContext())
            {
                db.Add(dataTekananDarah);
                db.SaveChanges();
            }
        }

        // Method untuk submit data obat
        protected void Submit(string nama, string deskripsi)
        {
            // Database handling
        }
    }
}

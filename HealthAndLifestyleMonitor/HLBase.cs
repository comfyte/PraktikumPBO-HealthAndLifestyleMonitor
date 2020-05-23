using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public abstract class HLBase
    {
        // Move back to MainWindow class?
        public enum HLCategory { Cuaca, AirMinum, JadwalObat, TekananDarah };

        public static string HariSekarang
        {
            get { return DateTime.Now.ToString("dddd", CultureInfo.CreateSpecificCulture("id-ID")); }
        }

        protected string TanggalSekarang
        {
            get { return DateTime.Now.ToString("yyyy-MM-dd"); }
        }

        public static string WaktuSekarang
        {
            get { return DateTime.Now.ToString("HH:mm"); }
        }

        public static string[] GetDaftarHari()
        {
            return CultureInfo.CreateSpecificCulture("id-ID").DateTimeFormat.DayNames;
        }

        protected void Tambah(object newData)
        {
            using (var db = new HLDatabaseContext())
            {
                db.Add(newData);
                db.SaveChanges();
            }
        }

        //protected void Submit(AirMinumModel dataAirMinum)
        //{
        //    dataAirMinum.Tanggal = TanggalSekarang;
        //    dataAirMinum.Waktu = WaktuSekarang;
        //    using (var db = new HLDatabaseContext())
        //    {
        //        db.Add(dataAirMinum);
        //        db.SaveChanges();
        //    }
        //}

        // Method untuk submit data pengukuran tekanan darah
        //protected void Submit(TekananDarahModel dataTekananDarah)
        //{
        //    dataTekananDarah.TanggalWaktu = TanggalSekarang + " " + WaktuSekarang;
        //    using (var db = new HLDatabaseContext())
        //    {
        //        db.Add(dataTekananDarah);
        //        db.SaveChanges();
        //    }
        //}
    }
}

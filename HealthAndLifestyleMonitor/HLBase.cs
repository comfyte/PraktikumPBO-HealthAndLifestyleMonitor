using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public abstract class HLBase
    {
        public static string HariSekarang
        {
            get { return DateTime.Now.ToString("dddd", CultureInfo.CreateSpecificCulture("id-ID")); }
        }

        public static string TanggalSekarang
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
    }
}

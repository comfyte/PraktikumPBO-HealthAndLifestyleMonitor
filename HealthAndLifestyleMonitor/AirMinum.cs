using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace HealthAndLifestyleMonitor
{
    public class AirMinum : HLBase
    {
        public float TotalHariIni
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    try
                    {
                        List<float> liters = db.DaftarAirMinum
                            .Where(t => t.Tanggal == TanggalSekarang)
                            .Select(s => s.Jumlah)
                            .ToList();
                        return liters.Sum();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return 0;
                    }

                }
            }
        }
        public string TotalHariIniText
        {
            get { return TotalHariIni.ToString() + " liter"; }
        }

        public void Tambah(int tambahan)
        {
            Submit(new AirMinumModel { Jumlah = tambahan });
        }

        public List<AirMinumModel> GetDaftarHariIni()
        {
            using (var db = new HLDatabaseContext())
            {
                return db.DaftarAirMinum.ToList();
            }
        }

        public List<AirMinumModel> GetDaftarRiwayatHarian()
        {
            using (var db = new HLDatabaseContext())
            {
                return (
                    from item in db.DaftarAirMinum
                    group item by item.Tanggal into itemGroup
                    select new AirMinumModel
                    {
                        Tanggal = itemGroup.Key,
                        Jumlah = itemGroup.Sum(s => s.Jumlah)
                    }
                    ).ToList();
            }
        }
    }
}

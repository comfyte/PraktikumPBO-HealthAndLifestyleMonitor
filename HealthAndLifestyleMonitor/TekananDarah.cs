using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace HealthAndLifestyleMonitor
{
    public class TekananDarah : HLBase
    {
        public string TerakhirText
        {
            get { return GetSistolikTerakhir() + "/" + GetDiastolikTerakhir() + " mmHg"; }
        }

        public bool DiDalamRentangNormal
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    int SistolikMax = db.UserPrefs.Where(k => k.Name == "sistolik-max").First().IntValue;
                    int DiastolikMax = db.UserPrefs.Where(k => k.Name == "diastolik-max").First().IntValue;
                    int SistolikMin = db.UserPrefs.Where(k => k.Name == "sistolik-min").First().IntValue;
                    int DiastolikMin = db.UserPrefs.Where(k => k.Name == "diastolik-min").First().IntValue;

                    if (GetSistolikTerakhir() >= SistolikMin && GetDiastolikTerakhir() >= DiastolikMin &&
                        GetSistolikTerakhir() <= SistolikMax && GetDiastolikTerakhir() <= DiastolikMax)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        private int GetSistolikTerakhir()
        {
            try
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.DaftarTekananDarah.OrderBy(o => o.Id).Last().Sistolik;
                }
            }
            catch (InvalidOperationException)
            {
                // Saat belum ada data di database
                return 0;
            }
        }

        private int GetDiastolikTerakhir()
        {
            try
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.DaftarTekananDarah.OrderBy(o => o.Id).Last().Diastolik;
                }
            }
            catch (InvalidOperationException)
            {
                // Saat belum ada data di database
                return 0;
            }
        }

        public void Tambah(int sistolik, int diastolik)
        {
            TekananDarahModel dataBaru = new TekananDarahModel
            {
                Sistolik = sistolik,
                Diastolik = diastolik,
                TanggalWaktu = TanggalSekarang + " " + WaktuSekarang
            };
            base.Tambah(dataBaru);
        }

        public List<TekananDarahModel> GetDaftarRiwayat()
        {
            using (var db = new HLDatabaseContext())
            {
                return db.DaftarTekananDarah.ToList();
            }
        }
    }
}

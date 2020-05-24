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

        public bool DiDalamRentangNormal
        {
            get
            {
                if (GetSistolikTerakhir() >= BatasSistolikMin && GetDiastolikTerakhir() >= BatasDiastolikMin &&
                    GetSistolikTerakhir() <= BatasSistolikMax && GetDiastolikTerakhir() <= BatasDiastolikMax)
                {
                    return true;
                }
                return false;
            }
        }

        public int BatasSistolikMax
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(k => k.Name == "sistolik-max").First().IntValue;
                }
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("kurang-dari-nol");
                }
                else
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(k => k.Name == "sistolik-max").First().IntValue = value;
                        db.SaveChanges();
                    }
                }
            }
        }

        public int BatasDiastolikMax
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(k => k.Name == "diastolik-max").First().IntValue;
                }
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("kurang-dari-nol");
                }
                else
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(k => k.Name == "diastolik-max").First().IntValue = value;
                        db.SaveChanges();
                    }
                }
            }
        }

        public int BatasSistolikMin
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(k => k.Name == "sistolik-min").First().IntValue;
                }
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("kurang-dari-nol");
                }
                else
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(k => k.Name == "sistolik-min").First().IntValue = value;
                        db.SaveChanges();
                    }
                }
            }
        }

        public int BatasDiastolikMin
        {
            get
            {
                using (var db = new HLDatabaseContext())
                {
                    return db.UserPrefs.Where(k => k.Name == "diastolik-min").First().IntValue;
                }
            }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("kurang-dari-nol");
                }
                else
                {
                    using (var db = new HLDatabaseContext())
                    {
                        db.UserPrefs.Where(k => k.Name == "diastolik-min").First().IntValue = value;
                        db.SaveChanges();
                    }
                }
            }
        }

        public void Tambah(int sistolik, int diastolik)
        {
            if (sistolik > 0 && diastolik > 0)
            {
                TekananDarahModel dataBaru = new TekananDarahModel
                {
                    Sistolik = sistolik,
                    Diastolik = diastolik,
                    TanggalWaktu = TanggalSekarang + " " + WaktuSekarang
                };
                base.Tambah(dataBaru);
            }
            else
            {
                throw new InvalidOperationException("kurang-dari-nol");
            }
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

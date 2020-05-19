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
        public int SistolikTerakhir
        {
            get
            {
                try
                {
                    using (var db = new HLDatabaseContext())
                    {
                        return db.DaftarTekananDarah.OrderBy(o => o.Id).Last().Sistolik;
                    }
                }
                catch (InvalidOperationException e)
                {
                    return 0;
                }
            }
        }
        public int DiastolikTerakhir
        {
            get
            {
                try
                {
                    using (var db = new HLDatabaseContext())
                    {
                        return db.DaftarTekananDarah.OrderBy(o => o.Id).Last().Diastolik;
                    }
                }
                catch (InvalidOperationException e)
                {
                    return 0;
                }
            }
        }

        public string TerakhirText
        {
            get { return SistolikTerakhir + "/" + DiastolikTerakhir + " mm Hg"; }
        }

        public void Tambah(int sistolik, int diastolik)
        {
            Submit(new TekananDarahModel { Sistolik = sistolik, Diastolik = diastolik });
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

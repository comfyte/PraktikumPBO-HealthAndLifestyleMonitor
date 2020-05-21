using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation.Peers;

namespace HealthAndLifestyleMonitor
{
    public class JadwalObat : HLBase
    {
        public string JadwalHariIniText
        {
            get
            {
                string countText;
                using (var db = new HLDatabaseContext())
                {
                    int count = GetJadwalHariIni().Count();
                    if (count > 0)
                        countText = "memiliki " + count.ToString();
                    else
                        countText = "tidak memiliki";
                }
                return "Anda " + countText + " jadwal minum obat hari ini.";
            }
        }

        public void Tambah(string nama, string deskripsi, string waktu, bool isMingguan, int indeksHari)
        {
            JadwalObatModel dataBaru = new JadwalObatModel
            {
                Nama = nama,
                Deskripsi = deskripsi,
                Waktu = waktu,
                Hari = isMingguan ? GetDaftarHari()[indeksHari] : "setiapHari"
            };
            base.Tambah(dataBaru);
        }

        public void Hapus(int id)
        {
            using (var db = new HLDatabaseContext())
            {
                JadwalObatModel removeTarget = db.DaftarJadwalObat.Where(i => i.Id == id).First();
                db.Remove(removeTarget);
                db.SaveChanges();
            }
        }

        public List<JadwalObatModel> GetDaftarJadwalObat()
        {
            using (var db = new HLDatabaseContext())
            {
                List<JadwalObatModel> result = db.DaftarJadwalObat.ToList();
                foreach(JadwalObatModel item in result)
                {
                    if (item.Hari == "setiapHari")
                    {
                        item.Hari = "Setiap hari";
                    }
                }
                return result;
            }
        }

        public List<JadwalObatModel> GetJadwalHariIni()
        {
            using (var db = new HLDatabaseContext())
            {
                return db.DaftarJadwalObat.Where(o => o.Hari == HariSekarang || o.Hari == "setiapHari").ToList();
            }
        }
    }
}

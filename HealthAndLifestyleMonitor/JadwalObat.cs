using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public class JadwalObat : HLBase
    {
        public string JadwalHariIniText
        {
            get
            {
                return "Anda " + " jadwal minum obat hari ini.";
            }
        }

        public void Tambah(string nama, string deskripsi, int jam, int menit, bool isMingguan, int indeksHari)
        {
            JadwalObatModel dataBaru = new JadwalObatModel
            {
                Nama = nama,
                Deskripsi = deskripsi,
                Waktu = jam.ToString("D2") + ":" + menit.ToString("D2"),
                Hari = isMingguan ? GetDaftarHari()[indeksHari] : "setiapHari"
            };
            base.Tambah(dataBaru);
        }
    }
}

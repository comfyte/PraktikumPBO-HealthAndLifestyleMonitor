using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor.DatabaseModels
{
    public class JadwalObatModel : IHLDataModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public string Waktu { get; set; }
        //public bool Mingguan { get; set; }
        // Use blank Hari for daily
        public string Hari { get; set; }
    }
}

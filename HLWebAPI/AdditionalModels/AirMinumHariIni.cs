using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLWebAPI.AdditionalModels
{
    public class AirMinumHariIni
    {
        public string Tanggal { get; set; }
        public float TotalLiter { get; set; }
        public List<AirMinumHariIniListItem> Daftar { get; set; }
    }

    public class AirMinumHariIniListItem
    {
        public string Waktu { get; set; }
        public float Jumlah { get; set; }
    }
}

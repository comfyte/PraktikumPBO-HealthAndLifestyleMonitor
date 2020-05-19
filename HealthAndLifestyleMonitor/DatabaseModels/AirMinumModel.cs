using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor.DatabaseModels
{
    public class AirMinumModel : IHLDataModel
    {
        public int Id { get; set; }
        public string Tanggal { get; set; }
        public string Waktu { get; set; }
        public float Jumlah { get; set; }
    }
}

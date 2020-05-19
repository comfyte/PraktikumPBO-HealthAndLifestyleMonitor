using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor.DatabaseModels
{
    public class TekananDarahModel : IHLDataModel
    {
        public int Id { get; set; }
        public string TanggalWaktu { get; set; }
        public int Sistolik { get; set; }
        public int Diastolik { get; set; }
    }
}

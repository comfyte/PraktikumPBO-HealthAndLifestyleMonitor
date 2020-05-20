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
        public string Hari { get; set; }
    }
}

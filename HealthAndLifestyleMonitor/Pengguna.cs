using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public class Pengguna
    {
        public AirMinum AirMinum { get; private set; }
        public JadwalObat JadwalObat { get; private set; }
        public TekananDarah TekananDarah { get; private set; }

        public Pengguna()
        {
            this.AirMinum = new AirMinum();
            this.JadwalObat = new JadwalObat();
            this.TekananDarah = new TekananDarah();
        }
    }
}

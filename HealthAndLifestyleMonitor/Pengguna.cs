using System;
using System.Collections.Generic;
using System.Text;

namespace HealthAndLifestyleMonitor
{
    public class Pengguna
    {
        public AirMinum AirMinum { get; private set; }
        public TekananDarah TekananDarah { get; private set; }

        public Pengguna()
        {
            this.AirMinum = new AirMinum();
            this.TekananDarah = new TekananDarah();
        }

        //public void TekananDarahBaru(int sistolik, int diastolik)
        //{
        //    this._tekananDarahSistolik = sistolik;
        //    this._tekananDarahDiastolik = diastolik;
        //}
    }
}

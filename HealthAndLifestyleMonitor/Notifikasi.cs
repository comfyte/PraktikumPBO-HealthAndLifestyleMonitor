using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Threading;

namespace HealthAndLifestyleMonitor
{
    public class Notifikasi
    {
        public Notifikasi()
        {
            DispatcherTimer notificationTimer = new DispatcherTimer();
            notificationTimer.Interval = TimeSpan.FromMinutes(1);
            notificationTimer.Tick += notificationTimer_Tick;
            notificationTimer.Start();
        }

        private void notificationTimer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

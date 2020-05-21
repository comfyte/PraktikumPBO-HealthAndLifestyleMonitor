using HealthAndLifestyleMonitor.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace HealthAndLifestyleMonitor
{
    public class Notifikasi
    {
        private readonly Pengguna _user;

        public DispatcherTimer NotificationTimer { get; set; }

        public Notifikasi(Pengguna user)
        {
            _user = user;

            this.NotificationTimer = new DispatcherTimer();
            this.NotificationTimer.Interval = TimeSpan.FromMinutes(1);
            this.NotificationTimer.Tick += NotificationTimer_Tick;
            this.NotificationTimer.Start();
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            List<JadwalObatModel> notificationQueue;
            using (var db = new HLDatabaseContext())
            {
                notificationQueue = db.DaftarJadwalObat
                    .Where(o => (o.Hari == HLBase.HariSekarang || o.Hari == "setiapHari") && o.Waktu == HLBase.WaktuSekarang)
                    .ToList();
            }

            List<NotifikasiWindow> notificationWindows = new List<NotifikasiWindow>();
            foreach (JadwalObatModel item in notificationQueue)
            {
                string deskripsi = String.Format("Setiap {0}, pukul {1}", item.Hari == "setiapHari" ? "hari" : item.Hari, item.Waktu);
                NotifikasiWindow notificationWindow = new NotifikasiWindow(item.Nama, deskripsi);
                notificationWindow.Show();
                notificationWindows.Add(notificationWindow);
            }
        }
    }
}

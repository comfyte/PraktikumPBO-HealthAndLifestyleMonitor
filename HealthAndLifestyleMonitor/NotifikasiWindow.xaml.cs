using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HealthAndLifestyleMonitor
{
    /// <summary>
    /// Interaction logic for NotifikasiWindow.xaml
    /// </summary>
    public partial class NotifikasiWindow : Window
    {
        private DispatcherTimer _windowCloseTimer;

        private int _remainingSeconds = 6;

        private string _previousTitle;

        public NotifikasiWindow(string judul, string jadwal)
        {
            InitializeComponent();

            this.Left = System.Windows.SystemParameters.WorkArea.Width - this.Width - 10;
            this.Top = System.Windows.SystemParameters.WorkArea.Height - this.Height - 10;

            labelNama.Content = judul;
            labelJadwal.Content = jadwal;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();

            _previousTitle = this.Title;

            _windowCloseTimer = new DispatcherTimer();
            _windowCloseTimer.Interval = TimeSpan.FromSeconds(1);
            _windowCloseTimer.Tick += windowCloseTimer_Tick;
            _windowCloseTimer.Start();
        }

        private void windowCloseTimer_Tick(object sender, EventArgs e)
        {
            _remainingSeconds -= 1;
            if (_remainingSeconds < 0)
            {
                _windowCloseTimer.Stop();
                this.Close();
            }
            this.Title = _previousTitle + " (" + _remainingSeconds.ToString() + ")";
        }
    }
}

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

namespace HealthAndLifestyleMonitor
{
    /// <summary>
    /// Interaction logic for TambahAir.xaml
    /// </summary>
    public partial class TambahAirMinum : Window
    {
        private Pengguna _user;
        //public int Tambahan { get; private set; }

        public TambahAirMinum(Pengguna user)
        {
            InitializeComponent();
            _user = user;
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            _user.AirMinum.Tambah(int.Parse(textboxLiter.Text));
            this.Close();
        }
    }
}

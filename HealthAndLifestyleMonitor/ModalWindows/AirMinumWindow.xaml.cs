using HealthAndLifestyleMonitor.DatabaseModels;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthAndLifestyleMonitor.ModalWindows
{
    /// <summary>
    /// Interaction logic for AirMinumWindow.xaml
    /// </summary>
    public partial class AirMinumWindow : Window
    {
        private readonly Pengguna _user;

        public AirMinumWindow(Pengguna user)
        {
            InitializeComponent();
            _user = user;

            RefreshData();
        }

        private void RefreshData()
        {
            labelLiterAir.Content = _user.AirMinum.TotalHariIniText;
            datagridHariIni.ItemsSource = _user.AirMinum.GetDaftarHariIni();
            datagridRiwayatHarian.ItemsSource = _user.AirMinum.GetDaftarRiwayatHarian();
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            TambahAirMinum w = new TambahAirMinum(_user);
            w.ShowDialog();

            RefreshData();
        }
    }
}

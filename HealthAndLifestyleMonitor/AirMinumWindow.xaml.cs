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

namespace HealthAndLifestyleMonitor
{
    /// <summary>
    /// Interaction logic for AirMinumWindow.xaml
    /// </summary>
    public partial class AirMinumWindow : Window
    {
        private Pengguna _user;

        public AirMinumWindow(Pengguna user)
        {
            InitializeComponent();
            _user = user;

            labelLiterAir.Content = _user.AirMinum.TotalHariIniText;

            using (var db = new HLDatabaseContext())
            {
                datagridHariIni.ItemsSource = db.DaftarAirMinum.ToList();

                //datagridRiwayatHarian.ItemsSource = db.DaftarAirMinum.GroupBy(g => g.Tanggal)
                //    .Select(s => new AirMinumModel {
                //        Tanggal = s.Key,
                //        Jumlah = s.Sum(u => u.Jumlah)
                //    })
                //    .ToList();

                datagridRiwayatHarian.ItemsSource = (from item in db.DaftarAirMinum
                                                     group item by item.Tanggal into g
                                                     select new AirMinumModel
                                                     {
                                                         Tanggal = g.Key,
                                                         Jumlah = g.Sum(u => u.Jumlah)
                                                     })
                                                     .ToList();
            }
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            TambahAirMinum w = new TambahAirMinum(_user);
            w.ShowDialog();

            labelLiterAir.Content = _user.AirMinum.TotalHariIniText;

            using (var db = new HLDatabaseContext())
            {
                datagridHariIni.ItemsSource = db.DaftarAirMinum.ToList();
            }
        }
    }
}

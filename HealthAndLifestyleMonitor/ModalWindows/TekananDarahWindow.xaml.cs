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

namespace HealthAndLifestyleMonitor.ModalWindows
{
    /// <summary>
    /// Interaction logic for TekananDarahWindow.xaml
    /// </summary>
    public partial class TekananDarahWindow : Window
    {
        private readonly Pengguna _user;

        public TekananDarahWindow(Pengguna user)
        {
            InitializeComponent();
            _user = user;

            RefreshData();
        }

        private void RefreshData()
        {
            labelTekananDarahTerakhir.Content = _user.TekananDarah.TerakhirText;
            datagridRiwayat.ItemsSource = _user.TekananDarah.GetDaftarRiwayat();
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            TambahTekananDarah w = new TambahTekananDarah(_user) { Owner = this };
            w.ShowDialog();

            RefreshData();
        }
    }
}

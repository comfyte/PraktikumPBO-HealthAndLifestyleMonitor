using HealthAndLifestyleMonitor.ModalWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthAndLifestyleMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentRefreshable
    {
        private readonly Pengguna _user;
        private readonly Notifikasi _notifikasi;

        public MainWindow()
        {
            InitializeComponent();
            _user = new Pengguna();
            _notifikasi = new Notifikasi(_user);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshContent();
            Cuaca testcuaca = new Cuaca();
            textblockLokasi.Text = testcuaca.Lokasi;
        }

        public void RefreshContent()
        {
            RefreshContent(HLBase.HLCategory.AirMinum);
            RefreshContent(HLBase.HLCategory.JadwalObat);
            RefreshContent(HLBase.HLCategory.TekananDarah);
        }

        private void RefreshContent(HLBase.HLCategory category)
        {
            switch (category)
            {
                case HLBase.HLCategory.AirMinum:
                    labelLiterAir.Content = _user.AirMinum.TotalHariIniText;
                    break;
                case HLBase.HLCategory.JadwalObat:
                    if (_user.JadwalObat.GetJadwalHariIni() != null && _user.JadwalObat.GetJadwalHariIni().Count() != 0)
                    {
                        datagridJadwalObatHariIni.ItemsSource = _user.JadwalObat.GetJadwalHariIni();
                        datagridJadwalObatHariIni.Visibility = Visibility.Visible;
                        textblockTidakAdaJadwalObat.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        datagridJadwalObatHariIni.Visibility = Visibility.Hidden;
                        textblockTidakAdaJadwalObat.Visibility = Visibility.Visible;
                    }
                    break;
                case HLBase.HLCategory.TekananDarah:
                    labelTekananDarah.Content = _user.TekananDarah.TerakhirText;
                    labelTekananDarah.Foreground = _user.TekananDarah.DiDalamRentangNormal ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                    break;
                default:
                    break;
            }
        }

        private void buttonTambahAir_Click(object sender, RoutedEventArgs e)
        {
            TambahAirMinum modalWindow = new TambahAirMinum(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.AirMinum);
        }

        private void buttonAirSelengkapnya_Click(object sender, RoutedEventArgs e)
        {
            labelLiterAir.Opacity = 0.25;
            labelLiterAir.IsEnabled = false;

            AirMinumWindow modalWindow = new AirMinumWindow(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.AirMinum);
            labelLiterAir.Opacity = 1;
            labelLiterAir.IsEnabled = true;
        }

        private void buttonJadwalObatSelengkapnya_Click(object sender, RoutedEventArgs e)
        {
            datagridJadwalObatHariIni.IsEnabled = false;
            textblockTidakAdaJadwalObat.Opacity = 0.25;

            JadwalObatWindow modalWindow = new JadwalObatWindow(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.JadwalObat);
            datagridJadwalObatHariIni.IsEnabled = true;
            textblockTidakAdaJadwalObat.Opacity = 1;
        }

        private void buttonPengukuranBaru_Click(object sender, RoutedEventArgs e)
        {
            TambahTekananDarah modalWindow = new TambahTekananDarah(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.TekananDarah);
        }

        private void buttonTekananDarahSelengkapnya_Click(object sender, RoutedEventArgs e)
        {
            labelTekananDarah.Opacity = 0.25;
            labelTekananDarah.IsEnabled = false;

            TekananDarahWindow modalWindow = new TekananDarahWindow(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.TekananDarah);
            labelTekananDarah.Opacity = 1;
            labelTekananDarah.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult closeConfirmation = MessageBox.Show("Aplikasi harus tetap berjalan agar notifikasi obat dapat bekerja. Ingin tetap menutup aplikasi?", "Tutup Aplikasi", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (closeConfirmation == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                _notifikasi.NotificationTimer.Stop();
            }
        }

        private void buttonPengaturan_Click(object sender, RoutedEventArgs e)
        {
            PengaturanWindow pengaturan = new PengaturanWindow(_user) { Owner = this };
            pengaturan.ShowDialog();

            RefreshContent();
        }
    }
}

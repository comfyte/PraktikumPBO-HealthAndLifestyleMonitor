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
        private Pengguna _user;

        public MainWindow()
        {
            InitializeComponent();
            _user = new Pengguna();
            RefreshContent();
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
                    if (_user.JadwalObat.GetJadwalHariIni() != null)
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
            AirMinumWindow modalWindow = new AirMinumWindow(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.AirMinum);
        }

        private void buttonJadwalObatSelengkapnya_Click(object sender, RoutedEventArgs e)
        {
            JadwalObatWindow modalWindow = new JadwalObatWindow(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.JadwalObat);
        }

        private void buttonPengukuranBaru_Click(object sender, RoutedEventArgs e)
        {
            TambahTekananDarah modalWindow = new TambahTekananDarah(_user) { Owner = this };
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.TekananDarah);
        }

        private void buttonTekananDarahSelengkapnya_Click(object sender, RoutedEventArgs e)
        {
            TekananDarahWindow modalWindow = new TekananDarahWindow(_user) { Owner = this };
            labelTekananDarah.Opacity = 0.25; //testing
            labelTekananDarah.IsEnabled = false;
            modalWindow.ShowDialog();

            RefreshContent(HLBase.HLCategory.TekananDarah);
            labelTekananDarah.Opacity = 1; //testing
            labelTekananDarah.IsEnabled = true;
        }

        
    }
}

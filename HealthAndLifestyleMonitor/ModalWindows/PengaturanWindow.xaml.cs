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
    /// Interaction logic for PengaturanWindow.xaml
    /// </summary>
    public partial class PengaturanWindow : Window
    {
        private Pengguna _user;
        private Cuaca _cuaca;

        public enum SettingsCategory { Cuaca, JadwalObat, TekananDarah };

        public PengaturanWindow(Pengguna user)
        {
            InitializeComponent();
            _user = user;
            _cuaca = new Cuaca();

            textboxLokasiCuaca.Text = _cuaca.LocationPref;

            switch (_cuaca.TemperatureUnitPref)
            {
                case "C":
                    radiobuttonCelsius.IsChecked = true;
                    break;
                case "F":
                    radiobuttonFahrenheit.IsChecked = true;
                    break;
                case "K":
                    radiobuttonKelvin.IsChecked = true;
                    break;
                default:
                    break;
            }

            textboxSistolikMax.Text = _user.TekananDarah.BatasSistolikMax.ToString();
            textboxDiastolikMax.Text = _user.TekananDarah.BatasDiastolikMax.ToString();
            textboxSistolikMin.Text = _user.TekananDarah.BatasSistolikMin.ToString();
            textboxDiastolikMin.Text = _user.TekananDarah.BatasDiastolikMin.ToString();
        }

        public PengaturanWindow(Pengguna user, SettingsCategory category) : this(user)
        {
            switch (category)
            {
                case SettingsCategory.Cuaca:
                    tabitemCuaca.IsSelected = true;
                    break;
                case SettingsCategory.JadwalObat:
                    tabitemJadwalObat.IsSelected = true;
                    break;
                case SettingsCategory.TekananDarah:
                    tabitemTekananDarah.IsSelected = true;
                    break;
                default:
                    break;
            }
        }

        private void buttonTesNotifikasi_Click(object sender, RoutedEventArgs e)
        {
            NotifikasiWindow w = new NotifikasiWindow("Uji Coba Notifikasi", "Notifikasi akan tampil seperti ini");
            w.Show();
        }

        private void buttonSimpan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Cuaca
                textboxLokasiCuaca.Text = textboxLokasiCuaca.Text.Replace(" ", "");

                if (textboxLokasiCuaca.Text != _cuaca.LocationPref)
                    _cuaca.LocationPref = textboxLokasiCuaca.Text;

                if (radiobuttonCelsius.IsChecked ?? false)
                    _cuaca.TemperatureUnitPref = "C";
                else if (radiobuttonFahrenheit.IsChecked ?? false)
                    _cuaca.TemperatureUnitPref = "F";
                else if (radiobuttonKelvin.IsChecked ?? false)
                    _cuaca.TemperatureUnitPref = "K";

                // Tekanan darah
                _user.TekananDarah.BatasSistolikMax = int.Parse(textboxSistolikMax.Text);
                _user.TekananDarah.BatasDiastolikMax = int.Parse(textboxDiastolikMax.Text);
                _user.TekananDarah.BatasSistolikMin = int.Parse(textboxSistolikMin.Text);
                _user.TekananDarah.BatasDiastolikMin = int.Parse(textboxDiastolikMin.Text);

                this.Close();
            }
            catch (Exception ex) when (ex is FormatException || ex.Message == "kurang-dari-nol")
            {
                MessageBox.Show("Nilai tekanan darah tidak valid", "Gagal Mengatur Batas Baru", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex) when (ex.Message == "lokasi-tidak-valid")
            {
                MessageBox.Show("Lokasi yang Anda masukkan tidak valid", "Gagal Mengatur Lokasi Cuaca Baru", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonBatal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

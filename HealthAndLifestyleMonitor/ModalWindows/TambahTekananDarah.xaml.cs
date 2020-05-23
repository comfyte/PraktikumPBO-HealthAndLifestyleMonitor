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
    /// Interaction logic for TambahTekananDarah.xaml
    /// </summary>
    public partial class TambahTekananDarah : Window
    {
        private readonly Pengguna _user;

        //public int SistolikBaru { get; private set; }
        //public int DiastolikBaru { get; private set; }

        public TambahTekananDarah(Pengguna user)
        {
            InitializeComponent();
            _user = user;
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _user.TekananDarah.Tambah(int.Parse(textboxSistolik.Text), int.Parse(textboxDiastolik.Text));
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Masukan hanya dapat berupa bilangan bulat", "Galat", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

﻿using System;
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
    /// Interaction logic for TambahAir.xaml
    /// </summary>
    public partial class TambahAirMinum : Window
    {
        private readonly Pengguna _user;

        public TambahAirMinum(Pengguna user)
        {
            InitializeComponent();
            _user = user;
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _user.AirMinum.Tambah(float.Parse(textboxLiter.Text));
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Masukan hanya dapat berupa bilangan bulat atau desimal", "Galat", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException ex) when (ex.Message == "kurang-dari-nol")
            {
                MessageBox.Show("Nilai tidak boleh nol atau negatif", "Nilai Tidak Valid", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

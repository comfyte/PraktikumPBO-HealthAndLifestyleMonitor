﻿using System;
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
    public partial class MainWindow : Window
    {
        private Pengguna _user;

        public MainWindow()
        {
            InitializeComponent();
            _user = new Pengguna();

            labelLiterAir.Content = _user.AirMinum.TotalHariIniText;

            //labelTekananDarah.Content = _user.TekananDarahSistolik + "/" + _user.TekananDarahDiastolik + " mmHg";
        }

        private void buttonTambahAir_Click(object sender, RoutedEventArgs e)
        {
            TambahAirMinum w = new TambahAirMinum(_user);
            w.ShowDialog();
            labelLiterAir.Content = _user.AirMinum.TotalHariIniText;
        }

        private void buttonPengukuranBaru_Click(object sender, RoutedEventArgs e)
        {
            TambahTekananDarah w = new TambahTekananDarah();
            w.ShowDialog();
            _user.TekananDarahBaru(w.SistolikBaru, w.DiastolikBaru);
            //labelTekananDarah.Content = _user.TekananDarahSistolik + "/" + _user.TekananDarahDiastolik + " mmHg";
        }

        private void buttonAirSelengkapnya_Click(object sender, RoutedEventArgs e)
        {
            AirMinumWindow w = new AirMinumWindow(_user);
            w.ShowDialog();
            labelLiterAir.Content = _user.AirMinum.TotalHariIniText;
        }
    }
}

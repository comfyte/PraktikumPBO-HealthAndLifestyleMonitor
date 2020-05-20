using HealthAndLifestyleMonitor.DatabaseModels;
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
    /// Interaction logic for EditorJadwalObat.xaml
    /// </summary>
    public partial class EditorJadwalObat : Window
    {
        private readonly Pengguna _user;

        private bool _jadwalBaru; // Probably not needed since we can just check the dataObat value? Nope, still needed
        private int _id;

        // Constructor untuk menambah jadwal obat baru
        public EditorJadwalObat(Pengguna user)
        {
            InitializeComponent();
            _user = user;

            _jadwalBaru = true;
            this.Title = "Tambah Jadwal Obat Baru";
            buttonSimpan.Content = "Tambah";
            

            comboboxHari.ItemsSource = HLBase.GetDaftarHari();
        }
        
        // Constructor untuk mengubah jadwal obat di database
        public EditorJadwalObat(int id, JadwalObatModel dataObat)
        {
            InitializeComponent();
            _jadwalBaru = false;

            // TODO: Reduce params to just id
            textboxNama.Text = dataObat.Nama;
            textboxDeskripsi.Text = dataObat.Deskripsi;
            if (dataObat.Hari != "setiapHari")
            {
                radiobuttonMingguan.IsChecked = true;
                //comboboxHari.SelectedItem = "Selasa"; use days array and indexof instead
            }
        }

        private void Baru()
        {

        }

        private void Ubah()
        {

        }

        private void buttonSimpan_Click(object sender, RoutedEventArgs e)
        {
            // fixme, especially the ?? part
            _user.JadwalObat.Tambah(textboxNama.Text, textboxDeskripsi.Text, int.Parse(textboxJam.Text), int.Parse(textboxMenit.Text), radiobuttonMingguan.IsChecked ?? false, comboboxHari.SelectedIndex);
            this.Close();
        }
    }
}

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
    /// Interaction logic for EditorJadwalObat.xaml
    /// </summary>
    public partial class EditorJadwalObat : Window
    {
        private readonly Pengguna _user;

        private bool _jadwalBaru = true;
        private int _id;

        // Constructor default untuk menambah jadwal obat baru
        public EditorJadwalObat(Pengguna user)
        {
            InitializeComponent();
            _user = user;
            comboboxHari.ItemsSource = HLBase.GetDaftarHari();
        }
        
        // Constructor untuk mengubah jadwal obat di database
        public EditorJadwalObat(Pengguna user, int id) : this(user)
        {
            _jadwalBaru = false;
            _id = id;
            this.Title = "Ubah Jadwal Obat";
            buttonSimpan.Content = "Simpan";

            using (var db = new HLDatabaseContext())
            {
                JadwalObatModel selection = db.DaftarJadwalObat.Where(o => o.Id == id).First();
                textboxNama.Text = selection.Nama;
                textboxDeskripsi.Text = selection.Deskripsi;
                if (selection.Hari == "setiapHari")
                {
                    radiobuttonHarian.IsChecked = true;
                }
                else
                {
                    radiobuttonMingguan.IsChecked = true;
                    comboboxHari.SelectedValue = selection.Hari;
                }
                textboxJam.Text = selection.Waktu.Split(":")[0];
                textboxMenit.Text = selection.Waktu.Split(":")[1];
            }
        }

        private string ReformatWaktu(string jam, string menit)
        {
            return int.Parse(jam).ToString("D2") + ":" + int.Parse(menit).ToString("D2");
        }

        private void buttonSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (textboxNama.Text == "")
            {
                MessageBox.Show("Nama obat tidak boleh kosong", "Nama obat tidak valid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (!int.TryParse(textboxJam.Text, out _) || !int.TryParse(textboxMenit.Text, out _))
            {
                MessageBox.Show("Waktu hanya dapat berupa angka", "Waktu tidak valid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (int.Parse(textboxJam.Text) > 23 || int.Parse(textboxMenit.Text) > 59 || int.Parse(textboxJam.Text) < 0 || int.Parse(textboxMenit.Text) < 0)
            {
                MessageBox.Show("Jam atau menit tidak valid", "Waktu tidak valid", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if ((radiobuttonMingguan.IsChecked ?? false) && comboboxHari.SelectedIndex < 0)
            {
                MessageBox.Show("Anda belum memilih hari", "Tidak ada hari yang terpilih", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else if (_jadwalBaru)
            {
                _user.JadwalObat.Tambah(
                    textboxNama.Text, 
                    textboxDeskripsi.Text,
                    ReformatWaktu(textboxJam.Text, textboxMenit.Text),
                    radiobuttonMingguan.IsChecked ?? false, 
                    comboboxHari.SelectedIndex);
                this.Close();
            }

            else
            {
                using (var db = new HLDatabaseContext())
                {
                    JadwalObatModel editTarget = db.DaftarJadwalObat.Where(o => o.Id == _id).First();
                    editTarget.Nama = textboxNama.Text;
                    editTarget.Deskripsi = textboxDeskripsi.Text;
                    editTarget.Waktu = ReformatWaktu(textboxJam.Text, textboxMenit.Text);
                    if (radiobuttonHarian.IsChecked ?? false)
                    {
                        editTarget.Hari = "setiapHari";
                    }
                    else
                    {
                        editTarget.Hari = HLBase.GetDaftarHari()[comboboxHari.SelectedIndex];
                    }
                    db.SaveChanges();
                }
                this.Close();
            }
        }

        private void buttonBatal_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

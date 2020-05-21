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
    /// Interaction logic for JadwalObatWindow.xaml
    /// </summary>
    public partial class JadwalObatWindow : Window, IContentRefreshable
    {
        private Pengguna _user;

        public JadwalObatWindow(Pengguna user)
        {
            InitializeComponent();
            _user = user;

            RefreshContent();
        }

        public void RefreshContent()
        {
            datagridDaftarJadwalObat.ItemsSource = _user.JadwalObat.GetDaftarJadwalObat();
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            EditorJadwalObat addWindow = new EditorJadwalObat(_user) { Owner = this };
            addWindow.ShowDialog();

            RefreshContent();
        }

        private void buttonUbah_Click(object sender, RoutedEventArgs e)
        {
            if (datagridDaftarJadwalObat.SelectedItem != null)
            {
                EditorJadwalObat editWindow = new EditorJadwalObat(_user, (datagridDaftarJadwalObat.SelectedItem as JadwalObatModel).Id) { Owner = this };
                editWindow.ShowDialog();

                RefreshContent();
            }
            else
            {
                MessageBox.Show("Pilih salah satu item untuk mengedit", "Tidak ada item yang terpilih", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonHapus_Click(object sender, RoutedEventArgs e)
        {
            if (datagridDaftarJadwalObat.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Hapus \"" + (datagridDaftarJadwalObat.SelectedItem as JadwalObatModel).Nama + "\"?", "Konfirmasi", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    _user.JadwalObat.Hapus((datagridDaftarJadwalObat.SelectedItem as JadwalObatModel).Id);
                    RefreshContent();
                }
            }
            else
            {
                MessageBox.Show("Pilih salah satu item untuk dihapus", "Tidak ada item yang terpilih", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

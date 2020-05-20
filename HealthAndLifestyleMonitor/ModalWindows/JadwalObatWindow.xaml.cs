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
    public partial class JadwalObatWindow : Window
    {
        private Pengguna _user;

        public JadwalObatWindow(Pengguna user)
        {
            InitializeComponent();
            _user = user;
        }

        private void buttonTambah_Click(object sender, RoutedEventArgs e)
        {
            EditorJadwalObat addWindow = new EditorJadwalObat(_user) { Owner = this };
            addWindow.ShowDialog();
        }
    }
}

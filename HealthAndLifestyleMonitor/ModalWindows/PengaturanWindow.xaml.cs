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
        public enum SettingsCategory { Cuaca, JadwalObat, TekananDarah, WebAPI };

        public PengaturanWindow()
        {
            InitializeComponent();
        }

        public PengaturanWindow(SettingsCategory category) : this()
        {

        }
    }
}

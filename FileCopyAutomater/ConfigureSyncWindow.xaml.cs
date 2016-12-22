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
using System.Windows.Shapes;

namespace FileCopyAutomater
{
    /// <summary>
    /// Interaction logic for ConfigureSyncWindow.xaml
    /// </summary>
    public partial class ConfigureSyncWindow : Window
    {
        private SyncData _selectedSync;

        public ConfigureSyncWindow()
        {
            InitializeComponent();
        }

        public ConfigureSyncWindow(SyncData selectedFile)
        {
            _selectedSync = selectedFile;
        }
    }
}

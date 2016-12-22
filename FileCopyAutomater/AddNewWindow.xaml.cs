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
    /// Interaction logic for AddNewSyncFile.xaml
    /// </summary>
    public partial class AddNewWindow : Window
    {
        public AddNewWindow(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;
            checkBox_CanOverwrite.IsChecked = false;
        }
        private MainWindow _mainWindow;

        private void button_Browse1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Browse2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.AllFiles.Add(new SyncData(textBox_Source.Text, textBox_Target.Text, checkBox_CanOverwrite.IsChecked.Value));
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

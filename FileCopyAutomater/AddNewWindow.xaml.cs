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
        private bool _multipleItemsSelected = false;
        private string[] _multiSelectedItems;

        private void button_Browse1_Click(object sender, RoutedEventArgs e)
        {
            string[] pathArray = BrowseFiles(true);

            if (pathArray.Length > 1)
            {
                var text = new StringBuilder();
                text.Append(pathArray.First());
                for (int i = 1; i < pathArray.Length; i++)
                {
                    text.Append(", " + pathArray[i]);
                }
                textBox_Source.Text = text.ToString();
                _multipleItemsSelected = true;
                _multiSelectedItems = pathArray;
            }
            else
            {
                textBox_Source.Text = pathArray.First();
                _multipleItemsSelected = false;
            }
        }

        private void button_Browse2_Click(object sender, RoutedEventArgs e)
        {
            textBox_Target.Text = BrowseFiles(false).First();
        }

        private string[] BrowseFiles(bool allowMultiSelect)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.Multiselect = allowMultiSelect;
            bool? result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                return dlg.FileNames;
            }
            else
            {
                return new string[0];
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            if (_multipleItemsSelected)
            {
                foreach (string file in _multiSelectedItems)
                {
                    _mainWindow.AllFiles.Add(new SyncData(file, textBox_Target.Text, checkBox_CanOverwrite.IsChecked.Value));
                }
            }
            else
            {
                _mainWindow.AllFiles.Add(new SyncData(textBox_Source.Text, textBox_Target.Text, checkBox_CanOverwrite.IsChecked.Value));
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

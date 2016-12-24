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
        private bool? _sourceIsFile = null;
        private bool? _targetIsFile = null;

        private void button_BrowseSourceFile_Click(object sender, RoutedEventArgs e)
        {
            string[] pathArray = BrowseFiles(true);

            // Has user selected anything?
            if (pathArray != null)
            {
                _sourceIsFile = true;

                // Has user selected multiple files?
                if (pathArray.Length > 1)
                {
                    textBox_Source.Text = BuildTextForTextBox(pathArray);
                    _multipleItemsSelected = true;
                    _multiSelectedItems = pathArray;
                }
                else
                {
                    textBox_Source.Text = pathArray.First();
                    _multipleItemsSelected = false;
                }
            }
        }

        private void button_BrowseSourceFolder_Click(object sender, RoutedEventArgs e)
        {
            string path = BrowseFolders();
            if (path != null)
            {
                _sourceIsFile = false;
                _multipleItemsSelected = false;
                textBox_Source.Text = path;
            }
        }

        private string BrowseFolders()
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.ShowDialog();
            return dlg.SelectedPath;
        }

        private string BuildTextForTextBox(string[] pathArray)
        {
            var text = new StringBuilder();
            text.Append(pathArray.First());
            for (int i = 1; i < pathArray.Length; i++)
            {
                text.Append(", " + pathArray[i]);
            }
            return text.ToString();
        }

        private void button_BrowseTargetFile_Click(object sender, RoutedEventArgs e)
        {
            string path = BrowseFiles(false).First();
            if (path != null)
            {
                _targetIsFile = true;
                textBox_Target.Text = path;
            }
        }

        private void button_BrowseTargetFolder_Click(object sender, RoutedEventArgs e)
        {
            string path = BrowseFolders();
            if (path != null)
            {
                _targetIsFile = false;
                textBox_Target.Text = path;
            }
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
                return null;
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            // Valid choices
            if (_sourceIsFile == true && _targetIsFile == true && _multipleItemsSelected == false)
            {
                // File-to-file sync
            }
            else if (_sourceIsFile == false && _targetIsFile == false)
            {
                // Folder-to-folder sync

            }
            else if (_sourceIsFile == true && _targetIsFile == false)
            {
                // File-to-folder sync: multiselect is only allowed in this case
                if (_multipleItemsSelected == true)
                {

                }
            }
            else
            {
                // Invalid selection
                MessageBox.Show(IdentifyUserError());
            }



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

        private string IdentifyUserError()
        {
            if (_sourceIsFile == true && _targetIsFile == true && _multipleItemsSelected == true)
            {

            }




        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

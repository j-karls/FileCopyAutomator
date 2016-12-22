using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace FileCopyAutomater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private SyncData _selectedFile;
        public SyncData SelectedFile
        {
            get { return _selectedFile; }
            set { _selectedFile = value; OnPropertyChanged(nameof(SelectedFile)); }
        }

        private ObservableCollection<SyncData> _allFiles;
        public ObservableCollection<SyncData> AllFiles
        {
            get { return _allFiles; }
            set { _allFiles = value; OnPropertyChanged(nameof(AllFiles)); }
        }




        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            var popup = new AddNewWindow(this);
            popup.ShowDialog();
        }

        private void button_Sync_Click(object sender, RoutedEventArgs e)
        {
            SelectedFile.Sync();
        }

        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            var popup = new ConfigureSyncWindow(SelectedFile);
            popup.ShowDialog();
        }

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            AllFiles.Remove(SelectedFile);
        }

        private void button_SyncAll_Click(object sender, RoutedEventArgs e)
        {
            long allFilesSize = AllFiles.Sum(x => x.SyncMember.Size);
            foreach (SyncData file in AllFiles)
            {
                file.Sync();
                progressBar.Value += file.SyncMember.Size / allFilesSize;
            }
        }
    }
}

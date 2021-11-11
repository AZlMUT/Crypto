using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptons.Views.Crypts
{
    /// <summary>
    /// Логика взаимодействия для SettingForm.xaml
    /// </summary>
    public partial class SettingForm : Page
    {
        string LoadFile = Properties.Settings.Default.LoadFile,
            SaveFile = Properties.Settings.Default.SaveFile;
        
        string GetFolderFile()
        {
            string result = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ".txt|*.txt";
            dialog.ShowDialog();

            result = dialog.FileName;

            if (result.IndexOf(".txt") < 0)
                return "";

            return result;
        }
        void Save()
        {
            LoadFile = LoadFileBlock.Text;
            SaveFile = SaveFileBlock.Text;

            if (LoadFile.Length > 0) Properties.Settings.Default.LoadFile = LoadFile;
            if (SaveFile.Length > 0) Properties.Settings.Default.SaveFile = SaveFile;
        }
        private void NewLoadFile(object sender, RoutedEventArgs e)
        {
            string res = GetFolderFile();
            if (res != "") LoadFileBlock.Text = res;
        }
        private void NewSaveFile(object sender, RoutedEventArgs e)
        {
            string res = GetFolderFile();
            if (res != "") SaveFileBlock.Text = res;
        }
        private void SaveProperts(object sender, RoutedEventArgs e)
        {
            Save();
        }

        public SettingForm()
        {
            InitializeComponent();
            if (LoadFile.Length > 0) 
                LoadFileBlock.Text = LoadFile;
            if (SaveFile.Length > 0)
                SaveFileBlock.Text = SaveFile;
        }
    }
}

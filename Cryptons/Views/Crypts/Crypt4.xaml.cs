using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для Crypt4.xaml
    /// </summary>
    public partial class Crypt4 : Page
    {
        string LoadFile = Properties.Settings.Default.LoadFile,
            SaveFile = Properties.Settings.Default.SaveFile;
        public Crypt4()
        {
            InitializeComponent();
        }

        public string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                text_po.Text = GetHash(text_do.Text);
            }
            catch
            {
                text_po.Text = "";
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            text_do.Text = "";
            if (LoadFile.Length == 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                bool flag = (bool)ofd.ShowDialog();
                if (flag) LoadFile = ofd.FileName;
            };
            if (LoadFile.Length > 0)
            {

                try
                {
                    StreamReader sr = new StreamReader(LoadFile);
                    while (!sr.EndOfStream)
                    {
                        text_do.Text += sr.ReadLine() + '\n';
                    }
                    sr.Close();
                }
                catch
                {
                    text_do.Text = "Файл не удалось открыть!";
                }
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (SaveFile.Length == 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                bool flag = (bool)ofd.ShowDialog();
                if (flag) SaveFile = ofd.FileName;
            };

            if (SaveFile.Length > 0)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(SaveFile);
                    string[] result = text_po.Text.Split('\n');
                    foreach (string item in result)
                        sw.WriteLine(item);
                    sw.Close();
                }
                catch { }
            }
            else
            {
                MessageBox.Show("Файл не выбран!");
            }
        }
    }
}

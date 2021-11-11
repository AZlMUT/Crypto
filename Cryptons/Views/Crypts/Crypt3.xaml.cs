using Cryptons.Views.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Crypt3.xaml
    /// </summary>
    public partial class Crypt3 : Page
    {
        Transposition t;
        string LoadFile = Properties.Settings.Default.LoadFile,
            SaveFile = Properties.Settings.Default.SaveFile;
        public Crypt3()
        {
            InitializeComponent();
            t = new Transposition();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                t.SetKey(textKey.Text);
                text_po.Text = t.Encrypt(text_do.Text);
            }
            catch
            {
                new ErrorFrame("Данные были введены не кореектно! Выполнение метода было прервано!").Show();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                t.SetKey(textKey.Text);
                text_po.Text = t.Decrypt(text_do.Text);
            }
            catch
            {
                new ErrorFrame("Данные были введены не кореектно! Выполнение метода было прервано!").Show();
            }
        }

        private void KeyDownText(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString(); key = key.Substring(key.Length - 1, 1);
            if (!Char.IsDigit(key[0]))
                e.Handled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            text_do.Text = text_po.Text;
            text_po.Text = "";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
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

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
    /// Логика взаимодействия для Crypt1.xaml
    /// </summary>
    public partial class Crypt1 : Page
    {
        public Crypt1()
        {
            InitializeComponent();
        }

        string alf1 = "A-B-C-D-E-F-G-H-I-J-K-L-M-N-O-P-Q-R-S-T-U-V-W-X-Y-Z-a-b-c-d-e-f-g-h-i-j-k-l-m-n-o-p-q-r-s-t-u-v-w-x-y-z-А-Б-В-Г-Д-Е-Ё-Ж-З-И-Й-К-Л-М-Н-О-П-Р-С-Т-У-Ф-Х-Ц-Ч-Ш-Щ-Ъ-Ы-Ь-Э-Ю-Я-а-б-в-г-д-е-ё-ж-з-и-й-к-л-м-н-о-п-р-с-т-у-ф-х-ц-ч-ш-щ-ъ-ы-ь-э-ю-я- -1-2-3-4-5-6-7-8-9-0";       private char[] alf;
        string LoadFile = Properties.Settings.Default.LoadFile,
            SaveFile = Properties.Settings.Default.SaveFile;

        void Russian()
        {
            alf = new char[113];
            string[] s = alf1.Split('-');int i = 0;
            foreach (string l in s)
                alf[i++] = l[0];

        }

        private void KeyDownText(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString(); key = key.Substring(key.Length - 1, 1);
            if (!Char.IsDigit(key[0]))
                e.Handled = true;
        }




        public bool MYCRYPT()
        {
            string text = text_do.Text;
            if (textKey.Text.Length == 0)
                textKey.Text = "0";
            var array_input = text.ToCharArray();
            try
            {
                int key = Convert.ToInt32(textKey.Text);
                char[] array_output = array_input;
                if (alf == null) Russian();

                while (key >= alf.Length)
                {
                    key = key - alf.Length;
                }

                for (int i = 0; i < array_input.Length; i++)
                {
                    for (int j = 0; j < alf.Length; j++)
                    {
                        if (array_input[i] == alf[j])
                        {
                            if (j + key >= alf.Length)
                            {
                                int num = (j + key) - alf.Length;
                                array_output[i] = alf[num];
                                break;
                            }
                            else if (j + key < alf.Length)
                            {
                                array_output[i] = alf[j + key];
                                break;
                            }
                        }
                    }
                }
                string str = new string(array_output);
                text_po.Text = str.ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MYCRYPT();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (textKey.Text.Length == 0) 
                textKey.Text = "0";
            try
            {
                string text = text_do.Text;
                var array_input = text.ToCharArray();
                int key = Convert.ToInt32(textKey.Text);
                char[] array_output = array_input;


                if (alf == null) Russian();

                while (key >= alf.Length)
                {
                    key = key - alf.Length;
                }

                for (int i = 0; i < array_input.Length; i++)
                {
                    for (int j = 0; j < alf.Length; j++)
                    {
                        if (array_input[i] == alf[j])
                        {
                            if (j - key >= alf.Length)
                            {
                                int num = (j - key) - alf.Length;
                                array_output[i] = alf[num];
                                break;
                            }
                            else if (j - key < alf.Length && j - key >= 0)
                            {
                                array_output[i] = alf[j - key];
                                break;
                            }
                            else if (j - key <= 0)
                            {
                                array_output[i] = alf[alf.Length + (j - key)];
                                break;
                            }
                        }
                    }
                }
                string str = new string(array_output);
                text_po.Text = str.ToString();

            }
            catch
            {

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            text_do.Text = text_po.Text;
            text_po.Text = "";
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
            if (LoadFile.Length > 0) {

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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (SaveFile.Length == 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                bool flag = (bool)ofd.ShowDialog();
                if (flag) SaveFile = ofd.FileName;
            };
            
            if (SaveFile.Length>0)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(SaveFile);
                    string[] result = text_po.Text.Split('\n');
                    foreach (string item in result)
                        sw.WriteLine(item);
                    sw.Close();
                }
                catch{}
            }
            else
            {
                MessageBox.Show("Файл не выбран!");
            }
        }
    }
}

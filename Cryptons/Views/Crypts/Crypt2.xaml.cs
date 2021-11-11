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
    /// Логика взаимодействия для Crypt2.xaml
    /// </summary>
    public partial class Crypt2 : Page
    {
        public Crypt2()
        {
            InitializeComponent();
        }

        public char[] characters = new[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private int N; //довжина алфавіту
        string LoadFile = Properties.Settings.Default.LoadFile,
            SaveFile = Properties.Settings.Default.SaveFile;




        void MYCRYPT()
        {
            text_po.Text = "";
            if ((bool)radioButton1.IsChecked)
            {
                N = characters.Length;

                string[] sr = text_do.Text.Split('\n');
                foreach (string s in sr)
                {
                    text_po.Text += (Encode(s, Generate_Pseudorandom_KeyWord(s.Length, 100))) + '\n';
                }

            }
            else
            {
                N = characters.Length;
                if (key_word.Text.Length > 0)
                {
                    string[] sr = text_do.Text.Split('\n');

                    foreach (string s in sr)
                    {
                        text_po.Text += (Encode(s, key_word.Text)) + '\n';
                    }
                }

            }
        }

        void MYDECRYPT()
        {
            text_po.Text = "";
            if ((bool)radioButton1.IsChecked)
            {
                N = characters.Length;

                string[] sr = text_do.Text.Split('\n');
                foreach (string s in sr)
                {
                    text_po.Text += (Decode(s, Generate_Pseudorandom_KeyWord(s.Length, 100))) + '\n';
                }

            }
            else
            {
                N = characters.Length;
                if (key_word.Text.Length > 0)
                {
                    string[] sr = text_do.Text.Split('\n');
                    foreach (string s in sr)
                    {
                        text_po.Text += (Decode(s, key_word.Text)) + '\n';
                    }
                }

            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MYCRYPT();
            }
            catch
            {
                new ErrorFrame("Данные были введены не кореектно! Выполнение метода было прервано!").Show();
            }
            
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MYDECRYPT();
            }
            catch
            {
                new ErrorFrame("Данные были введены не кореектно! Выполнение метода было прервано!").Show();
            }
        }


        private string Encode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
               Array.IndexOf(characters, keyword[keyword_index])) % N;
                result += characters[c];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }
        //розшифрувати
        private string Decode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();
            string result = "";
            int keyword_index = 0;
            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;
                result += characters[p];
                keyword_index++;
                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }
            return result;
        }
        private string Generate_Pseudorandom_KeyWord(int lenght, int startSeed)
        {
            Random rand = new Random(startSeed);
            string result = "";
            for (int i = 0; i < lenght; i++)
                result += characters[rand.Next(0, characters.Length)];
            return result;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            text_do.Text = text_po.Text;
            text_po.Text = "";
        }
    }
}

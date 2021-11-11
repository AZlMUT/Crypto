using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для Crypt6.xaml
    /// </summary>
    public partial class Crypt6 : Page
    {
        char[] characters = new char[] { '#', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-' };
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

        public Crypt6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ((p_text.Text.Length > 0) && (q_text.Text.Length > 0) && (file_1.Text.Length > 0) && (file_2.Text.Length > 0))
                {
                    long p = Convert.ToInt64(p_text.Text); long q = Convert.ToInt64(q_text.Text); if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
                    {
                        string hash = File.ReadAllText(file_1.Text).GetHashCode().ToString();
                        long n = p * q; long m = (p - 1) * (q - 1);
                        long d = Calculate_d(m);
                        long e_ = Calculate_e(d, m);
                        List<string> result = RSA_Endoce(hash, e_, n);
                        StreamWriter sw = new StreamWriter(file_2.Text);
                        foreach (string item in result)
                            sw.WriteLine(item); sw.Close();
                        d_text.Text = d.ToString();
                        n_text.Text = n.ToString();
                    }
                }
            }
            catch
            {

            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if ((d_text.Text.Length > 0) && (n_text.Text.Length > 0) && (file_1.Text.Length > 0) && (file_2.Text.Length > 0))
                {
                    long d = Convert.ToInt64(d_text.Text); long n = Convert.ToInt64(n_text.Text); List<string> input = new List<string>();
                    StreamReader sr = new StreamReader(file_2.Text); while (!sr.EndOfStream)
                    { input.Add(sr.ReadLine()); }
                    sr.Close(); string result = RSA_Dedoce(input, d, n);
                    string hash = File.ReadAllText(file_1.Text).GetHashCode().ToString();

                    if (result.Equals(hash)) MessageBox.Show("Подписи совпадают");
                    else MessageBox.Show("Подписи совпадают");
                }
                else
                {
                    MessageBox.Show("Данные введены не верно");
                }
            }
            catch
            {

            }
            
        }
















        private void NewLoadFile(object sender, RoutedEventArgs e)
        {
            try
            {
                string res = GetFolderFile();
                if (res != "") file_1.Text = res;
            }
            catch
            {

            }
            
        }
        private void NewSaveFile(object sender, RoutedEventArgs e)
        {
            try
            {
                string res = GetFolderFile();
                if (res != "") file_2.Text = res;
            }
            catch
            {

            }
            
        }

        private bool IsTheNumberSimple(long n)
        {
            if (n < 2) return false;
            if (n == 2) return true;
            for (long i = 2; i < n; i++)
                if (n % i == 0) return false;
            return true;
        }
        //зашифрувати
        private List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>(); BigInteger bi;
            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);
                bi = new BigInteger(index); bi = BigInteger.Pow(bi, (int)e);
                BigInteger n_ = new BigInteger((int)n); bi = bi % n_;
                result.Add(bi.ToString());
            }
            return result;
        }
        //розшифрувати
        private string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = ""; try
            {
                BigInteger bi; foreach (string item in input)
                {
                    bi = new BigInteger(Convert.ToDouble(item));
                    bi = BigInteger.Pow(bi, (int)d); BigInteger n_ = new BigInteger((int)n); bi = bi % n_;
                    int index = Convert.ToInt32(bi.ToString()); result += characters[index].ToString();
                }
            }
            catch { }
            return result;
        }
        //розраховуємо d. d поинно бути взаємно простим с m
        private long Calculate_d(long m)
        {
            long d = m - 1; for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //якщо мають загальні дільники
                { d--; i = 1; }
            return d;
        }

        private void KeyDownText(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString(); key = key.Substring(key.Length - 1, 1);
            if (!Char.IsDigit(key[0]))
                e.Handled = true;
        }

        //розрахунок параметру e
        private long Calculate_e(long d, long m)
        {
            long e = 10;
            while (true) { if ((e * d) % m == 1) break; else e++; }
            return e;
        }
    }
}

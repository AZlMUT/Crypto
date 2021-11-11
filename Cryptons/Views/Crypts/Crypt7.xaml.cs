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
    /// Логика взаимодействия для Crypt7.xaml
    /// </summary>
    public partial class Crypt7 : Page
    {
        char[] characters = new char[] { 
        '#', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 
        'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ', 'Э', 'Ю', 
        'Я', ' ', '1', '2', '3', '4', '5', '6', '7','8', '9', '0' };


        public Crypt7()
        {
            InitializeComponent();
        }

        private void KeyDownText(object sender, KeyEventArgs e)
        {
            string key = e.Key.ToString(); key = key.Substring(key.Length - 1, 1);
            if (!Char.IsDigit(key[0]))
                e.Handled = true;
        }

        //зашифровать
        private void Button_Click(object sender, EventArgs e)
        {
            text_po.Text = "";
            try
            {
                if ((p_text.Text.Length > 0) && (q_text.Text.Length > 0))
                {
                    long p = Convert.ToInt64(p_text.Text);
                    long q = Convert.ToInt64(q_text.Text);

                    if (IsTheNumberSimple(p) && IsTheNumberSimple(q))
                    {
                        string s = text_do.Text;

                        s = s.ToUpper();

                        long n = p * q;
                        long m = (p - 1) * (q - 1);
                        long d = Calculate_d(m);
                        long e_ = Calculate_e(d, m);

                        List<string> result = RSA_Endoce(s, e_, n);

                        foreach (string item in result)
                            text_po.Text += item + '\n';

                        d_text.Text = d.ToString();
                        n_text.Text = n.ToString();

                    }
                    else
                        MessageBox.Show("p или q - не простые числа!");
                }
                else
                    MessageBox.Show("Введите p и q!");
            }
            catch { }            
        }

        //расшифровать
        private void Button_Click_1(object sender, EventArgs e)
        {
            text_po.Text = "";
            try
            {
                if ((d_text.Text.Length > 0) && (n_text.Text.Length > 0))
                {
                    long d = Convert.ToInt64(d_text.Text);
                    long n = Convert.ToInt64(n_text.Text);

                    List<string> input = new List<string>();
                    string[] res = text_do.Text.Split('\n');
                    foreach (string item in res)
                    {
                        input.Add(item);
                    }

                    string result = RSA_Dedoce(input, d, n);

                    text_po.Text = result;
                }
                else
                    MessageBox.Show("Введите секретный ключ!");
            }
            catch { }
        }

        //проверка: простое ли число?
        private bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        //зашифровать
        private List<string> RSA_Endoce(string s, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < s.Length; i++)
            {
                int index = Array.IndexOf(characters, s[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        //расшифровать
        private string RSA_Dedoce(List<string> input, long d, long n)
        {
            string result = "";

            BigInteger bi;

            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                int index = Convert.ToInt32(bi.ToString());

                result += characters[index].ToString();
            }

            return result;
        }

        //вычисление параметра d. d должно быть взаимно простым с m
        private long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        //вычисление параметра e
        private long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }

        private void Button_Click_3(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(Properties.Settings.Default.LoadFile);
                while (!sr.EndOfStream)
                    text_do.Text += sr.ReadLine() + '\n';
                sr.Close();
            }
            catch
            {

            }
            
        }

        private void Button_Click_4(object sender, EventArgs e)
        {

            try
            {
                StreamWriter sw = new StreamWriter(Properties.Settings.Default.SaveFile);
                string[] result = text_po.Text.Split('\n');
                foreach (string item in result)
                    sw.WriteLine(item);
                sw.Close();
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
    }
}
